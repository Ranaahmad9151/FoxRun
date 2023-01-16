using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Bitboys.SuperPlaftormer2D {

	public class LoadLevelSelection_Mobile : MonoBehaviour {
		public static int LevelNumber;
		public int LevelNum;
		public string sceneToLoad; // the name of the scene that will charge after the loading scene.
		[Range(0, 5)]    // Slide bar.
		public int changeSceneDelay = 1;// the delay until the level changes.
	
		public void loadScene(){

			StartCoroutine (WaitForLoad ()); // the time we will wait before to load the scene.

		}
		public IEnumerator WaitForLoad()
		{
			yield return new WaitForSeconds(changeSceneDelay);
			SceneManager.LoadSceneAsync (sceneToLoad); // From here we load the scene that we have previously indicated in the editor.
			LevelNumber = LevelNum;
			Debug.Log (LevelNum);
		}
	}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////
