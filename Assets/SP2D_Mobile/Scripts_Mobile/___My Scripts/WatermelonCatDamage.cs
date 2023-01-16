using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bitboys.SuperPlaftormer2D
{
	public class WatermelonCatDamage : MonoBehaviour
	{
			//[Range(0, 5f)] // slide bar.
			public static float damageToGive = 0.5f;// The damage that the enemy will cause to the player when collides with him.
			public AudioClip knockBackSfx; // the audio clip used when the player and the enemy collides.
			[Range(0.0f, 5.0f)] // slide bar.
			public float knockBackSfxVolume = 1f; // the collision sound effect volume amount.
			public static Shake_Mobile shakeController; // the variable used for call the camera shake effect.

            private void Start()
            {
				shakeController = FindObjectOfType<Shake_Mobile>();
			}

            // Update is called once per frame
            void Update()
			{

			}
			void OnCollisionEnter2D(Collision2D coll)
			{
				if (coll.gameObject.tag == "Player")
				{

					shakeController.ShakeCamera(0.5f, 0.5f); // This will shake the camera when the player takes damage.
					HealthManager_Mobile.HurtPlayer(damageToGive); // This will substract energy to the player.

					AudioSource.PlayClipAtPoint(knockBackSfx, Camera.main.transform.position, knockBackSfxVolume); // The hit sound effect.
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
				}
			}
	}
}