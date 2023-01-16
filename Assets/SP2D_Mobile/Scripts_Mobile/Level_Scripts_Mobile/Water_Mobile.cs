using UnityEngine;
using System.Collections;


namespace Bitboys.SuperPlaftormer2D {

	public class Water_Mobile : MonoBehaviour {

	public AudioClip waterInSfx; // The enter water sound effect audio clip.
	[Range(0.0f, 5.0f)]  //enter water sound fx volume Slide Bar.
	public float waterInSfxVolume = 1f; // the enter water sound effect volume amount.
	public AudioClip waterOutSfx; // The exit water sound effect audio clip.
	[Range(0.0f, 5.0f)]  //exit water sound fx volume Slide Bar.
	public float waterOutSfxVolume = 1f; // the exit water sound effect volume amount.
	private PlayerController_Mobile player; // Here we call the script that controls the player.
	public GameObject waterParticles;// Here we name the water Particle system component.



	void Start () {
			
		player = FindObjectOfType<PlayerController_Mobile>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}


		void OnTriggerEnter2D(Collider2D other)
		{
			//Grounded collision, particles and sound effects.
			// If the player touches the ground and is not walking and is not goin up but is ending fall.
			if (other.transform.tag == ("Player") && player.falling) {
				
				GetComponent<AudioSource> ().PlayOneShot (waterInSfx, waterInSfxVolume);
			

			}
			if (other.transform.tag == ("Player") && !player.falling) {

				GetComponent<AudioSource> ().PlayOneShot (waterOutSfx, waterOutSfxVolume);

	

			}
		}




}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////
