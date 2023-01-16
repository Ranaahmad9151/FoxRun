using UnityEngine;
using System.Collections;
namespace Bitboys.SuperPlaftormer2D {
	public class FlyingEnemyMove_Mobile : MonoBehaviour {


	private PlayerController_Mobile player; 
	[Range(0.0f, 20.0f)] // slide bar.
	public float moveSpeed = 6f; // Flight speed.
	[Range(0.0f, 20.0f)] // slide bar.
	public float playerRange = 10f; //The range between the player and the enemy.
	public LayerMask playerLayer; // We use this layer mask to tell the enemy who is the player.
	public bool playerInRange; // sets if the player is the "attack" area.
	public bool facingAway; // sets if the player is facing away the enemy.
	public bool followOnLookAway; // sets if the enemy have to follow the player when its looking away.
	private Animator myAnim; // the enemy wings animator component.


	void Awake () {
	
		myAnim = GetComponent<Animator> ();
		player = FindObjectOfType<PlayerController_Mobile> ();

	}
		void Update () {

			// If the player is in the enemy's attack area.
		playerInRange = Physics2D.OverlapCircle (transform.position, playerRange, playerLayer);

		if (!followOnLookAway) {
			if (playerInRange) {
				transform.position = Vector3.MoveTowards (transform.position, player.transform.position, moveSpeed * Time.deltaTime);

				return;
			}
		}
		if ((player.transform.position.x < transform.position.x && player.transform.localScale.x < 0) || (player.transform.position.x > transform.position.x && player.transform.localScale.x > 0)) {
			facingAway = true;

		} else {
			facingAway = false;

		}
		if (playerInRange && facingAway) {
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, moveSpeed * Time.deltaTime);
			myAnim.SetTrigger ("Attack");
		}
		if (player.transform.position.x < transform.position.x) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} else if (player.transform.position.x > transform.position.x) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);

		}
	}
	private void onDrawGizmos (){
		Gizmos.DrawSphere(transform.position, playerRange);
	}
	
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////