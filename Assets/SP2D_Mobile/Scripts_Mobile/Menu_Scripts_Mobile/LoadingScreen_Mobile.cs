using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Bitboys.SuperPlaftormer2D {

	//  We use this script to wait a few seconds until the level is loaded and also to launch the screen fade effect.

	public class LoadingScreen_Mobile : MonoBehaviour {
		
		public string sceneToLoad; // the name of the scene that will charge after the loading scene.
		[Range(0, 5)]    // Slide bar.
		public int changeSceneDelay = 1;// the delay until the level changes.

void Awake(){
	
	StartCoroutine (WaitForLoad ()); // the time we will wait before to load the scene.

}
public IEnumerator WaitForLoad()
{
			yield return new WaitForSeconds(changeSceneDelay);
			SceneManager.LoadSceneAsync (sceneToLoad);
			//float fadeTime = GameObject.Find ("Fader").GetComponent<Fading> ().BeginFade (changeSceneDelay); // the delay until the level changes.


}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////
