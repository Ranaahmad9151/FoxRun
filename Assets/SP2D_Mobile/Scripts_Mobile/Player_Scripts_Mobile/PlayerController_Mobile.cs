using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityStandardAssets.CrossPlatformInput;

namespace Bitboys.SuperPlaftormer2D
{

    // This controller has been written from scratch. The Player Controller uses the Unity Physics for their behaviors. 
    //Thanks to GamePlusJames, Sebastian Lague, Gucio Devs and Brackeys to share their knowledge and help us to make this project possible.


    /// This Character Controller requires a Rigidbody 2D, Circle Collider 2D and Box Collider 2D components.


    public class PlayerController_Mobile : MonoBehaviour
    {


        // CHARACTER CONTROLLER VARIABLES//
        private Vector3 playerCheckpointPosition;
        public bool isInGame;
        public bool controllerActive; // This function enables or disables the gamepad, if it's activated will can control the character with booth gamepad and keyboard. If it's disabled we can only use the keyboard.
        public Transform playerGraphics; // The Character Sprites.
        [Range(0.0f, 50.0f)]           // Jump height Slide Bar.
        public float jumpHeight = 20; //The jump height.
        [Range(0.0f, 50.0f)]  // Move Speed Slide Bar.
        public float moveSpeed; // the Character  Horizontal movement speed.
        public float moveVelocity; // the Character Vertical movement speed.
        public Transform groundCheck; // The Transform component that determines if the Character it's in contact with the ground.
        [Range(0.0f, 1.0f)]           // Ground Check radius Slide Bar.
        public float groundCheckRadius; // This determines the space between the character Collider and the ground.
        public LayerMask whatIsGround; // We use this layer mask to tell the player what is ground and what is not.
        public bool isGrounded; // The bool that tells us when the player is grounded (true) or not (false).
        public bool doubleJumped; // The bool that tells us if the player is making a Double Jump.
        public bool playerAttack;
        public Animator myAnim; // The Animator component of the Player.


        public bool touchingLeftWall = false; // This determines if the player is touching a wall placed on their left.
        public Transform leftWallCheck; // The Transform component that determines if the Character it's in contact with a wall placed on their Left.
        [Range(0.0f, 1.0f)]           // Left Wall Check radius Slide Bar.
        public float leftWallTouchRadius = 0.3f; // This determines the space between the character Collider and the left placed walls.
        public LayerMask whatIsLeftWall; // We use this layer mask to tell the player what is a left wall and what is not. 

        public bool touchingRightWall = false; // This determines if the player is touching a wall placed on their right side.
        public Transform rightWallCheck; // The Transform component that determines if the Character it's in contact with a wall placed on their right.
        [Range(0.0f, 1.0f)]           // Right Wall check radius Slide Bar.
        public float rightWallTouchRadius = 0.3f; // This determines the space between the character Collider and the right placed walls.
        public LayerMask whatIsRightWall; // We use this layer mask to tell the player what is a right wall and what is not. 

        [Range(0.0f, 20)]           // Jump push force Slide Bar.
        public float jumpPushForce = 10f; //The amount of force applied to push the player to the opposite side when they are stuck on a wall.
        [Range(0.0f, 1000f)]           // Wall Jump force Slide Bar.
        public float jumpForce = 700f; // The force with which the player can jump when they are stuck on a wall.


        // WEAPON 01 VARIABLES //
        public Transform weapon0FirePoint; // The point from where the projectile is spawned.
        public GameObject wp0FireBall; // The Projectile Prefab.
        [Range(0.0f, 50.0f)]  // Fire Rate Slide Bar.
        public float fireRate = 0; // The amount of projectiles that we will spawn when presses the fire key/button.
        private float timeToFire; // The shots counter.
        public bool shootShake = false; // we want the camera shakes when the player shoots or not?

        // WEAPON 01 AUDIO AND PARTICLES VARIABLES //
        public AudioClip shotSfx; // The Shot 01 Audio file.
        [Range(0.0f, 5.0f)]  // Shot 01 Volume Slide Bar.
        public float shotSfxVolume = 1f; // The Shot Audio file volume amount.
        public ParticleSystem shotParticle; // The Shot 01 Particle Component.
        public ParticleSystem flipShotParticle; // The reverse Shot 01 Particle Component.
        public bool weapon0Shooting = false; // This determines if the player is Shooting.
        public bool canShot; // This determines if the player can shoot or no.
        public AudioClip reloadSfx; // The Reload effect Audio file.
        [Range(0.0f, 5.0f)]  // The reload sound effect volume Slide Bar.
        public float reloadSfxVolume; // The reload effect volume amount.

        // PLAYER KNOCKBACK / DAMAGED VARIABLES // 

        [Range(0.0f, 20.0f)]  // Knockback Slide Bar.
        public float knockback = 9.0f; // the amount of force applied to the player when he is damaged by an enemy.
        [Range(0.0f, 5.0f)]  // Knockback lenght Slide Bar.
        public float knockbackLength = 0.5f; // the lenght of the knockback.
        public float knockbackCounter; // this counts the times that the player is beaten.
        public bool knockFromRight; // This determines whether the character has been hit by the right and in that case, if the player is facing away, the sprite will look to the opposite side of which has been hit.
        public bool knockFromUp; // This determines wheter the player being hit from above.
                                 // PLAYER GENERAL AUDIO // 

        public AudioClip jumpSfx; // The jump sound effect audio clip.
        [Range(0.0f, 5.0f)]  // Jump effect Volumen Slide Bar.
        public float jumpSfxVolume = 1f; // The Jump effect volume amount.
        public AudioClip doubleJumpSfx; // The double Jump effect audio clip.
        [Range(0.0f, 5.0f)]  // Double Jump effect Volume Slide Bar.
        public float doubleJumpSfxVolume = 1f; // The double jump effect volume amount.
        public AudioClip groundingSfx; // The grounding sound effect audio clip.
        [Range(0.0f, 5.0f)]  // grounding sound fx volume Slide Bar.
        public float groundingSfxVolume = 1f; // the grounding sound effect volume amount.
        public AudioClip landedSfx; // The Landed sound effect audio clip.
        [Range(0.0f, 5.0f)]  // landed sound fx volume Slide Bar.
        public float landedSfxVolume = 1f; // the landed sound effect volumen amount.
        public AudioClip walledSfx; // the walled sound effect audio clip.
        [Range(0.0f, 5.0f)]  //walled sound fx volume Slide Bar.
        public float walledSfxVolume = 1f; // the walled sound effect volumen amount.


        //  PLAYER VARIOUS VARIABLES // 

        public bool facingRight = true; // This variable tells us when the player is facing to the right.
        public bool inSlope = false; // This determines if we are in contact with a slope.
        public bool walking = false; // This determines if the player is walking or not.
        public bool running = false; // This determines if the player it's running or not.
        public bool falling; // This determines if the player is falling down.
        public bool goUp; // This determines if the player is going up.


        public bool redDiamond; // This variable it's activated when the player picks up the red  gem.
        public bool yellowDiamond;// This variable it's activated when the player picks up the yellow gem.
        public bool blueDiamond;// This variable it's activated when the player picks up the blue gem.
        public bool lilaDiamond;// This variable it's activated when the player picks up the lila gem.
        public bool greenDiamond;// This variable it's activated when the player picks up the green gem.

        private HealthManager_Mobile health; // With this variable we call the health manager script.
        public Shake_Mobile ShakeController; // With this variable we call the Shake Effect Control script.
        private DollyZoom_Mobile dolly; // With this variable we call the Dolly Zoom script.
        private Door_Mobile door; // With this variable we call the Dolly Zoom script.

        // PLAYER PARTICLE SYSTEMS VARIABLES // 

        public GameObject hitParticle; // With this we create the space to assign the Hit Particle prefab.
        public ParticleSystem healthParticle; // Here we name the health particle system component.
        public ParticleSystem groundParticles; // Here we name the ground Particle system component.
        public ParticleSystem JumpParticles;// Here we name the Jump Particle system component.
        public ParticleSystem doubleJumpParticles;// Here we name the double jump Particle system component.
        public ParticleSystem groundedparticles;// Here we name The grounded Particle system component.
        public ParticleSystem wallParticles;// Here we name the wall Particle system component.
        public ParticleSystem wallJumpParticles;// Here we name the wall jump Particle system component.
        public ParticleSystem walledParticles;// Here we name the walled Particle system component.
        public ParticleSystem landedParticles;// Here we name the landed Particle system component.
        public ParticleSystem tokenParticles;// Here we name the Ui Token particles.



        // WEAPONS VARIABLE CALLS //

        private Weapon1_Mobile weapon1; // With this variable we call the Weapon 01 script.
        private Weapon2_Mobile weapon2; // With this variable we call the Weapon 02 script.
        private Weapon3_Mobile weapon3; // With this variable we call the Weapon 03 script.
        private Weapon4_Mobile weapon4; // With this variable we call the Weapon 04 script.



        // VORTEX INTRO //

        public bool vortexIntro = false; // This determines if we will use the vortex intro or not.
        private LevelManager_Mobile vortex; // Here we call the vortex variable of the LevelManager Script.
        [Range(0.0f, 1.0f)] // slide bar.
        public float maxScale = 1.0f; // This sets the maximum scale at which the character comes when appearing across the vortex.
        [Range(0.0f, 1.0f)] // slide bar.
        public float minScale = 0f; // This sets the minimum scale when the character appears through the vortex. If it is zero the character appears out of nowhere.
        [Range(0.0f, 10.0f)] // slide bar.
        public float scaleSpeed = 5.0f; // the speed as the character changes their size when it appears through the vortex.
        private Vector3 targetScale;// this variable creates a new vector with given  the x, y, z components.
        public bool allGemsCollected = false;
        public GameObject travelCharacter;
        private RigidbodyConstraints2D originalRigidboyContraints;

        // WATER / SWIMMING //

        public bool inWaterZone = false;
        public GameObject waterEnterParticles;
        public GameObject waterParticles;
        public Transform waterEffects;

        void Awake()
        {

            playerGraphics = transform.Find("PlayerGraphics"); // Here we tell the script that the Transform that contains the character sprites is Child of this object.
            myAnim = transform.Find("PlayerGraphics").GetComponent<Animator>();// Here we tell the script that the character Animator component it's in the same child object that contains the character sprites.
            ShakeController = FindObjectOfType<Shake_Mobile>(); // Call the Shake effect controller Script.
            door = FindObjectOfType<Door_Mobile>(); // Call the Shake effect controller Script.
            originalRigidboyContraints = this.gameObject.GetComponent<Rigidbody2D>().constraints;


            // Set to 0 the Grounded Particles before to start.
            var em = groundedparticles.emission;
            em.enabled = false;
            em.rateOverTime = new ParticleSystem.MinMaxCurve(0);

            // Here we call the Weapons Scripts to make use of them.
            weapon1 = FindObjectOfType<Weapon1_Mobile>();
            weapon2 = FindObjectOfType<Weapon2_Mobile>();
            weapon3 = FindObjectOfType<Weapon3_Mobile>();
            weapon4 = FindObjectOfType<Weapon4_Mobile>();

            dolly = FindObjectOfType<DollyZoom_Mobile>();   // Here we call the Dolly Zoom function script.
            vortex = FindObjectOfType<LevelManager_Mobile>();   // Here we call the level Manage script to make use of the vortex intro function.

        }
        private void OnEnable()
        {
            redDiamond=true; // This variable it's activated when the player picks up the red  gem.
            yellowDiamond=true;// This variable it's activated when the player picks up the yellow gem.
            blueDiamond=true;// This variable it's activated when the player picks up the blue gem.
            lilaDiamond=true;// This variable it's activated when the player picks up the lila gem.
            greenDiamond=true;
    }
        void FixedUpdate()// In the Fixed Update function we include all the actions that we want that work in every fixed framerate frame.
        {
            GetComponent<Rigidbody2D>().freezeRotation = true; // Freeze the Character rotation constantly to avoid to turn when is on a slope.

            

            // Here we make sure that if we pick or have any weapon items selected, the character can not shoot through their mouth.

            if (isInGame == true)
            {
                if (inWaterZone == true || weapon1.gotWeapon1 == true && weapon1.wp1Selected == true || weapon2.gotWeapon2 == true && weapon2.wp2Selected == true || weapon3.gotWeapon3 == true && weapon3.wp3Selected == true || weapon4.gotWeapon4 == true && weapon4.wp4Selected == true)
                {
                    canShot = false;
                }
                else
                {
                    // If don't have guns can shoot with his mouth.
                    canShot = true;
                }
            }


            //We take the GroundCheck position , the space between the character's collider and the ground and the "WhatIsGround" assigned layers that indicate what is ground to determine if the player is grounded or not.
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
            facingRight = playerGraphics.localScale.x > 0; // We determined that the character is facing right when the horizontal scale of his transform is greater than zero.



            // Then we make sure that if the Gamepad is active we can shoot with the Right trigger. From here we also control if we want to make the camera shake with every shoot.
            if (controllerActive == true && CrossPlatformInputManager.GetButtonDown("Fire1") && Time.time > timeToFire && canShot == true && !touchingLeftWall && !touchingRightWall)
            {
                Shoot();
                timeToFire = Time.time + 1 / fireRate; // Delay between shoots.
                                                       // Here we Start the coroutine that controls te he times that we press the fire button.
                StartCoroutine(ShootCounter());
                GetComponent<AudioSource>().PlayOneShot(shotSfx, shotSfxVolume); // The Shoot sound effect.
                myAnim.SetTrigger("Fire");

                // The Camera Shake... It's this function activated or not??
                if (shootShake == true)
                {
                    ShakeController.ShakeCamera(0.4f, 0.1f);
                }
                // Spawn particles when shoot to the left.
                if (playerGraphics.localScale.x < -0.1f)
                {
                    flipShotParticle.gameObject.GetComponent<ParticleSystem>().Play();
                }
                // Spawn particles when shoot to the right.
                if (playerGraphics.localScale.x > 0.1f)
                {
                    shotParticle.gameObject.GetComponent<ParticleSystem>().Play();
                }
            }
        }
        public GameObject[] wallTags;
        private void Start()
        {
            
            wallTags = GameObject.FindGameObjectsWithTag("Wall");
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public GameObject player;

        void Update()
        { // In the Update function we include all the actions that we want that work in every frame.

            // Swimming

            if (inWaterZone == true)
            {
                myAnim.SetTrigger("Swimming");

            }

            if (isInGame == true)
            {
                if (door.spawnTraveller == true)
                {
                    Instantiate(travelCharacter, this.transform.position, this.transform.rotation);

                }
            }

            //THE VORTEX//
            // If we use the intro of the vortex, the character will change its scale of 0 to 1, creating the feeling that appears through the vortex.
            if (vortexIntro == true)
            {
                this.transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
                if (vortex.openTheVortex == true)
                {
                    StartCoroutine("VortexIntro");
                }
            }

            if (isInGame == true)
            {
                // Switch between Weapons (if we have pick some)
                if (weapon1.gotWeapon1 || weapon2.gotWeapon2 || weapon3.gotWeapon3 || weapon4.gotWeapon4)
                {

                    if (controllerActive == true && CrossPlatformInputManager.GetButtonDown("SWR") && !touchingLeftWall && !touchingRightWall && !inWaterZone)
                    { // Play a sound if we press the switch between weapons button or key.
                        AudioSource.PlayClipAtPoint(reloadSfx, Camera.main.transform.position, reloadSfxVolume);
                    }
                }
            }

            // Here we determine that if the player is not touching the ground, it is not touching a wall and vertical speed is less than 0, it is falling. 
            if (GetComponent<Rigidbody2D>().velocity.y < -0.1 && !isGrounded && !touchingLeftWall && !touchingRightWall)
            {
                falling = true;
                // Set the fall animation
                myAnim.SetTrigger("Falling");
            }
            else
            {
                falling = false;
            }

            // Here we determine that if the player  vertical speed is bigger than 0, it's going up. 
            if (GetComponent<Rigidbody2D>().velocity.y > 0.1 && !isGrounded)
            {
                goUp = true;
                myAnim.SetTrigger("GoUp");// Set the going up animation

            }
            else
            {
                goUp = false;
            }

            //WALLS//////
            // if the player it's touching the Left  wall we activate the sticky animation and we ensure that the local scale is set to the right.
            if (touchingLeftWall == true)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -moveVelocity);
            }
            // if the player it's touching the right wall we activate the sticky animation and we ensure that the local scale is set to the left.
            if (touchingRightWall == true)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, moveVelocity);
            }
            // if we touch the left or right wall the gravity scale changes to avoid the player fall down so quickly. Also we apply some horizontal force to get the sticky feeling.
            if (touchingRightWall || touchingLeftWall)
            {
                
                

                /*GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -0.1f);
                Vector3 newPos = transform.position + new Vector3(0, 1, 0) * Time.deltaTime * 5;
                if (newPos != Vector3.zero)
                {
                    GetComponent<Rigidbody2D>().MovePosition(newPos);
                    // this.GetComponent<Rigidbody2D>().MovePosition(this.GetComponent<Rigidbody2D>().position+(new Vector2(GetComponent<Rigidbody2D>().velocity.y*5*Time)))

                }
                GetComponent<Rigidbody2D>().gravityScale = 0f;
                GetComponent<Rigidbody2D>().angularDrag = 0f;
*/
                //GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Static;
                // The Wall Down Particles emmission rate. 
                var em = wallParticles.emission;
                em.enabled = true;
                em.rateOverTime = new ParticleSystem.MinMaxCurve(10);

                isGrounded = false;  // if we are in a wall, we are not touching the ground.
                doubleJumped = false; // if we are in a wall, we can't make a double jump.
                inSlope = false; // if we are in a wall we are not in a slope.
                                 // When we touch a wall we disable all weapons to avoid bother us.
                weapon1.wp1Selected = false;
                weapon2.wp2Selected = false;
                weapon3.wp3Selected = false;
                weapon4.wp4Selected = false;
                // in a wall we disable the circle collider and activate the box collider. Only in walls!
                GetComponent<CircleCollider2D>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = true;

            }
            else
            {
                myAnim.enabled = true;
                GetComponent<Rigidbody2D>().gravityScale = 5f;


                // The Wall Down Particles emmission rate. 
                var em = wallParticles.emission;
                em.enabled = false;
                em.rateOverTime = new ParticleSystem.MinMaxCurve(0);

                //wallParticles.emissionRate = 0;
                GetComponent<CircleCollider2D>().enabled = true;
                GetComponent<BoxCollider2D>().enabled = false;

            }
            // Touching the left joystick or the character movement keys we can jump from one wall to another.

            //  Left to right.
            if (controllerActive && touchingLeftWall && Input.GetKey(KeyCode.RightArrow) && !isGrounded || touchingLeftWall && CrossPlatformInputManager.GetAxis("Horizontal_Mobile") > 0.5f && !isGrounded)
            {
               
                //WallJump(); // We call the walljump void function.
            }
            // Right to left.
            if (controllerActive == true && touchingRightWall && Input.GetKey(KeyCode.LeftArrow) && !isGrounded || touchingRightWall && CrossPlatformInputManager.GetAxis("Horizontal_Mobile") < -0.5f && !isGrounded)
            {
                //WallJump();// We call the walljump void function.
            }

            // We make sure that a double jump is over when the player is grounded.
            if (isGrounded)
                doubleJumped = false;
            myAnim.SetBool("Grounded", isGrounded); // Set the idle animation.
                                                    // if we are jumping or making a double jump the isgrounded function is set to false.
            if (doubleJumped)
            {
                isGrounded = false;
            }


            //SLOPE FUNCTION//
            // If the player is touching an slope we freeze the horizontal movement of the Rigidbody component.
            if (inSlope)
            {
                FreezeConstraints();
            }
            else
            {
                if (!inSlope && walking)
                {
                    UnfreezeConstraints();
                }
            }
            // To can walk thru the slopes we return to activate the horizontal movement but only when we move the joystick or the arrow keys.
            if (controllerActive == true && Input.GetKey(KeyCode.RightArrow) && inSlope || controllerActive == true && Input.GetKey(KeyCode.LeftArrow) && inSlope || controllerActive == true && CrossPlatformInputManager.GetAxis("Horizontal_Mobile") > 0.5f && inSlope || controllerActive == true && CrossPlatformInputManager.GetAxis("Horizontal_Mobile") < -0.5f && inSlope)
            {
                UnfreezeConstraints();
                inSlope = false;
                walking = true;

            }
            
            // JUMP FUNCTION // 
            // If the player is not touching a wall and is grounded can call the jump function.
            if (controllerActive == true && Input.GetKeyDown(KeyCode.Space) && isGrounded && !touchingLeftWall && !touchingRightWall || controllerActive == true && CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded && !touchingLeftWall && !touchingRightWall)
            {
                Jump();
                /*if (isJump)
                {
                    if (isJump)
                    {
                        foreach (GameObject wall in wallTags)
                        {
                            wall.SetActive(false);
                            Debug.Log("Collider Diseable");
                        }
                    }
                }*/
                /*else
                {
                    if (!isJump)
                    {
                        foreach (GameObject wall in wallTags)
                        {
                            wall.SetActive(true);
                            Debug.Log("Collider Enable");
                        }
                    }
                }*/

                if (!inWaterZone)
                {
                    JumpParticles.Emit(20);// Here we activate the jump particles.
                    if (controllerActive == true && Input.GetKeyDown(KeyCode.Space) || controllerActive == true && CrossPlatformInputManager.GetButtonDown("Jump"))
                    {
                        GetComponent<AudioSource>().PlayOneShot(jumpSfx, jumpSfxVolume); // the jump sound effect.
                    }
                }
                else
                {
                    JumpParticles.Emit(0);
                }
            }

            //DOUBLE JUMP FUNCTION // 
            // If the player is not touching a wall and is not grounded we can call the double jump function.
            if (controllerActive == true && Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !isGrounded && !touchingLeftWall && !touchingRightWall || controllerActive == true && CrossPlatformInputManager.GetButtonDown("Jump") && !doubleJumped && !isGrounded && !touchingLeftWall && !touchingRightWall)
            {
                doubleJump();
                doubleJumped = true;
                if (controllerActive == true && Input.GetKeyDown(KeyCode.Space) || controllerActive == true && CrossPlatformInputManager.GetButtonDown("Jump"))
                {
                    GetComponent<AudioSource>().PlayOneShot(doubleJumpSfx, doubleJumpSfxVolume);// the double jump sound effect.
                }
                // Here we activate the jump particles.
                if (!inWaterZone)
                {
                    doubleJumpParticles.Emit(10);
                }
                else
                {
                    doubleJumpParticles.Emit(0);
                }
            }

            // PLAYER MOVEMENT // 

            // PLAYER FOOTSTEPS
            //WALKING
            if (walking && isGrounded)
            {
                this.transform.Find("Walk_Sound").gameObject.SetActive(true);   // When the player walks we access to the child object that have an Audio Source and Unpause the looping sound.
            }
            else
            {
                this.transform.Find("Walk_Sound").gameObject.SetActive(false);// If the player stops the sound automatically stops.	
            }
            //RUNNING
            if (running == true && isGrounded)
            {
                this.transform.Find("Run_Sound").gameObject.SetActive(true);    // When the player walks we access to the child object that have an Audio Source and Unpause the looping sound.
                this.transform.Find("Walk_Sound").gameObject.SetActive(false); ;// If the player stops the sound automatically stops.	

            }
            else
            {
                this.transform.Find("Run_Sound").gameObject.SetActive(false);// If the player stops the sound automatically stops.	
            }

            // If we are running we increase the player move speed to 8.
            if (running == true)
            {
                moveSpeed = 8;
                // if player is walking we increase jump height is 25.
                if (walking)
                {
                    jumpHeight = 20;
                }
            }
            else
            {
                moveSpeed = 6;
                jumpHeight = 20;

            }
            // The Run button/Key.
            //If we press down the run button we are running.
            if (controllerActive == true && CrossPlatformInputManager.GetButton("Run") && walking && !touchingLeftWall && !touchingRightWall || controllerActive == true && Input.GetKey(KeyCode.LeftShift) && walking && !touchingLeftWall && !touchingRightWall)
            {
                running = true;
            }
            else
            {
                //If we leave up the run button we are not running.
                if (controllerActive == true && CrossPlatformInputManager.GetButtonUp("Run") && !touchingLeftWall && !touchingRightWall || controllerActive == true && Input.GetKeyUp(KeyCode.LeftShift) && !touchingLeftWall && !touchingRightWall)
                {
                    running = false;

                }
            }


            //JOYSTICK HORIZONTAL CONTROL//
            //The Joystick movement.
            if (controllerActive == true)
            {
                moveVelocity = moveSpeed * CrossPlatformInputManager.GetAxis("Horizontal_Mobile");// We multiply the move speed through the joystick travel in its horizontal movement.
            }

            //FLIP THE CHARACTER SPRITES//
            // We ensure that the character sprites turn to the side to which we are moving.
            if (controllerActive == true && CrossPlatformInputManager.GetAxis("Horizontal_Mobile") > 0.1f && !touchingLeftWall && !touchingRightWall)
            {
                playerGraphics.localScale = new Vector3(1, 1, 1); // Right flip.

            }
            if (controllerActive == true && CrossPlatformInputManager.GetAxis("Horizontal_Mobile") < -0.1f && !touchingLeftWall && !touchingRightWall)
            {
                playerGraphics.localScale = new Vector3(-1, 1, 1); // Left flip.
            }

            //KEYBOARD HORIZONTAL CONTROL//
            // The player only walks when is grounded.
            if (controllerActive == true && Input.GetKey(KeyCode.RightArrow))
            {
                moveVelocity = moveSpeed;
                playerGraphics.localScale = new Vector3(1, 1, 1); // Flip the character art(Right flip).

                // Grounded Particles ON/OFF
                var em = groundParticles.emission;
                em.enabled = false;
                em.rateOverTime = new ParticleSystem.MinMaxCurve(10);
            }
            else
            {
                var em = groundParticles.emission;
                em.enabled = false;
                em.rateOverTime = new ParticleSystem.MinMaxCurve(0);

            }
            if (controllerActive == true && Input.GetKey(KeyCode.LeftArrow))
            {
                //touchingRightWall)
                moveVelocity = -moveSpeed;
                playerGraphics.localScale = new Vector3(-1, 1, 1);// Left flip.

                // Ground Particles ON/OFF.
                var em = groundParticles.emission;
                em.enabled = false;
                em.rateOverTime = new ParticleSystem.MinMaxCurve(10);

            }
            else
            {
                var em = groundParticles.emission;
                em.enabled = false;
                em.rateOverTime = new ParticleSystem.MinMaxCurve(0);
            }

            // BOOL WALKING WITH KEYBOARD//
            // If the controller is active we can walk.
            if (controllerActive == true && Input.GetKey(KeyCode.RightArrow) && isGrounded == true || controllerActive == true && Input.GetKey(KeyCode.LeftArrow) && isGrounded == true)
            {

                walking = true;
            }
            else
            {
                walking = false;
            }
            // BOOL WALKING + PARTICLES JOYSTICK AND DIGITAL KEYPAD//

            if (controllerActive == true && CrossPlatformInputManager.GetAxis("Horizontal_Mobile") > 0.1f && isGrounded == true || controllerActive == true && CrossPlatformInputManager.GetAxis("Horizontal_Mobile") < -0.1f && isGrounded == true)
            {
                //Sets the ground particles amount when the player is walking
                var em = groundParticles.emission;
                em.enabled = false;
                em.rateOverTime = new ParticleSystem.MinMaxCurve(10);

                walking = true;
               /* if(AxisTouchButton.instance.isPressed==false)
                {
*/                 
                    //player.transform.rotation = Quaternion.Euler(0, 0, 0);
                //}
            }
            else
            {
                // Sets the ground particles amount to 0 if the player is not walking.
                var em = groundParticles.emission;
                em.enabled = false;
                em.rateOverTime = new ParticleSystem.MinMaxCurve(0);

                walking = false;
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // CHARACTER MOUTH SHOOT, AMMO, AMMO BAR DESCREASING AND DISABLING //

            // if leave up the key the weapon 0 shoot function sets to false. 
            if (controllerActive == true && Input.GetKeyUp(KeyCode.F) && !touchingLeftWall && !touchingRightWall && canShot == true)
            {
                weapon0Shooting = false;
            }
            //If we press down the fire key we call the shoot function.
            if (controllerActive == true && Input.GetKeyDown(KeyCode.F) && !touchingLeftWall && !touchingRightWall && canShot == true && Time.time > timeToFire)
            {
                Shoot(); // set the shoot function
                timeToFire = Time.time + 1 / fireRate;
                StartCoroutine("ShootCounter"); // We start the shot counter to can decrease the ammo ui bar.
                GetComponent<AudioSource>().PlayOneShot(shotSfx, shotSfxVolume); // the shoot sound effect.
                myAnim.SetTrigger("Fire"); // set the fire animation.

                // if this function is active, the camera will shake when we press down the fire button.
                if (shootShake == true)
                {
                    ShakeController.ShakeCamera(0.4f, 0.1f);
                }
                // Here we make sure that when the character shoot left or right, the particles follow the direction in which the character is facing.
                if (playerGraphics.localScale.x < -0.1f)
                {
                    flipShotParticle.gameObject.GetComponent<ParticleSystem>().Play();
                }
                if (playerGraphics.localScale.x > 0.1f)
                {
                    shotParticle.gameObject.GetComponent<ParticleSystem>().Play();

                }
            }

            //KNOCKBACK PLAYER'S DAMAGE //

            // If the knockback counter is set to zero and received a blow, the character will be pushed to the opposite side from which it has been hit.
            if (knockbackCounter <= 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                if (knockFromRight)
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-knockback, knockback);
                if (!knockFromRight)
                    GetComponent<Rigidbody2D>().velocity = new Vector2(knockback, knockback);
                knockbackCounter -= Time.deltaTime;
                myAnim.SetTrigger("Hit"); // Sets the player hit animation. 
                if (knockFromUp)
                    GetComponent<Rigidbody2D>().velocity = new Vector2(knockback, -knockback);
            }
            // This sets the player walk and run movement animation.
            myAnim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

            //This bool will be activated when the character has collected all the gems.
            if (redDiamond == true && blueDiamond == true && greenDiamond == true && lilaDiamond == true && yellowDiamond == true)
            {
                //allGemsCollected = true;
            }
            else
            {
                allGemsCollected = false;
            }
        }

        // SHOOT, WALL JUMP, JUMP AND DOUBLE JUMP FUNCTIONS // 
        void Shoot()
        {
            Instantiate(wp0FireBall, weapon0FirePoint.position, weapon0FirePoint.rotation); // When this function is called, we instantiate the shoot prefab based on the position and rotation of the firepoint transform.
        }
        void WallJump()
        {
            GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(jumpPushForce, jumpForce)); // We use the relative force function of the character Rigidbody 2D component to hang out with outside of a wall.
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
            wallJumpParticles.Emit(5); // Set the wall jump particle amount that we want to emit when the player leaves a wall.
        }
        //public bool isJump;
        public void Jump()
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight); // We determine the new position of the player based on the Rigidbody's x velocity and the jump amount.
            isJump = true;
            if (isJump)
            {
                if (isJump)
                {
                    foreach (GameObject wall in wallTags)
                    {
                        wall.SetActive(false);
                    }
                }
            }
        }
        public void doubleJump()
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);// We determine the new position of the player based on the Rigidbody's x velocity and the jump amount.

        }
        public void FreezeConstraints()
        {

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;

        }
        public void UnfreezeConstraints()
        {
            this.gameObject.GetComponent<Rigidbody2D>().constraints = originalRigidboyContraints;
            GetComponent<Rigidbody2D>().freezeRotation = true; // Freeze the Character rotation constantly to avoid to turn when is on a slope.

        }


        // We use the shoot counter enumerator function to measure the duration between shots.
        public IEnumerator ShootCounter()
        {
            weapon0Shooting = true;
            yield return new WaitForSeconds(0.1f);
            weapon0Shooting = false;
        }

        // With this feature control the time between the vortex opens, the character appears (changing its scale from 0 to 1), 
        //the control is activated so that we can move the player and we ensure that the player horizontal scale is set to initially look to the right.
        public IEnumerator VortexIntro()
        {
            yield return new WaitForSeconds(0.5f);
            targetScale.Set(maxScale, maxScale, maxScale);
            yield return new WaitForSeconds(1);
            controllerActive = true;
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        public bool isJump;
        public bool upperGrounded;
        public bool grounded;
        IEnumerator WallsCollider()
        {
            if (upperGrounded)
            {
                yield return new WaitForSeconds(0.001f);
                foreach (GameObject wall in wallTags)
                {
                    wall.SetActive(true);
                }
            }
            else if (grounded)
            {
                yield return new WaitForSeconds(0.05f);
                foreach (GameObject wall in wallTags)
                {
                    wall.SetActive(true);
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // COLLISIONS AND TRIGGER FUNCTIONS // 
        //public GameObject[] 
        void OnCollisionEnter2D(Collision2D coll)
        {
            //Physics2D.OverlapAreaAll(0, 0, "Enemy");
            if (coll.transform.tag == ("Ground"))
            {
                grounded = true;
                //myAnim.SetBool("PlayerAttack", false);
                StartCoroutine(WallsCollider());
            }
            if (coll.transform.tag == ("UpperGround") && !upperGrounded)
            {
                upperGrounded = true;
                //myAnim.SetBool("PlayerAttack", false);
                StartCoroutine(WallsCollider());
            }

            //Grounded collision, particles and sound effects.
            // If the player touches the ground and is not walking and is not goin up but is ending fall.
            if (coll.transform.tag == ("Ground") && !walking && !goUp && falling)
            {
                GameObject go = this.transform.Find("GroundedParticles").gameObject;
                go.SetActive(true);// We activate the "puff" grounded particles.
                groundedparticles.Emit(10);
                GetComponent<AudioSource>().PlayOneShot(groundingSfx, groundingSfxVolume);
            }
            else
            {
                groundedparticles.Emit(0);
                GameObject go = this.transform.Find("GroundedParticles").gameObject;
                go.SetActive(false); // set particles off.

            }
            //Slope grounded particles and sound effects.
            if (coll.transform.tag == ("Slope") && !walking && !goUp && falling)
            {
                GameObject go = this.transform.Find("LandedParticles").gameObject;
                go.SetActive(true);// We activate the "puff" grounded particles.
                landedParticles.Emit(10);
                GetComponent<AudioSource>().PlayOneShot(landedSfx, landedSfxVolume);
            }
            else
            {
                landedParticles.Emit(0);
                GameObject go = this.transform.Find("LandedParticles").gameObject;
                go.SetActive(false);// set particles off.
            }
            //HIT ENEMY PARTICLES//
            //This function sets active the "hit" particle system when the character collides with an enemy.
            if (coll.transform.tag == ("Enemy") || coll.transform.tag == ("Arrow"))
            {
                Instantiate(hitParticle, transform.position, transform.rotation);
            }
        }
        public ParticleSystem sandParticles;
        private void OnCollisionStay2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Mud"))
            {
                sandParticles.Emit(1);// Here we activate the jump particles.
            }
            if (collision.transform.tag == ("Ground"))
            {
                grounded = true;
                StartCoroutine(WallsCollider());
            }

        }

        // This collision use is to ensure that when the character is on a platform we stay on it.
        void OnCollisionExit2D(Collision2D other)
        {
            //NOT TOUCHING WALL ... EXIT!!
            if (other.transform.tag == ("UpperGround"))
            {
                foreach (GameObject wall in wallTags)
                {
                    wall.SetActive(false);
                }
            }

            if (other.transform.tag == ("Wall"))
            {
                touchingLeftWall = false;
                touchingRightWall = false;
            }
            if (other.transform.tag == "MovingPlatform")
            {
                GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Interpolate; // We activate the interpolate function to avoid the player vibration.

                transform.parent = null; // When the player leaves the platform this function is automatically disabled.
            }

        }
        /*public void PlayerCheckPointPosition()
        {
            playerCheckpointPosition = transform.position;
            transform.position = playerCheckpointPosition;
        }*/
        // if the player collides with a gem we automatically activate the bool function of each gem that we touch.
        
        void OnTriggerEnter2D(Collider2D other)
        {
            /*if(other.CompareTag("mushroom"))
            {
                PlayerCheckPointPosition();
                print("Checkpoint");
            }*/
            // if the player is placed over the object that have this script, automatically will be within a door zone.
            if (other.transform.tag == "Door")
            {
                door.playerInZone = true;
            }

            if (other.transform.tag == "RedGem")
                redDiamond = true; // We have the red gem
            if (other.transform.tag == "YellowGem")
                yellowDiamond = true;// We have the yellow gem
            if (other.transform.tag == "BlueGem")
                blueDiamond = true;// We have the blue gem
            if (other.transform.tag == "LilaGem")
                lilaDiamond = true;// We have the lila gem
            if (other.transform.tag == "GreenGem")
                greenDiamond = true;// We have the green gem

            // particles are emitted when we touch a health item.
            if (other.transform.tag == "HealthItem")
                healthParticle.gameObject.GetComponent<ParticleSystem>().Play();

            // particles spawned on the ui token when we pick up a token.
            if (other.transform.tag == "Token")
                tokenParticles.gameObject.GetComponent<ParticleSystem>().Play();


            // INS SLOPE FREEZZE//
            // this collision warns us that we are in an slope in order to freeze the character motion and not begin to slide down the slope.
            if (other.transform.tag == ("Slope"))
            {
                inSlope = true;
            }

            // MOVING PLATFORM PARENTING // 
            // This collision warns us that we are in a moving platform and parent the character and the platform to ensure that the character follows platform movement.
            if (other.transform.tag == "MovingPlatform")
            {
                GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.None;
                transform.parent = other.transform;
            }

            // DOLLY ZOOM ZONES COLLISION// 
            //If collides with a "Dolly Zoom zone" the "Zoom in" function of the camera is activated thus creating the camera's dolly zoom smooth effect.
            if (other.transform.tag == "DollyZoom")
            {
                dolly.inDollyZoomZone = true;

            }

            // know if the player is placed over the water object.
            if (other.transform.tag == "Water")
            {
                inWaterZone = true;
            }
            // know if the player hits the water effects activator and starts playing the water particles.
            if (other.transform.tag == "Water_Trigger" && !falling)
            {
                Instantiate(waterParticles, waterEffects.transform.position, waterEffects.transform.rotation);
            }
            // know if the player hits the water effects activator and starts playing the water particles.
            if (other.transform.tag == "Water_Trigger" && falling)
            {
                Instantiate(waterEnterParticles, waterEffects.transform.position, waterEffects.transform.rotation);
            }

           

        }
        //We use the "onTriggerExit2D" function to indicate the character that has stopped touching the ground, a wall .... And so to stop emitting particles or to call other functions.
        void OnTriggerExit2D(Collider2D other)
        {
            
            if (other.transform.tag == "Door")
            {
                door.playerInZone = false;
            }
            if (other.transform.tag == ("Slope"))
            {
                inSlope = false;
                UnfreezeConstraints();
                if (!walking)
                {
                    GameObject go = this.transform.Find("LandedParticles").gameObject;
                    go.SetActive(false);
                    landedParticles.Emit(0);
                }
            }
            if (other.transform.tag == ("Ground") && !walking)
            {
                GameObject go = this.transform.Find("GroundedParticles").gameObject;
                go.SetActive(false);
                groundedparticles.Emit(0);


            }
            if (other.transform.name == ("LeftWall"))
            {
                touchingLeftWall = false;

                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (other.transform.name == ("RightWall"))
            {
                touchingRightWall = false;

                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if(other.CompareTag("UpperGround"))
            {
                /*if (playerGraphics.localScale.x < 0)
                {
                    player.GetComponent<Rigidbody2D>().DOMove(new Vector3(player.transform.position.x - 0.4f, player.transform.position.y, 0), 0.2f);
                }
                else
                {
                    player.GetComponent<Rigidbody2D>().DOMove(new Vector3(player.transform.position.x + 0.4f, player.transform.position.y, 0), 0.3f);
                } */ 
            }
            if (other.transform.tag == "MovingPlatform")
            {
                GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Interpolate;
                transform.parent = null;
            }
            if (other.transform.tag == "DollyZoom")
            {
                dolly.inDollyZoomZone = false;
            }

            // know if the player is placed over the water object.
            if (other.transform.tag == "Water")
            {
                inWaterZone = false;
            }

        }
        //We use the "onTrigger`2D" function to indicate the character that it's still touching the ground, a wall ....
        void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Wall"))
            {
                if (other.transform.name == "RightWall")
                {
                    float y;
                    if (playerGraphics.localScale.x > 0) y = 1.25f;
                    else y = -1.25f;

                    RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, y, 0), new Vector3(1, 0f, 0));
                    Debug.DrawRay(transform.position + new Vector3(0, y, 0), new Vector3(1, 0f, 0), Color.red);
                    if (hit.collider.CompareTag("UpperGround"))
                    {
                        player.transform.DOMove(new Vector3(player.transform.position.x + 1.5f, player.transform.position.y + 2.5f, 0), 0.2f);
                        player.transform.rotation = Quaternion.Euler(0, 0, 90);
                        walking = true;
                    }
                    else if (hit.collider.CompareTag("Ground"))
                    {
                        player.transform.position += new Vector3(-0.15f, 0, 0);
                        player.transform.rotation = Quaternion.Euler(0, 0, 0);
                        walking = true;
                    }
                }
                else if (other.transform.name == ("LeftWall"))
                {
                    float y;
                    if (playerGraphics.localScale.x < 0) y = 0.9f;
                    else y = -1.25f;

                    RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-1f, y, 0), new Vector3(1, 0f, 0));
                    Debug.DrawRay(transform.position + new Vector3(-1f, y, 0), new Vector3(1, 0f, 0), Color.red);
                    Debug.Log(hit.collider.name);
                    if (hit.collider.CompareTag("UpperGround"))
                    {
                        player.transform.DOMove(new Vector3(player.transform.position.x - 1.5f, player.transform.position.y + 2.5f, 0), 0.2f);
                        player.transform.rotation = Quaternion.Euler(0, 0, 90);
                        walking = true;

                    }
                    else if (hit.collider.CompareTag("Ground"))
                    {
                        player.transform.position += new Vector3(-0.15f, 0, 0);
                        player.transform.rotation = Quaternion.Euler(0, 0, 0);
                        walking = true;

                    }
                }
            }
            if (other.transform.tag == "Door")
            {
                door.playerInZone = true;
            }

            if (other.transform.tag == ("Slope"))
            {
                inSlope = true;
            }
            //This collision warns us that we are in a moving platform and parent the character and the platform to ensure that the character follows platform movement.
            if (other.transform.tag == "MovingPlatform")
            {
                GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.None;
                transform.parent = other.transform;

            }
            // If we stay within a zone dolly zoom zoom I will set us until we leave it.
            if (other.transform.tag == "DollyZoom")
            {
                dolly.inDollyZoomZone = true;
            }
            // know if the player is placed over the water object.
            if (other.transform.tag == "Water")
            {
                inWaterZone = true;
            }
            if (other.transform.name == ("LeftWall")&& wallCheck==true)
            {

                touchingLeftWall = true; // We set the tounching left wall bool to true.
                if (touchingLeftWall == true)
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, -90);
                    walking = true;
                }
            } 
            if (other.transform.name == ("RightWall") && wallCheck == true)
            {
                touchingRightWall = true; // We set the tounching left wall bool to true.
                if (touchingRightWall == true)
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 90);
                    walking = true;

                }
            }
        }
        public bool wallCheck = false;
        public void LeftButton()
        {
           wallCheck=true;

        }
        public void RightButton()
        {
           wallCheck = true;
            
        }
    }
   
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY BITBOYS //////////////////////////////////////////////////////////////////////////////////////////////////////

