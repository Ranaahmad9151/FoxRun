using UnityEngine;
using System.Collections;
namespace Bitboys.SuperPlaftormer2D
{
	public class EnemyPatrol_Mobile : MonoBehaviour
	{
		public static EnemyPatrol_Mobile instance;
		public float moveSpeed;// the enemy  Horizontal movement speed.
		private float moveVelocity;
		public bool moveRight;// will use this variable to tell the enemy that must change its move direction.
		public Transform wallCheck;// This object is placed in front of the enemy and is used to know when its touching a wall.
		[Range(0.0f, 1.0f)]           // Wall Check radius Slide Bar.
		public float wallCheckRadius = 0.1f;// This determines the space between the enemy Collider and the walls.
		public LayerMask whatIsWall;// We use this layer mask to tell the enemy what is a wall and what is not.
		private bool hittinWall;// this determines if the enemy is touching a wall.
		private bool notAtEdge; // this determines if the enemy has reached an edge.
		public Transform edgeCheck;// This object is placed in front of the enemy and is used to know when its reaching an edge.

		private void Awake()
		{
			instance = this;
		}
		private void Start()
		{
		}
		// Update is called once per frame
		void Update()
		{

			hittinWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

			notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

			if (hittinWall || !notAtEdge)
				moveRight = !moveRight;

			if (moveRight)
			{
				transform.localScale = new Vector3(-1f, 1f, 1f); // when the enemy touches a wall or reach an edge we change its move direction.

				GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
				//EnemiesTarget.isMoveRight = true;
			}
			else
			{
				transform.localScale = new Vector3(1f, 1f, 1f);
				GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
				//EnemiesTarget.isMoveRight = false;
			}
		}
	}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////
