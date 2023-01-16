using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace Bitboys.SuperPlaftormer2D {

	// In this script we control the change between other weapons, shoot spawning and the weapon sounds among other things.

	public class Weapon1_Mobile : MonoBehaviour {

	public Transform muzzleFlashRight; // Sets the Muzzle flash effect Transform used when the player is facing and shooting to the right.
    public Transform muzzleFlashLeft;// Sets the Muzzle flash effect Transform used when the player is facing and shooting to the left.
	public Transform weapon1FirePoint;// Sets the transform position from where the shots are instantiated.
	public GameObject wp1FireBall; // The Weapon fireball prefab.
	public GameObject wp1FireBallRight; // The weapon fireball used when the player is facing and shooting to the right.
	public float wp1ShotDelay; // The delay between shoots.
	private float wp1ShotDelayCounter; // The shoots delay counter.
	[Range(0.0f, 5.0f)] // Slide Bar.
	public float timeBetweenShots = 0.3333f;  // Allow 3 shots per second
	private float timestamp; // 
	public AudioClip wp1ShotSfx; // the audio clip used when shooting.
	[Range(0.0f, 5.0f)] // Slide Bar.
	public float wp1ShotSfxVolume = 1f; // the audio clip effect volume amount.
	public int weapon1AmmoAmount; // the amount of ammo that we have.
	public GameObject wp1AmmoBar;// the UI bar that shows the amount of ammo that we have.
	public GameObject weapon1Gui; // the small weapon image that appears next to the weapon ammo bar.
	public bool gotWeapon1; // the bool that determinates if we got this weapon or not.
	public bool wp1Selected; // the bool that determinates if we have this weapon selected.
	private PlayerController_Mobile player; // The reference to the player controller script.
	private Weapon2_Mobile wp2; //The reference to the weapon 02 script.
	private Weapon3_Mobile wp3;//The reference to the weapon 03 script.
	private Weapon4_Mobile wp4;//The reference to the weapon 04 script.
	public bool shootShake = false;// we want the camera shakes when the player shoots or not?
	private Shake_Mobile ShakeController; // With this variable we call the Shake Effect Control script.

	void Start () {
		//Previously we have created some reference variables so now we have to tell the script how they can find the variables we need.
			player = FindObjectOfType<PlayerController_Mobile> ();
			wp2 = FindObjectOfType<Weapon2_Mobile> ();
			wp3 = FindObjectOfType<Weapon3_Mobile> ();
			wp4 = FindObjectOfType<Weapon4_Mobile> ();
			ShakeController = FindObjectOfType<Shake_Mobile> ();	// Call the Shake effect controller Script.

	}
	
	void Update () {

			if (player.inWaterZone == true) { // if the player is swimming the weapon will be disabled to avoid problems with animations. You can change this easely if you use your own animations.
				wp1Selected = false;
			}

			//If you select this weapon all others are disabled including the main character shot.
			if (wp1Selected) {
				player.canShot = false;
				wp2.wp2Selected = false;
				wp3.wp3Selected = false;
				wp4.wp4Selected = false;
			} 
			//If the player controller is activated and press the key or button to switch between weapons we can activate or deactivate this weapon or switch between we have.
			if (player.controllerActive == true && gotWeapon1 && CrossPlatformInputManager.GetButtonDown ("SWR") && !player.inWaterZone) {

				if(wp2.wp2Selected == false && wp3.wp3Selected == false && wp4.wp4Selected == false){
					wp1Selected = !wp1Selected; // if we press the switch between weapons button we can Enable/disable the weapon o change between the weapons we have.

				}
			}
			// WEAPON SPRITE ACTIVATION //

			//If we have collected the item of this weapon, we select it and we are not touching the wall, the weapon object will be activated and can use it.
			if (gotWeapon1 && wp1Selected && !player.touchingLeftWall && !player.touchingRightWall) {
				GameObject go = this.transform.Find ("Weapon_01").gameObject;
				go.SetActive (true);
			} 
			// If you don't have collected this item or we are touching a wall, the object will be deactivated.
			if (!gotWeapon1 || player.touchingLeftWall || player.touchingRightWall ) {

				GameObject go = this.transform.Find ("Weapon_01").gameObject;
				go.SetActive (false);
			}
		

		
			//If ammo is less than 0 will disable the weapon object and the ammo bar.
		if (weapon1AmmoAmount <= 0) {
		   wp1Selected = false;
			gotWeapon1 = false;
			GameObject go = wp1AmmoBar;
			go.SetActive (false); // deactivates the object.
				
			}
		

		// AMMO BAR DESCREASING AND DISABLING //
	
	// Set the button and the key that we use to shoot.
			if (player.controllerActive == true && CrossPlatformInputManager.GetButton ("Fire1") && Time.time >= timestamp && !player.touchingLeftWall && !player.touchingRightWall && gotWeapon1 && wp1Selected|| player.controllerActive == true && Time.time >= timestamp && Input.GetKey (KeyCode.F) && !player.touchingLeftWall && !player.touchingRightWall && gotWeapon1 && wp1Selected  ) {
				// if the player is facing right we instantiate the shoot pregab in the transform located to the right of the player.
			if(player.facingRight){
				Instantiate (wp1FireBall, weapon1FirePoint.position, weapon1FirePoint.rotation);
			}
				// if the player is facing left we instantiate the shoot pregab in the transform located to the left of the player.
			if(!player.facingRight){
				Instantiate (wp1FireBallRight, weapon1FirePoint.position, weapon1FirePoint.rotation);
			}
				// Also if the player looks to the right and we shoot, we instantiate the muzzle flash effect every time we press the fire button.
			if(player.facingRight){
			Instantiate (muzzleFlashRight, weapon1FirePoint.position, weapon1FirePoint.rotation);
			}else{
				Instantiate (muzzleFlashLeft, weapon1FirePoint.position, weapon1FirePoint.rotation); // if the player faces to the left we instantiate the muzzle flash effect to the left.

			}
				// the formula that controls the time between shoots.
			timestamp = Time.time + timeBetweenShots;
			wp1ShotDelayCounter = wp1ShotDelay;
			
				// Every time we shoot, we subtract a bullet of ammo amount.
			weapon1AmmoAmount = weapon1AmmoAmount - 1;

			GetComponent<AudioSource> ().PlayOneShot (wp1ShotSfx, wp1ShotSfxVolume); // the weapon shoot audio effect.
			
				// if we're shooting but we are static, we run a different animation that will show when we are shooting and walking at the same time.
			if (!player.walking) { 
				player.myAnim.SetTrigger ("Fire2"); // Only fire animation.
			} else {
				
				player.myAnim.SetTrigger ("Fire2Part2"); // fire and walking animation.
			}
			// if this function is active, the camera will shake when we press down the fire button.
			if (shootShake == true) {
			ShakeController.ShakeCamera (0.4f, 0.1f);
			}
				// the formula that controls the time between shoots.
			if (wp1ShotDelayCounter <= 0) {
				wp1ShotDelayCounter = wp1ShotDelay;
				timestamp = Time.time + timeBetweenShots;
			}
		}
			// WEAPON AMMO UI BAR // 

			//If we have collected the item of this weapon and we select it, the UI Ammo Bar object will be activated.
		if (wp1Selected && gotWeapon1 && !player.touchingLeftWall && !player.touchingRightWall) {
			
			GameObject go = wp1AmmoBar;
			go.SetActive (true);

			weapon1Gui.SetActive (true);
		} else { 
			GameObject go = wp1AmmoBar;
			go.SetActive (false);
			
			weapon1Gui.SetActive (false);
		}
	
		}
	}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY BITBOYS //////////////////////////////////////////////////////////////////////////////////////////////////////
