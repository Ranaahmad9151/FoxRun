using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	// This script allows what happens when we pick a weapon item.

	public class Weapon1Item_Mobile : MonoBehaviour {

	public AudioClip reloadSfx; // the audio effect that sounds when we pick up a weapon item.
	[Range(0.0f, 5.0f)] // Slide Bar.
	public float reloadSfxVolume = 1f; // the pick up weapon audio effect volume.
	private Weapon1_Mobile weapon;//The reference to the weapon 01 script.
	private Weapon2_Mobile weapon2;//The reference to the weapon 02 script.
	private Weapon3_Mobile weapon3;//The reference to the weapon 03 script.
	private Weapon4_Mobile weapon4;//The reference to the weapon 04 script.
	
	void Awake () {
		//Previously we have created some reference variables for the weapons scripts so now we have to tell the script how they can find the variables we need.
		weapon = FindObjectOfType<Weapon1_Mobile> ();
		weapon2 = FindObjectOfType<Weapon2_Mobile> ();	
		weapon3 = FindObjectOfType<Weapon3_Mobile> ();	
		weapon4 = FindObjectOfType<Weapon4_Mobile> ();	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		// When the player collides with the item activates some options.
			if (other.GetComponent<PlayerController_Mobile> () == null)
			return;
		weapon.gotWeapon1 = true; // we got this weapon activated and ready to be used.
		weapon.wp1Selected = true;// this will make that when we pick up the item automatically we will have the weapon one selected.
		weapon.weapon1AmmoAmount = 100; // This is the amount of ammo that the weapon will have when the item is picked up.
		AudioSource.PlayClipAtPoint (reloadSfx, Camera.main.transform.position, reloadSfxVolume); // the audio effect that sounds when we pick up a weapon item.
	// if we pick this item, automatically al the other weapons will be deselected.
		weapon2.wp2Selected = false;
		weapon3.wp3Selected = false;
		weapon4.wp4Selected = false;

			//When collide with the item object automatically we destroy it, making it disappear from the scene.
		StartCoroutine (WaitToDestroy ());// we start the destroy coroutine.
		
	}
	public IEnumerator WaitToDestroy()
	{
		yield return new WaitForSeconds(0.1f); // We delay the "destroy" function a little to give us time to get the item and activates the weapon.
		Destroy (gameObject);// destroy the object.
	}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////
