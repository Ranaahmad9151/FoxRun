using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	// We will use this feature to create an explosion effect when the character collides with this object.
	
	public class MineExplosive_Mobile : MonoBehaviour {

	[Range(0.0f, 5.0f)]  
	public float secondsToDestroy; // Set the seconds delay before to destroy the object.
	public GameObject explosionEffect; // The particle effects.
	public AudioClip explosionSfx; // The sound effect.
	[Range(0.0f, 5.0f)]  
	public float explosionSfxVolume = 1f; // The sound effect Volume.

	void OnCollisionEnter2D(Collision2D other)
	{
			// if the player collides with the object...
			if (other.transform.tag == "Player" || other.transform.tag == "Rocks") {
				this.GetComponent<BoxCollider2D>().isTrigger = enabled;

			Instantiate(explosionEffect, transform.position, transform.rotation);
			GetComponent<AudioSource>().PlayOneShot(explosionSfx, explosionSfxVolume);
			GetComponent<Renderer> ().enabled = false;


			Destroy (gameObject,secondsToDestroy);		
		}
	}


}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////