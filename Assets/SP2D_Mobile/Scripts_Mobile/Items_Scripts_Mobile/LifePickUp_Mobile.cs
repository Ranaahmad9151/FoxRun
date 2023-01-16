using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	//This script is responsible of counting the lives we collect and add points to the scoreboard every time the character collides with them.
	
	public class LifePickUp_Mobile : MonoBehaviour {
		
	[Range(0, 500)] // Slide Bar.
	public int pointToAdd = 100;// The points are added to the scoreboard every time we collect a gem.
	private LifeManager_Mobile lifeSystem; // we acces to the life system script to tell that we have collected a life item.
	public GameObject lifeParticle;// the particles that will be spawned when the player picks a life.
	public AudioClip lifeSfx;// the audio clip of the sound effect.
	[Range(0.0f, 5.0f)] // Slide Bar.
	public float lifeSfxVolume = 1f;// the amount of volume for the sound effect.

	// Use this for initialization
	void Start () {
		lifeSystem = FindObjectOfType<LifeManager_Mobile> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
			//When the player collides with this object some processes will be initiated.
		if (other.name == "Player") {
			Instantiate(lifeParticle, transform.position, transform.rotation);// Instantiate some particle effects.
			lifeSystem.GiveLife(); // we add a life.
			AudioSource.PlayClipAtPoint (lifeSfx, Camera.main.transform.position, lifeSfxVolume);// Set the sound we chosen to use when pick the object and we use our main camera position to instantiate it,  finally indicates the volume amount for the sound.
			Destroy (gameObject);// Finally we destroy de crate object to make it dissapear.
		}
	}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////
