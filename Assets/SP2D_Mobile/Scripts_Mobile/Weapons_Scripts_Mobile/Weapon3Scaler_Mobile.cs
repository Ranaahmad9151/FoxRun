using UnityEngine;
using System.Collections;
namespace Bitboys.SuperPlaftormer2D {

	// This script show ups the gun when the weapon item is collected, changing its scale from 0 to 1.

	public class Weapon3Scaler_Mobile : MonoBehaviour {

		[Range(0.0f, 1.0f)] // Slide Bar.
		public float maxScale = 1.0f; // the weapon maximun scale size.
		[Range(0.0f, 1.0f)] // Slide Bar.
		public float minScale = 0f; // the weapon minumim scale size.
		[Range(0.0f, 30.0f)] // Slide Bar.
		public float scaleSpeed = 30f;// the speed as the sprite is scaled.
		private Vector3 targetScale; // the target to scale.
		private Weapon3_Mobile weapon3; // the reference to the weapon script.
		private PlayerController_Mobile player; // the reference to the player control script.


		void Start () {

			weapon3 = FindObjectOfType<Weapon3_Mobile> ();	
			player = FindObjectOfType<PlayerController_Mobile> ();

		}

		// Update is called once per frame
		void Update () {

			// Here we change the scale of the weapon using the local scale and creating a smooth effect multiplying it by the scale speed.
			this.transform.localScale = Vector3.Lerp (transform.localScale, targetScale, Time.time * scaleSpeed);
			// if we pick up the weapon iteam and we are not in a wall the scale of the weapon object will change to the maximum scale.
			if (weapon3.gotWeapon3 && weapon3.wp3Selected && !player.touchingLeftWall && !player.touchingRightWall) {
				targetScale.Set (maxScale, maxScale, maxScale);
			}
			// If don't have this weapon or if we touch a wall the gun scale will change to its minimum size.
			if (!weapon3.gotWeapon3 || !weapon3.wp3Selected || player.touchingLeftWall || player.touchingRightWall) {

				targetScale.Set (minScale, minScale, minScale);
			}
		}
	}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////

