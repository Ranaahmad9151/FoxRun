using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {
	
// This script is used for when the character shoots a breakable stone, the stone will break and a gem will emerge from inside.

	public class RockScript_Mobile : MonoBehaviour {

	public GameObject gemRock;//the game object that contains the gem.
	public int rockStrength;//  the necessary force generated to the box to can break it.
	public GameObject rockEffects; // the game object that contains the stone particle effects.
	[Range(0, 100f)] // Slide Bar.
	public int pointsOnRockBreak = 30; // the points we earn by breaking the box.
	public AudioClip rockSfx;// the break sound effect clip.
	[Range(0.0f, 5.0f)] // Slide Bar.
	public float rockSfxVolume = 1f; // the crate sound effect volume amount.

		// Update is called once per frame
		void Update () {
			if (rockStrength <= 0) { // If the character shoots to the rock his "rocktrength"amount is reduced. Therefore if the rock strenght is zero or less than zero some processes will be initiated.
				Instantiate(rockEffects, transform.position, transform.rotation);// Instantiate the rock particle effects on the same position as the rock.
				Instantiate(gemRock, transform.position, transform.rotation); // Instantiates a gem on the same position as the rock.
				AudioSource.PlayClipAtPoint (rockSfx, Camera.main.transform.position, rockSfxVolume);// Set the sound we chosen to use when the rock was broken and we use our main camera position to instantiate it,  finally indicates the volume amount for the sound.
				ScoreManager_Mobile.AddPoints(pointsOnRockBreak); // add points to the score counter.
				Destroy (gameObject);// Finally we destroy de rock object to make it dissapear.
			}
		} 
		public void giveForce (int forceToGive)
		{
			rockStrength -= forceToGive;// The rock strength is less than or equal to the force needed by the fireball to can break it.

		}
	void OnTriggerEnter2D (Collider2D other)
	{
			// If the box collides with an object tagged with the name "fireball" some processes will be initiated.
		if (other.tag == "Fireball") {
			AudioSource.PlayClipAtPoint (rockSfx, Camera.main.transform.position, rockSfxVolume);// Set the sound we chosen to use when the rock was broken and we use our main camera position to instantiate it,  finally indicates the volume amount for the sound.
			Instantiate(gemRock, transform.position, transform.rotation);// Instantiates a gem on the same position as the rock.
			Instantiate(rockEffects, transform.position, transform.rotation);// Instantiate the rock particle effects on the same position as the rock.
			Destroy (gameObject);// Finally we destroy de rock object to make it dissapear.
		}
	}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D By Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////
