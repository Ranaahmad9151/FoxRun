using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	//This script is responsible of counting the number of tokens we collect and add points to the scoreboard every time the character collides with them.
	
	public class CoinPickup_Mobile : MonoBehaviour {
		
	[Range(0, 500)] // Slide Bar.
	public int pointToAdd= 50; // The points are added to the scoreboard every time we collect a token.
	public AudioClip coinSfx; // the audio clip of the sound effect.
	[Range(0.0f, 5.0f)] // Slide Bar.
	public float coinSfxVolume = 1f; // the amount of volume for the sound effect.
	public GameObject starsParticle; // the particles that will be spawned evert time the player picks a token.
	[Range(0.0f, 1.0f)] // Slide Bar.
	public int numberOfCoins = 1; // the amount of tokens that are recorded when we pick them.

	void OnTriggerEnter2D (Collider2D other)
	{
			// If the box collides with a token some processes will be initiated.
			if (other.GetComponent<PlayerController_Mobile> () == null)
		return;
		NumberOfCoins_Mobile.AddPoints (numberOfCoins + 1);// the amount of tokens that we have + 1.
		Instantiate(starsParticle, transform.position, transform.rotation);// Instantiate the coin particle effects on the same position as the token.
		ScoreManager_Mobile.AddPoints (pointToAdd);// add points to the score.
		AudioSource.PlayClipAtPoint (coinSfx, Camera.main.transform.position, coinSfxVolume);// Set the sound we chosen to use when pick a token and we use our main camera position to instantiate it,  finally indicates the volume amount for the sound.
		Destroy (gameObject);// Finally we destroy de crate object to make it dissapear.
	}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////
