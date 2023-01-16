using UnityEngine;
using System.Collections;
using System;


namespace Bitboys.SuperPlaftormer2D {
//This script controls the alpha channel of the sprites when the camera plays with the Zoom Out effect.

[ExecuteInEditMode]

	public class ZoomFadingObject_Mobile : MonoBehaviour
{
	private SpriteRenderer sprite; // With this we access to the object's sprite renderer.
	private PauseMenu_Mobile paused;// We call the Pause Menu Script.
	private DollyZoom_Mobile dolly; // We call the Dolly Zoom function Script.



	void Awake(){
		
		paused = FindObjectOfType<PauseMenu_Mobile> (); // We tell the script that the "paused" variable refers to the Pause Menu Script.
		sprite = GetComponent<SpriteRenderer> ();// Access to the Sprite Renderer component based on the "sprite" variable that we have called previously.
		dolly = FindObjectOfType<DollyZoom_Mobile> ();// We tell the script that the "dolly" variable refers to the DollyZoom Script.


		if(sprite == null) // This will alert is if our object does not have a sprite renderer component.
		{
			Debug.LogError("There is no Sprite Render attached to the object!!");
		}

	}

    void Update()
    {
			try{
		// This determines that if the Dolly Zoom effect is not active and we use the Zoom function and the Game is not paused, the object's sprite will reduce its alpha channel to be transparent.
		if (dolly.dollyZoom == false && Input.GetKeyDown (KeyCode.Z)&& paused.isPaused == false || dolly.dollyZoom == false && Input.GetButtonDown ("ZoomOut")&& paused.isPaused == false) {

			sprite.color = new Color(1f,1f,1f,0f);
		}

		//This ensures that when the Zoom function is not being used the alpha sprite channel back to its initial color.
		if (dolly.dollyZoom == false && Input.GetKeyUp (KeyCode.Z)&& paused.isPaused == false && Camera.main.orthographicSize == 9f || dolly.dollyZoom == false && Input.GetButtonUp ("ZoomOut")&& paused.isPaused == false){
			sprite.color = new Color(1f,1f,1f,1f);
		}
	}catch(Exception e) 
			{
	}
}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by BITBOYS ///////////////////////////////////////////////////////////////////////////////////////////////