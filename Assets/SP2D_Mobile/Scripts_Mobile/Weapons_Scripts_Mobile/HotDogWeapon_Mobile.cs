using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	// This script allows the Hot Dog Weapon animations.

	public class HotDogWeapon_Mobile : MonoBehaviour {

	private Animator myAnim; // The object animator component.
	private Weapon1_Mobile weapon; // The reference to the weapon 01 script.
	private PlayerController_Mobile player; // The reference to the player controller script.
	public bool hotDogIdle = false; // the bool that controls if the idle animation it's activated or not.

	void Start () {
			
    //Previously we have created some reference variables for the weapons scripts so now we have to tell the script how they can find the variables we need.
	myAnim = GetComponent<Animator> (); // The animator component.
	weapon = FindObjectOfType<Weapon1_Mobile> (); // The weapon 01 script.
	player = FindObjectOfType<PlayerController_Mobile> (); // The player controller script.

	}
	void Update () {

	// Every time we press the fire key/button activates the hot dog animation movement.	
	if(Input.GetKey (KeyCode.F) && weapon.gotWeapon1 && weapon.wp1Selected ||Input.GetAxisRaw ("Right_Trigger") != 0 && weapon.gotWeapon1 && weapon.wp1Selected) {
		
	myAnim.SetTrigger ("HotDogShoot"); // Set the animation.
		
	}
	//  If the character is grounded and  has the weapon in his hands, the idle bool will set to true.
	if (player.isGrounded && weapon.gotWeapon1 && weapon.wp1Selected) {
		hotDogIdle = true;
	} else {
		hotDogIdle = false; // the animation stops if the weapon is not selected.
	}
	//  If the character is standing but has the weapon in his hands, the idle animation will be activated.
	if (hotDogIdle == true) {
	 myAnim.SetTrigger ("DogIdle");
		}
	}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////

