using UnityEngine;
using System.Collections;
namespace Bitboys.SuperPlaftormer2D {

	[RequireComponent(typeof(AudioSource))]

	public class TikiDead_Mobile : MonoBehaviour {

		public bool getup = false;
		public AudioClip scream;

	// Update is called once per frame
	void Update () {
			
			if (getup == true) {
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, 20); // We determine the new position of the player based on the Rigidbody's x velocity and the jump amount.
				StartCoroutine(TikiDie()); // we activate the flash coroutine to make the enemy flash.
				GetComponent<AudioSource>().PlayOneShot(scream);
		}
	}
		IEnumerator TikiDie()	{
			getup = false;
			yield return new WaitForSeconds(2f);
			Destroy (gameObject); // finally destroy this object.

		}
	}
}


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////


