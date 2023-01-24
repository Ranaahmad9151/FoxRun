using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	//This script is assigned to a child object located on the player prefab. The object contains a Collider 2D that is detected by the crate Collider and thanks to that we can create box breaking effect.

	[RequireComponent(typeof(BoxCollider2D))]

	public class BoxStomper_Mobile : MonoBehaviour {

        private void Start()
        {
            
        }
        [Range(0, 5)] // Slide Bar.
	public int forceToGive = 1; // the force applied to the crate object.
	[Range(0.0f, 25.0f)] // Slide Bar.
	public float bounceOnBox = 18.00f;// the amount of bounce that we get when the character jump on the crate.

	void OnTriggerEnter2D(Collider2D other)
	{
			// If the box stomper object collides with an object tagged with the name "boxes" some processes will be initiated.
		if (other.tag == "Boxes") {
				other.GetComponent<BoxScript_Mobile> ().giveForce (forceToGive); // access crate script to indicate that the force needed to break it is the same force as that we are putting on it.
			transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.parent.GetComponent<Rigidbody2D>().velocity.x, bounceOnBox); // sets the horizontal force that we provide using the player's Rigidbody component.
		}
	}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D By Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////
