using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

//This script is responsible of counting the health items we collect and add points to the scoreboard every time the character collides with them.

	
	public class HealthPickUp_Mobile : MonoBehaviour {
		
	[Range(0, 500)] // Slide Bar.
	public int pointToAdd = 100;// The points are added to the scoreboard every time we collect a gem.
	public AudioClip healthSfx;// the audio clip of the sound effect.
	[Range(0.0f, 5.0f)] // Slide Bar.
	public float healthSfxVolume = 1f;// the amount of volume for the sound effect.
	[Range(0.0f, 5.0f)] // Slide Bar.
	public int healthToAdd = 1; // the amount of health that the player will get when collides with this object.

	void OnTriggerEnter2D (Collider2D other)
	{
		// when the character collides with this object we access to the health manager script to indicate the amount of health that we will add to the health counter.
			if (other.GetComponent<PlayerController_Mobile> () == null)
			return;
			HealthManager_Mobile.AddHealth (healthToAdd); // // we add the desired health to the counter.
		AudioSource.PlayClipAtPoint (healthSfx, Camera.main.transform.position, healthSfxVolume);// Set the sound we chosen to use when pick the object and we use our main camera position to instantiate it,  finally indicates the volume amount for the sound.
		Destroy (gameObject);// Finally we destroy de crate object to make it dissapear.
	}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////