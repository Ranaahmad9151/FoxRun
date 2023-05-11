using UnityEngine;
using System.Collections;
namespace Bitboys.SuperPlaftormer2D {

	[RequireComponent (typeof (Rigidbody2D))]
	public class Fish_Mobile : MonoBehaviour {

	[Range(0.0f, 50.0f)]  // Move Speed Slide Bar.
	public float moveSpeed;// the fish  Horizontal movement speed.
	private float moveVelocity;
	public bool moveRight;// will use this variable to tell the fish that must change its move direction.
	public Transform wallCheck;// This object is placed in front of the enemy and is used to know when its touching a wall.
	[Range(0.0f, 1.0f)]           // Wall Check radius Slide Bar.
	public float wallCheckRadius = 0.1f;// This determines the space between the fish wall check transform and the walls.
	public LayerMask whatIsWall;// We use this layer mask to tell the fish what is a wall and what is not.
	private bool hittinWall;// this determines if the fish is touching a wall.


        public void Start()
        {
			print("Start Pos: " + this.transform.position);
        }

		public void Update()
        {
			print("Update Pos: " + this.transform.position);
        }

        void FixedUpdate () {

		hittinWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);



		if (hittinWall)
			moveRight = !moveRight;

		if (moveRight) {
			transform.localScale = new Vector3 (-1f, 1f, 1f); // when the fish touches a wall we change its move direction.

				GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			transform.localScale = new Vector3 (1f, 1f, 1f);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);

		}
	}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////
