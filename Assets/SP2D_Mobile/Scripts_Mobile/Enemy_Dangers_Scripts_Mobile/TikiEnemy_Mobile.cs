using UnityEngine;
using System.Collections;
using DG.Tweening;
namespace Bitboys.SuperPlaftormer2D {

	public class TikiEnemy_Mobile : MonoBehaviour {

		[Range(0.0f, 1.0f)] // Slide Bar.
		public float maxScale = 1.0f; // the weapon maximun scale size.
		[Range(0.0f, 1.0f)] // Slide Bar.
		public float minScale = 0f; // the weapon minumim scale size.
		[Range(0.0f, 20.0f)] // Slide Bar.
		public float scaleSpeed = 20f;// the speed as the sprite is scaled.
		private Vector3 targetScale; // the target to scale.
		private Animator anim;
		public GameObject tikiFace;

		public float playerRange = 10.0f;//The range between the player and the enemy.
		public LayerMask playerLayer;// We use this layer mask to tell the enemy who is the player.
		public bool playerInRange;// sets if the player is the "attack" area.

		[Range(0.0f, 20.0f)] // Enemy speed Slide Bar.
		public float moveSpeed = 10.0f; // the platform move speed.
		public Transform currentPoint; // The transform point from wich the enemy begins to move.
		public Transform[] points; // the multiple transform point by wich the enemy will moves.
		public int pointSelection;// the point where the enemy is in real time.
		void Awake () {

			currentPoint = points[pointSelection];
			anim = this.GetComponent<Animator> ();


		}
        private void Start()
        {
        }

		void Update (){

			// Sets the Enemy scale from 0 to 1 when the player is near.
			this.transform.localScale = Vector3.Lerp (this.transform.localScale, this.targetScale, Time.deltaTime * scaleSpeed);
	

			playerInRange = Physics2D.OverlapCircle (transform.position, playerRange, playerLayer);

			if (playerInRange) {
				Destroy (tikiFace.gameObject); // when its activated the "fake" face is destroyed.
				targetScale.Set (maxScale, maxScale, maxScale);
				anim.enabled = true; // plays the tiki enemy movement animation.

		
					//Enemy movement from left to right following the assigned points.
					this.GetComponent<Rigidbody2D> ().MovePosition (this.transform.position + transform.forward * Time.deltaTime);
					this.transform.position = Vector3.MoveTowards (this.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
					if (this.transform.position == currentPoint.position) {
						pointSelection++;
						if (pointSelection == points.Length) {
							pointSelection = 0;
						}
						currentPoint = points [pointSelection];
					}
					return;
				

			
				}
			}

}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////

