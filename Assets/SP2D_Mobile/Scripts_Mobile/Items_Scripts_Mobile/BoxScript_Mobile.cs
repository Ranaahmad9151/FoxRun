using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	// This script is used for when the character jumps on a box or shoot him, the box will break and some tokens will emerge.
	
	public class BoxScript_Mobile : MonoBehaviour {

	public GameObject coinBox; //the game object that contains the tokens located inside the box.
	public int boxStrength; //  the necessary force generated over the box to can break it.
	public GameObject crateEffects; // the game object that contains the crate particle effects.
	[Range(0, 100f)] // Slide Bar.
	public int pointsOnBreak = 30; // the points we earn by breaking the box.
	public AudioClip crateSfx; // the break sound effect clip.
	[Range(0.0f, 5.0f)] // Slide Bar.
	public float crateSfxVolume = 1f; // the crate sound effect volume amount.


		// Update is called once per frame
		void Update () {
			if (boxStrength <= 0) { // If the character jumps on the crate his "boxStrength"amount is reduced. Therefore if the box strenght is zero or less than zero some processes will be initiated.
				Instantiate(crateEffects, transform.position, transform.rotation);// Instantiate the crate particle effects on the same position as the crate.
				Instantiate(coinBox, transform.position, transform.rotation);// Instantiate the token container on the same position as the crate.
				AudioSource.PlayClipAtPoint (crateSfx, Camera.main.transform.position, crateSfxVolume);// Set the sound we chosen to use when the box was broken and we use our main camera position to instantiate it,  finally indicates the volume amount for the sound.
				ScoreManager_Mobile.AddPoints(pointsOnBreak); // add points to the score counter.
				Destroy (gameObject);// Finally we destroy de crate object to make it dissapear.
			}
		} 
		public void giveForce (int forceToGive)
		{
			boxStrength -= forceToGive; // The box strength is less than or equal to the force needed to can break it.

		}
	
	void OnTriggerEnter2D (Collider2D other)
	{
			// If the box collides with an object tagged with the name "fireball" some processes will be initiated.
		if (other.tag == "Fireball") {
				AudioSource.PlayClipAtPoint (crateSfx, Camera.main.transform.position, crateSfxVolume); // Set the sound we chosen to use when the box was broken and we use our main camera position to instantiate it,  finally indicates the volume amount for the sound.
				ScoreManager_Mobile.AddPoints(pointsOnBreak); // add points to the score.
				Instantiate(coinBox, transform.position, transform.rotation); // Instantiate the token container on the same position as the crate.
				Instantiate(crateEffects, transform.position, transform.rotation);// Instantiates the crate particle effects on the same position as the crate.
			    Destroy (gameObject); // Finally we destroy de crate object to make it dissapear.

		}
	}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D By Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////
	

