using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	//This script is responsible of counting the gems we collect and add points to the scoreboard every time the character collides with them.
	
	public class GemsPickUp_Mobile : MonoBehaviour {
		
	[Range(0, 500)] // Slide Bar.
	public int pointToAdd = 100;// The points are added to the scoreboard every time we collect a gem.
		public AudioClip gemSfx;// the audio clip of the sound effect.
	[Range(0.0f, 5.0f)] // Slide Bar.
		public float gemSfxVolume = 1f;// the amount of volume for the sound effect.
		public GameObject gemsParticle;// the particles that will be spawned evert time the player picks a Gem.
	[Range(0.0f, 1.0f)] // Slide Bar.
		public int numberOfGems = 1;//the amount of gems that are recorded when we pick them.

	
	void OnTriggerEnter2D (Collider2D other)
	{
			// If the box collides with a gem some processes will be initiated.
			if (other.GetComponent<PlayerController_Mobile> () == null)
			return;
			NumberOfGems_Mobile.AddPoints (numberOfGems +1);// the amount of gems that we have + 1.
			Instantiate(gemsParticle, transform.position, transform.rotation);// Instantiate the gem particle effects on the same position as they appear.
			ScoreManager_Mobile.AddPoints (pointToAdd);// add points to the score.
			AudioSource.PlayClipAtPoint (gemSfx, Camera.main.transform.position, gemSfxVolume);// Set the sound we chosen to use when pick a gem and we use our main camera position to instantiate it,  finally indicates the volume amount for the sound.
			Destroy (gameObject);// Finally we destroy de crate object to make it dissapear.
	}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////