using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace Bitboys.SuperPlaftormer2D {

	// This script handles the zoom out function that can be used to see the scene with more detail.

	public class ZoomFunction_Mobile : MonoBehaviour {

	[Range(0.0f, 5.0f)]  // Slide Bar.   
	public float zoomSpeed = 1; // The zoom out effect speed.
	public float targetOrtho; // The Orthographic size of the camera in real time.
	[Range(0.0f, 30.0f)]  // Slide Bar.      
	public float smoothSpeed = 30f; // the zoom effect move speed.
	[Range(0.0f, 5.0f)]  // Slide Bar.  
	public float minOrtho = 5.0f; // The minimum Orthographic size that the camera can reach.
	[Range(0.0f, 14.0f)]  // Slide Bar.  
	public float maxOrtho = 14.0f;// The max Orthographic size that the camera can reach.
	[Range(0.0f, 9.0f)]  // Slide Bar.  
    public float originalOrtho = 9.0f; //The original size of the camera before performing the zoom effect.
	public AudioClip zoomInSfx; // The zoom in sound effect.
	[Range(0.0f, 5.0f)]  // Slide Bar.  
	public float zoomInVolume = 1f; // The zoom back sound fx volume.
	public AudioClip zoomOutSfx; // The zoom out sound effect.
	[Range(0.0f, 5.0f)]  // Slide Bar.  
	public float zoomOutVolume = 1f;// The zoom out sound fx volume.
	private PauseMenu_Mobile paused;
	private DollyZoom_Mobile dolly;
	private PlayerController_Mobile player;


	void Awake() {
			
		targetOrtho = Camera.main.orthographicSize;
		paused = FindObjectOfType<PauseMenu_Mobile> ();
		dolly = FindObjectOfType<DollyZoom_Mobile> ();
		player = FindObjectOfType<PlayerController_Mobile> ();
		
	}
	
	void Update () {
			if (player.isInGame) {

				// If the game is not paused, the player is not in a dolly zoom area and we press the zoom out button or the z key, we will handle the zoom out effect.
				if (player.controllerActive == true && dolly.dollyZoom == false && CrossPlatformInputManager.GetButtonDown ("ZoomOut") && paused.isPaused == false || player.controllerActive == true && dolly.dollyZoom == false && Input.GetKeyDown (KeyCode.Z) && paused.isPaused == false) {
					GetComponent<AudioSource> ().PlayOneShot (zoomInSfx, zoomInVolume); // Sets the zoom back sound effect.
					targetOrtho += zoomSpeed * minOrtho;
				} else {
					if (player.controllerActive == true && dolly.dollyZoom == false && CrossPlatformInputManager.GetButtonUp ("ZoomOut") && paused.isPaused == false || player.controllerActive == true && dolly.dollyZoom == false && Input.GetKeyUp (KeyCode.Z) && paused.isPaused == false) {
						GetComponent<AudioSource> ().PlayOneShot (zoomOutSfx, zoomOutVolume); // sets the zoom out sound effect.
						targetOrtho = originalOrtho;
					}

					// With this we make sure that whenever we stop pressing the zoom button, the option will be disabled.
					if (CrossPlatformInputManager.GetButtonUp ("ZoomOut") || Input.GetKeyUp (KeyCode.Z)) {
						targetOrtho = originalOrtho;
					}
				}
			
				if (dolly.dollyZoom == false && dolly.inDollyZoomZone == false) {
					targetOrtho = Mathf.Clamp (targetOrtho, minOrtho, maxOrtho);
					Camera.main.orthographicSize = Mathf.MoveTowards (Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
				}
			}
		}
	}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D By Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////


