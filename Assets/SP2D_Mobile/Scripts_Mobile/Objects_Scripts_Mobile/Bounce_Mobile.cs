using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	// In this script we can control the mushroom bounce and their animation.

	public class Bounce_Mobile : MonoBehaviour {

	private PlayerController_Mobile player;
	[Range(0.0f, 50.0f)] // Slide Bar.
	public float jumpHeight = 30f; // The amount of bounce.
	public AudioClip bounceSfx; // the bounce sound effect audio clip.
	[Range(0.0f, 5.0f)] // Slide Bar.
	public float bounceSfxVolume = 1f; // the bounce sound effect volume amount.
	private Animator myAnim; // The animator component used for create the mushroom move effect.
		public bool boingBuzz = false; // The gamepad vibration generated when the player touches the mushroom.


	// Use this for initialization
	void Awake () {

		player = FindObjectOfType<PlayerController_Mobile> ();
		myAnim = GetComponent<Animator> ();

	}
		// When the mushroom contacts with an object tagged with the name "player" the mushroom functions are activated.
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.transform.tag == "Player")
		{
		player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (player.GetComponent<Rigidbody2D> ().velocity.x, jumpHeight); // The formula used to generate the mushroom jump is the same as we used to get the jump and double jump of our character.
		AudioSource.PlayClipAtPoint (bounceSfx, Camera.main.transform.position, bounceSfxVolume); // We instantiate a sound every time the player touches the top of the mushroom.
		myAnim.SetTrigger ("Bounce"); // Sets the mushroom's bounce animation.
		StartCoroutine(BoingVibration()); // Starts the gamepad vibration coroutine.

		}
}
	public IEnumerator BoingVibration()
	{
		//We sent a message to the vibration manager script to indicate that the gamepad should vibrate and stops after 0.2 seconds.
		boingBuzz = true; 
		yield return new WaitForSeconds(0.2f);
		boingBuzz = false;
		
	}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D By Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////
