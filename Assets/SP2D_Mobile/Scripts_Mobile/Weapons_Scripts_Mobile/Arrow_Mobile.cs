using UnityEngine;
using System.Collections;


	namespace Bitboys.SuperPlaftormer2D {

		//Here we will control the bullets behaviors and the damage caused to the enemies.

		[RequireComponent(typeof(BoxCollider2D))]
		[RequireComponent(typeof(Rigidbody2D))]

	public class Arrow_Mobile : MonoBehaviour {

		[Range(0.0f, 50.0f)] // Arrow speed slide Bar.
		public float speed = 30f; // the movement speed of the arrow.
		[Range(0.0f, 50.0f)] // slide bar.
		public float rotationSpeed = 0f; // the arrow transform rotation speed.
		[Range(0, 5f)] // slide bar.
		public int damageToGive = 1;// The damage that the enemy will cause to the player when collides with him.
		public AudioClip knockBackSfx; // the audio clip used when the player and the enemy collides.
		[Range(0.0f, 5.0f)] // slide bar.
		public float knockBackSfxVolume = 1f; // the collision sound effect volume amount.
		private Shake_Mobile shakeController; // the variable used for call the camera shake effect.
		public GameObject bloodEffect;

			void Awake () {
			shakeController = FindObjectOfType<Shake_Mobile> ();

			}

			void Update () {

				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D> ().velocity.y);
			GetComponent<Rigidbody2D> ().angularVelocity = rotationSpeed;

			}

		void OnCollisionEnter2D(Collision2D coll)
		{
			if (coll.gameObject.tag == "Player") {
				shakeController.ShakeCamera (0.5f, 0.5f); // This will shake the camera when the player takes damage.
				HealthManager_Mobile.HurtPlayer(damageToGive); // This will substract energy to the player.
				AudioSource.PlayClipAtPoint (knockBackSfx, Camera.main.transform.position, knockBackSfxVolume); // The hit sound effect.
				var player = coll.gameObject.GetComponent<PlayerController_Mobile>();
				player.knockbackCounter = player.knockbackLength;
				if (coll.gameObject.transform.position.x < transform.position.x) // determines whether the player is being hit from the right or not.
					player.knockFromRight = true;
				else
					player.knockFromRight = false;
				if (coll.gameObject.transform.position.y < transform.position.y) // determines whether the player is being hit from above.
					player.knockFromUp = true;
				else
					player.knockFromUp = false;
			
		
	

			

			Instantiate (bloodEffect, transform.position, transform.rotation); //  Instantiate the impact effects when the fireball collides with an enemy and then destroys the object.
			Destroy (gameObject);
		}
		}
	}
}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////

