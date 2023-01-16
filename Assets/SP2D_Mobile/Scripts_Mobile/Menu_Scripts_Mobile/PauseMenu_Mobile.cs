using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

namespace Bitboys.SuperPlaftormer2D {
	public class PauseMenu_Mobile : MonoBehaviour {
		public static PauseMenu_Mobile instance;
	public  bool isPaused;
	public  bool isPausedMotion;
	public GameObject pauseMenuCanvas;
	private PlayerController_Mobile player;
	private CameraController_Mobile cam;
	private Shake_Mobile ShakeController;
	private Weapon3_Mobile wp3;
	

	void Awake () {

			instance = this;
		player = FindObjectOfType<PlayerController_Mobile> ();
		cam = FindObjectOfType<CameraController_Mobile> ();
		ShakeController = FindObjectOfType<Shake_Mobile> ();	
		wp3 = FindObjectOfType<Weapon3_Mobile> ();
		

	}
			
	// Update is called once per frame
	void Update () {
			

		if (isPaused) {
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
			player.enabled = false;
			ShakeController.ShakeCamera (0f, 0f);



		} else {
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
			player.enabled = true;

		}
			// We can use the escape key or the pause button of the gamepad to pause the game.
		if (Input.GetKeyDown (KeyCode.Escape) || CrossPlatformInputManager.GetButtonDown ("Cancel")) {
			isPaused = !isPaused;
		}
		if (isPausedMotion  && !isPaused) {
			Time.timeScale = 0f;
			player.enabled = false;
			ShakeController.ShakeCamera (0f, 0f);

			
		}
		if(!isPausedMotion && !isPaused && !wp3.slowMo){
			Time.timeScale = 1f;
		player.enabled = true;
		
		}

		if (cam.maxZoom == true) {
			isPausedMotion = true;

		}else{
		
			isPausedMotion = false;
		}

			//WEAPON 03 SLOW MOTION EFFECT
			if (wp3.slowMo && !isPausedMotion && !isPaused) {
				Time.timeScale = 0.1f;

			}



	}

	public void  Resume()
	{
		isPaused = false;
			Time.timeScale = 1;
	}
			


}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY BITBOYS //////////////////////////////////////////////////////////////////////////////////////////////////////
