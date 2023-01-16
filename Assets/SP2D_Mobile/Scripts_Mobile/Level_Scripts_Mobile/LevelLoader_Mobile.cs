using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Bitboys.SuperPlaftormer2D {

	// We use this script to assign it to an object that we want to use as a gateway for can travel between scenes.
	
	public class LevelLoader_Mobile : MonoBehaviour {

	public bool PlayerInZone; // We use this variable to know if the player is within an area that activates the gateway for travel between scenes.
	public string levelToLoad; // In this space we will indicate the scene name of the level wich we want to travel.
	[Range(0, 5)]    // Slide bar.
	public int changeSceneDelay = 2;// the delay until the level changes.

	// Use this for initialization
	void Awake () {
			
		PlayerInZone = false; // we will ensure that this variable is disabled when the level starts.
	
	}
	void Update () {
		
			// This function will allow us to can enter trough a door by pressing the "up arrow" key, the "w" key on the keyboard or the up cross in the digital stick or the vertical up movement of the joystick.
			if (Input.GetKeyDown (KeyCode.UpArrow) && PlayerInZone || Input.GetKeyDown (KeyCode.W) && PlayerInZone || Input.GetAxis ("360_VerticalDPAD") > 0.1f && PlayerInZone || Input.GetAxis ("Vertical") > 0.5f && PlayerInZone) {
			SceneManager.LoadScene (levelToLoad);
			StartCoroutine (ChangeLevel ());
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
			// if the player is placed over the object that have this script, automatically will be within a door zone.
		if (other.name == "Player") {
			PlayerInZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
			//if the player leaves the door zone the player in zone feature will be deactivated.
		if (other.name == "Player") {
			PlayerInZone = false;
		}
	}
	public IEnumerator ChangeLevel(){

		yield return new WaitForSeconds(changeSceneDelay); // the delay until the level changes.

			float fadeTime = GameObject.Find ("Fader").GetComponent<Fading_Mobile> ().BeginFade (1); // sets the screen fade effect.

			yield return new WaitForSeconds(fadeTime);// the delay until the fade effect stops.

		SceneManager.LoadScene (levelToLoad); // we load the scene.


	
	}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////
