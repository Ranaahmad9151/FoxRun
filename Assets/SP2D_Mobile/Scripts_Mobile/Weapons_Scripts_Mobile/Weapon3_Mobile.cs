using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace Bitboys.SuperPlaftormer2D {

	// In this script we control the change between other weapons, shoot spawning and the weapon sounds among other things.

	public class Weapon3_Mobile : MonoBehaviour {
	
	public Transform muzzleFlashRight;// Sets the Muzzle flash effect Transform used when the player is facing and shooting to the right.
	public Transform muzzleFlashLeft;// Sets the Muzzle flash effect Transform used when the player is facing and shooting to the left.
	public Transform weapon3FirePoint;// Sets the transform position from where the shots are instantiated.
	public GameObject wp3FireBall;// The Weapon fireball prefab.
	public GameObject wp3FireBallRight;// The weapon fireball used when the player is facing and shooting to the right.
	public float wp3ShotDelay;// The delay between shoots.
	private float wp3ShotDelayCounter;// The shoots delay counter.
	[Range(0.0f, 5.0f)] // Slide Bar.
	public float timeBetweenShots = 0.2f;  // Allow 3 shots per second
	private float timestamp;
	public AudioClip wp3ShotSfx;// the audio clip used when shooting.
	[Range(0.0f, 5.0f)] // Slide Bar.
	public float wp3ShotSfxVolume = 1f;// the audio clip effect volume amount.
	public AudioClip wp3ChargeSfx;// the audio clip used when shooting.
	[Range(0.0f, 5.0f)] // Slide Bar.
	public float wp3ChargeSfxVolume = 1f;// the audio clip effect volume amount.
	public int weapon3AmmoAmount;// the amount of ammo that we have.
	public GameObject wp3AmmoBar;// the UI bar that shows the amount of ammo that we have.
	public GameObject weapon3Gui; // the small weapon image that appears next to the weapon ammo bar.
	public bool gotWeapon3;// the bool that determinates if we got this weapon or not.
	public bool wp3Selected;// the bool that determinates if we have this weapon selected.
	private PlayerController_Mobile player;// The reference to the player controller script.
	private Weapon1_Mobile wp1; //The reference to the weapon 01 script.
	private Weapon2_Mobile wp2; //The reference to the weapon 02 script.
	private Weapon4_Mobile wp4; //The reference to the weapon 04 script.
	public bool shootShake = false;// we want the camera shakes when the player shoots or not?
	private Shake_Mobile ShakeController; // With this variable we call the Shake Effect Control script.
	public bool slowMo = false;
	public bool triggerInUse = false; // this variable determines if we are pressing the gamepad shot trigger or not.
	public ParticleSystem distorsionParticles;// Here we name The grounded Particle system component.
	public ParticleSystem sparksParticles; // The Smoke particles

	
	void Start () {
		//Previously we have created some reference variables so now we have to tell the script how they can find the variables we need.
			player = FindObjectOfType<PlayerController_Mobile> ();
			wp1 = FindObjectOfType<Weapon1_Mobile> ();
			wp2 = FindObjectOfType<Weapon2_Mobile> ();
			wp4 = FindObjectOfType<Weapon4_Mobile> ();
			ShakeController = FindObjectOfType<Shake_Mobile> ();	// Call the Shake effect controller Script.
	}

	void Update () {

			if (player.inWaterZone == true) { // if the player is swimming the weapon will be disabled to avoid problems with animations. You can change this easely if you use your own animations.
				wp3Selected = false;
			}

			//If you select this weapon all others are disabled including the main character shot.
			if (wp3Selected) {
				player.canShot = false;
				wp1.wp1Selected = false;
				wp2.wp2Selected = false;
				wp4.wp4Selected = false;
			} 

			//If the player controller is activated and press the key or button to switch between weapons we can activate or deactivate this weapon or switch between we have.
			if (player.controllerActive == true && gotWeapon3 && CrossPlatformInputManager.GetButtonDown ("SWR")&& !player.inWaterZone) {

				if (wp1.wp1Selected == false && wp2.wp2Selected == false && wp4.wp4Selected == false) {

					wp3Selected = !wp3Selected;// if we press the switch between weapons button we can Enable/disable the weapon o change between the weapons we have.
				}
			}
			// WEAPON SPRITE ACTIVATION //

			//If we have collected the item of this weapon, we select it and we are not touching the wall, the weapon object will be activated and can use it.
			if (gotWeapon3 && wp3Selected && !player.touchingLeftWall && !player.touchingRightWall) {
				GameObject go = this.transform.Find ("Weapon_03").gameObject;
				go.SetActive (true);

			}
			// If you don't have collected this item or we are touching a wall, the object will be deactivated.
			if (!gotWeapon3 || player.touchingLeftWall || player.touchingRightWall ) {

				GameObject go = this.transform.Find ("Weapon_03").gameObject;
				go.SetActive (false);
			}

		//If ammo is less than 0 will disable the weapon object and the ammo bar.
		if (weapon3AmmoAmount <= 0) {
			wp3Selected = false;
			gotWeapon3 = false;
			GameObject go = wp3AmmoBar;
			go.SetActive (false); // deactivates the object.
		}
			// AMMO BAR DESCREASING AND DISABLING //

			// If the trigger is not being pressed we can shoot again.
			if (player.controllerActive == true && CrossPlatformInputManager.GetButtonUp ("Fire1") && triggerInUse == true) {
				triggerInUse = false;

			}

			// Set the button and the key that we use to shoot.
			if ( player.controllerActive == true && Time.time >= timestamp && Input.GetKeyDown (KeyCode.F) && !player.touchingLeftWall && !player.touchingRightWall && gotWeapon3 && wp3Selected  ||triggerInUse == false && player.controllerActive == true &&  Time.time >= timestamp && CrossPlatformInputManager.GetButton ("Fire1") && !player.touchingLeftWall && !player.touchingRightWall && gotWeapon3 && wp3Selected ) {
			// if the player is facing right we instantiate the shoot pregab in the transform located to the right of the player.

					
					StartCoroutine ("SlowMoShoot"); // We start the shot counter to can decrease the ammo ui bar.

					triggerInUse = true;

					distorsionParticles.gameObject.GetComponent<ParticleSystem> ().Play ();	



		}
			// WEAPON AMMO UI BAR // 

			//If we have collected the item of this weapon and we select it, the UI Ammo Bar object will be activated.
		if (wp3Selected && gotWeapon3 && !player.touchingLeftWall && !player.touchingRightWall) {
			
			GameObject go = wp3AmmoBar;
			go.SetActive (true);
			
			weapon3Gui.SetActive (true);
		} else {
			GameObject go = wp3AmmoBar;
			go.SetActive (false);
			
			weapon3Gui.SetActive (false);
		}
		
	}

		public IEnumerator SlowMoShoot(){
			slowMo = true;
			GetComponent<AudioSource> ().PlayOneShot (wp3ChargeSfx, wp3ChargeSfxVolume);// the weapon shoot audio effect.

			player.controllerActive = false;
			yield return new WaitForSeconds(0.05f);

			slowMo = false;
			player.controllerActive = true;
			distorsionParticles.gameObject.GetComponent<ParticleSystem> ().Stop ();	

			if(player.facingRight){
				Instantiate (wp3FireBall, weapon3FirePoint.position, weapon3FirePoint.rotation);
				player.gameObject.GetComponent<Rigidbody2D> ().AddForce (-transform.right * 2000);
				sparksParticles.gameObject.GetComponent<ParticleSystem> ().Play ();	
				GetComponent<AudioSource> ().PlayOneShot (wp3ShotSfx, wp3ShotSfxVolume);// the weapon shoot audio effect.
				Instantiate (muzzleFlashRight, weapon3FirePoint.position, weapon3FirePoint.rotation);


			}
			// if the player is facing left we instantiate the shoot pregab in the transform located to the left of the player.
			if(!player.facingRight){
				Instantiate (wp3FireBallRight, weapon3FirePoint.position, weapon3FirePoint.rotation);
				player.gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.right * 2000);
				sparksParticles.gameObject.GetComponent<ParticleSystem> ().Play ();	
				GetComponent<AudioSource> ().PlayOneShot (wp3ShotSfx, wp3ShotSfxVolume);// the weapon shoot audio effect.
				Instantiate (muzzleFlashLeft, weapon3FirePoint.position, weapon3FirePoint.rotation);

			}
		

			// Every time we shoot, we subtract a bullet of ammo amount.
			weapon3AmmoAmount = weapon3AmmoAmount - 1;


			// if we're shooting but we are static, we run a different animation that will show when we are shooting and walking at the same time.
			if (!player.walking) {
				player.myAnim.SetTrigger ("Fire2");// Only fire animation.
			} else {
				player.myAnim.SetTrigger ("Fire2Part2");// fire and walking animation.
			}
			// if this function is active, the camera will shake when we press down the fire button.
			if (shootShake == true) {
				ShakeController.ShakeCamera (0.4f, 0.1f);
			}
			// the formula that controls the time between shoots.
			if (wp3ShotDelayCounter <= 0) {
				wp3ShotDelayCounter = wp3ShotDelay;
				timestamp = Time.time + timeBetweenShots;
			}
			StopCoroutine ("SlowMoShoot"); // We start the shot counter to can decrease the ammo ui bar.


		}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////