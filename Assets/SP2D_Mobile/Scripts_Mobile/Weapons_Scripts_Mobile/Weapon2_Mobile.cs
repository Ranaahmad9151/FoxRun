using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace Bitboys.SuperPlaftormer2D {

	// In this script we control the change between other weapons, shoot spawning and the weapon sounds among other things.

	public class Weapon2_Mobile : MonoBehaviour {
	
	public Transform muzzleFlashRight; // Sets the Muzzle flash effect Transform used when the player is facing and shooting to the right.
	public Transform muzzleFlashLeft;// Sets the Muzzle flash effect Transform used when the player is facing and shooting to the left.
	public Transform weapon2FirePoint;// Sets the transform position from where the shots are instantiated.
	public GameObject wp2FireBall;// The Weapon fireball prefab.
	public GameObject wp2FireBallRight;// The weapon fireball used when the player is facing and shooting to the right.
	public float wp2ShotDelay;// The delay between shoots.
	private float wp2ShotDelayCounter;// The shoots delay counter.
	[Range(0.0f, 5.0f)] // Slide Bar.
	public float timeBetweenShots = 0.2f;  // Allow 3 shots per second
	private float timestamp;
	public AudioClip wp2ShotSfx;// the audio clip used when shooting.
	[Range(0.0f, 5.0f)] // Slide Bar.
	public float wp2ShotSfxVolume = 1f;// the audio clip effect volume amount.
	public int weapon2AmmoAmount;// the amount of ammo that we have.
	public GameObject wp2AmmoBar;// the UI bar that shows the amount of ammo that we have.
	public GameObject weapon2Gui; // the small weapon image that appears next to the weapon ammo bar.
	public bool gotWeapon2;// the bool that determinates if we got this weapon or not.
	public bool wp2Selected;// the bool that determinates if we have this weapon selected.
	private PlayerController_Mobile player;// The reference to the player controller script.
	private Weapon1_Mobile wp1; //The reference to the weapon 01 script.
	private Weapon3_Mobile wp3; //The reference to the weapon 03 script.
	private Weapon4_Mobile wp4; //The reference to the weapon 04 script.
	public bool shootShake = false;// we want the camera shakes when the player shoots or not?
	private Shake_Mobile ShakeController; // With this variable we call the Shake Effect Control script.

	
	void Start () {
		
	//Previously we have created some reference variables so now we have to tell the script how they can find the variables we need.
			player = FindObjectOfType<PlayerController_Mobile> ();
			wp1 = FindObjectOfType<Weapon1_Mobile> ();
			wp3 = FindObjectOfType<Weapon3_Mobile> ();
			wp4 = FindObjectOfType<Weapon4_Mobile> ();
			ShakeController = FindObjectOfType<Shake_Mobile> ();	// Call the Shake effect controller Script.
	}


	void Update () {

			if (player.inWaterZone == true) { // if the player is swimming the weapon will be disabled to avoid problems with animations. You can change this easely if you use your own animations.
				wp2Selected = false;
			}

			//If you select this weapon all others are disabled including the main character shot.
			if (wp2Selected) {
				player.canShot = false;
				wp1.wp1Selected = false;
				wp3.wp3Selected = false;
				wp4.wp4Selected = false;
			} 
			//If the player controller is activated and press the key or button to switch between weapons we can activate or deactivate this weapon or switch between we have.
			if (player.controllerActive == true && gotWeapon2 && CrossPlatformInputManager.GetButtonDown ("SWR")&& !player.inWaterZone) {

				if (wp1.wp1Selected == false && wp3.wp3Selected == false && wp4.wp4Selected == false) {

					wp2Selected = !wp2Selected;// if we press the switch between weapons button we can Enable/disable the weapon o change between the weapons we have.
				}
			}
			// WEAPON SPRITE ACTIVATION //

			//If we have collected the item of this weapon, we select it and we are not touching the wall, the weapon object will be activated and can use it.
			if (gotWeapon2 && wp2Selected && !player.touchingLeftWall && !player.touchingRightWall) {
				GameObject go = this.transform.Find ("Weapon_02").gameObject;
				go.SetActive (true);
			}
			// If you don't have collected this item or we are touching a wall, the object will be deactivated.
			if (!gotWeapon2 || player.touchingLeftWall || player.touchingRightWall ) {

				GameObject go = this.transform.Find ("Weapon_02").gameObject;
				go.SetActive (false);
			}

			//If ammo is less than 0 will disable the weapon object and the ammo bar.
		if (weapon2AmmoAmount <= 0) {
			wp2Selected = false;
			gotWeapon2 = false;
			GameObject go = wp2AmmoBar;
			go.SetActive (false); // deactivates the object.
		}
			// VIBRATION, AMMO BAR DESCREASING AND DISABLING //

			// Set the button and the key that we use to shoot.
			if (player.controllerActive == true && Time.time >= timestamp && CrossPlatformInputManager.GetButton ("Fire1") && !player.touchingLeftWall && !player.touchingRightWall && gotWeapon2 && wp2Selected ||player.controllerActive == true && Time.time >= timestamp && Input.GetKey (KeyCode.F) && !player.touchingLeftWall && !player.touchingRightWall && gotWeapon2 && wp2Selected ) {
			// if the player is facing right we instantiate the shoot pregab in the transform located to the right of the player.
			if(player.facingRight){
				Instantiate (wp2FireBall, weapon2FirePoint.position, weapon2FirePoint.rotation);
			}
			// if the player is facing left we instantiate the shoot pregab in the transform located to the left of the player.
			if(!player.facingRight){
				Instantiate (wp2FireBallRight, weapon2FirePoint.position, weapon2FirePoint.rotation);
			}
			if(player.facingRight){
				Instantiate (muzzleFlashRight, weapon2FirePoint.position, weapon2FirePoint.rotation);
			}else{
				Instantiate (muzzleFlashLeft, weapon2FirePoint.position, weapon2FirePoint.rotation);
			}
			// the formula that controls the time between shoots.
			timestamp = Time.time + timeBetweenShots;
			wp2ShotDelayCounter = wp2ShotDelay;
			// Every time we shoot, we subtract a bullet of ammo amount.
			weapon2AmmoAmount = weapon2AmmoAmount - 1;
			
			GetComponent<AudioSource> ().PlayOneShot (wp2ShotSfx, wp2ShotSfxVolume);// the weapon shoot audio effect.
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
			if (wp2ShotDelayCounter <= 0) {
				wp2ShotDelayCounter = wp2ShotDelay;
				timestamp = Time.time + timeBetweenShots;
			}
		}
			// WEAPON AMMO UI BAR // 

			//If we have collected the item of this weapon and we select it, the UI Ammo Bar object will be activated.
		if (wp2Selected && gotWeapon2 && !player.touchingLeftWall && !player.touchingRightWall) {
			
			GameObject go = wp2AmmoBar;
			go.SetActive (true);
			
			weapon2Gui.SetActive (true);
		} else {
			GameObject go = wp2AmmoBar;
			go.SetActive (false);
			
			weapon2Gui.SetActive (false);
		}

	}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////