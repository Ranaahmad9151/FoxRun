using UnityEngine;
using System.Collections;
namespace Bitboys.SuperPlaftormer2D {
	public class FlyingEnemiesGroup_Mobile : MonoBehaviour {

	private PlayerController_Mobile player;
	[Range(0.0f, 20.0f)] // slide bar.
	public float moveSpeed = 6.0f;// Flight speed.
	[Range(0.0f, 20.0f)] // slide bar.
	public float playerRange = 10.0f;//The range between the player and the enemy.
	public LayerMask playerLayer;// We use this layer mask to tell the enemy who is the player.
	public bool playerInRange;// sets if the player is the "attack" area.
	private Animator myAnim; // the enemy wings animator component.

	
	void Awake () {

	myAnim = GetComponent<Animator> ();
	player = FindObjectOfType<PlayerController_Mobile> ();

	}
	
	void Update () {

		if (player.transform.position.x < transform.position.x) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} else if (player.transform.position.x > transform.position.x) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			
		}
		
		playerInRange = Physics2D.OverlapCircle (transform.position, playerRange, playerLayer);
		

			if (playerInRange) {
				transform.position = Vector3.MoveTowards (transform.position, player.transform.position, moveSpeed * Time.deltaTime);
			myAnim.SetTrigger ("Attack");
				
			return;
			}

		}

	private void onDrawGizmos (){
		Gizmos.DrawSphere(transform.position, playerRange);
	}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////