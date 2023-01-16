using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// We use this script to assign it to a button with which we may close our game.
namespace Bitboys.SuperPlaftormer2D {
	
	public class QuitButton_Mobile : MonoBehaviour {

	public void QuitGame(){

			#if UNITY_EDITOR // If we are using the unity editor, press the button Stop playback of the scene.

			UnityEditor.EditorApplication.isPlaying = false;

			#else // If we are using the game buil the game will closes when you press the quit button.

		GameObject.Find ("Fader").GetComponent<Fading_Mobile> ().BeginFade (1); // the delay until the level changes.
			Application.Quit();
			#endif

	}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////
