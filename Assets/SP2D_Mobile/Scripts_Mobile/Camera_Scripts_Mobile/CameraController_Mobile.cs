using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace Bitboys.SuperPlaftormer2D {

	// This is the Main Camera controller, it allows you to follow the character when walks, runs....

public class CameraController_Mobile : MonoBehaviour {

	public bool bounds; // This option allows us to choose whether we want the camera to stops following the character when it reaches a certain position.
	public Vector3 minCamPos; //This variable is used to tell to the camera transform the min X,Y and Z limits whenever we use the "bounds" option.
	public Vector3 maxCamPos;//This variable is used to tell to the camera transform the max X,Y and Z limits whenever we use the "bounds" option.
	public GameObject player; // The player prefab.
	public bool isFollowing; // Set if the camera is following the character or not.
	public float XOffset; // The margin with which we want the camera follows the character in its horizontal position.
	public float YOffset; //The margin with which we want the camera follows the character in its vertical position.
	private Vector2 velocity; 
	public float smoothTimeY; //Sets the vertical smooth movement of the camera.
	public float smoothTimeX;//Sets the horizontal smooth movement of the camera.
	public bool maxZoom; // Sets if the camera has reached the maximum Orthographic size.

	void Start () {
		// Sets if the camera is following the player.If not selected the camera will remain static even though the character move around the scene.
		isFollowing = true;
	}

	void Update(){

			// if the is following option is activated.
		if (isFollowing) {
			float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x + XOffset, ref velocity.x, smoothTimeX);
			float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y + YOffset, ref velocity.y, smoothTimeY);
			transform.position = new Vector3 (posX, posY, transform.position.z);
			//transform.position = new Vector3 (posX, transform.position.y, transform.position.z);

		}
			// Set the camera bounds.
		if (bounds) {
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minCamPos.x, maxCamPos.x),
			                                  Mathf.Clamp (transform.position.y, minCamPos.y, maxCamPos.y),
			                                  Mathf.Clamp (transform.position.z, minCamPos.z, maxCamPos.z));
	
		}
			//  If we press the z key or the "zoom out" button on the gamepad and we are not in an dolly zoom area, the zoom out function will be activated.
			if (Camera.main.orthographicSize == 14.0f && Input.GetKey (KeyCode.Z) || Camera.main.orthographicSize == 14.0f & CrossPlatformInputManager.GetButton ("ZoomOut")) {
			maxZoom = true;
		}else{
		   maxZoom = false;
		}

}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D By Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////
