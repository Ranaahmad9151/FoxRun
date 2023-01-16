using UnityEngine;
using System.Collections;
namespace Bitboys.SuperPlaftormer2D {

	// The traveling character is the "fake" character that is instantiated when the player collides with the vortex door.


	public class TravellingCharacter_Mobile : MonoBehaviour {
		

	public float fadeTime = 1.0f;
	private float startTime;
	private SpriteRenderer sprite;
	private GameObject travelPoint;

	void Start() {
			
		startTime = Time.time;
			sprite = this.GetComponent<SpriteRenderer> ();
			travelPoint = GameObject.FindGameObjectWithTag ("TravelPoint");
	}

	void Update() {
			
			float t = (Time.time - startTime) / fadeTime;
		sprite.color = new Color(1f,1f,1f,Mathf.SmoothStep(1f, 0f, t));    

			// automatically moves to the vortex center (travel point position)
			this.transform.position = Vector3.MoveTowards (this.transform.position,travelPoint.transform.position, 15f* Time.deltaTime);

			if (this.transform.position.x > 0.01f ) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
			}
			if (this.transform.position.x < 0.01f ) {
				transform.localScale = new Vector3 (-1f, 1f, 1f); 
			}

		
	}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////
