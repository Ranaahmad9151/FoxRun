using UnityEngine;
using System.Collections;

// This script allows you to control an smooth camera zoom effect similar to the dolly zoom, when the player collides with objects tagged with the "DollyZoom" name will approach the camera smoothly to the character.

namespace Bitboys.SuperPlaftormer2D {

	public class DollyZoom_Mobile : MonoBehaviour {

	public bool inDollyZoomZone; // It indicates whether the player is in a zoom zone or not.
	public bool dollyZoom; // activates the zoom effect.
	[Range(0.0f, 20.0f)] // Slide Bar.
	public float dollySmoothSpeed = 5f; // the smooth speed of the effect.
	[Range(0.0f, 20.0f)] // Slide Bar.
	public float dollySpeed = 10f; // the zoom speed.
	public float targetOrtho; // the orthographic position of the camera.
	public float minOrtho; // the min position of the camera.
	public float maxOrtho;// the max position of the camera.
		private ZoomFunction_Mobile zoom; // we use this variable to locate the zoom Out function script.

	void Awake () {

	targetOrtho = Camera.main.orthographicSize; // The "targetOrtho" variable makes reference to the Main Camera Orthographic size.
			zoom = FindObjectOfType<ZoomFunction_Mobile> (); 
	}
	void Update () {
			
            //////ZOOM IN ///////
			//If the player is in an zoom are, automatically activates the zoom in effect..
		if (inDollyZoomZone == true) {
			dollyZoom = true;
			targetOrtho = 5.0f; // The camera Orthographic size changes to 5.
			Camera.main.orthographicSize = Mathf.SmoothStep (Camera.main.orthographicSize, targetOrtho, dollySmoothSpeed * Time.deltaTime); // This formula makes that the camera zoom in movement more smooth.
			targetOrtho = Mathf.MoveTowards (targetOrtho, minOrtho, maxOrtho);
					
		} 
			// When the player lefts a zoom area the camera backs to its normal position.
		if (inDollyZoomZone == false ) {

			targetOrtho = zoom.targetOrtho; // The actual camera Orthographic size backs to the original size.
			Camera.main.orthographicSize = Mathf.MoveTowards (Camera.main.orthographicSize, targetOrtho, dollySpeed * Time.deltaTime);
			targetOrtho = Mathf.MoveTowards (targetOrtho, minOrtho, maxOrtho);
			
		}

			//When the character leaves the zoom area and the  Orthographic size of the camera reaches 9, the zoom in effect is disabled.
		if (inDollyZoomZone == false && Camera.main.orthographicSize == 9.0f) {

			dollyZoom = false;
		}
	}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////