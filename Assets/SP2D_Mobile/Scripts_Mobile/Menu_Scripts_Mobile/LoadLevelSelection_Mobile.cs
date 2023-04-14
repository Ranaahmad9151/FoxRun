using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Security.Policy;

namespace Bitboys.SuperPlaftormer2D {

	public class LoadLevelSelection_Mobile : MonoBehaviour 
	{
		public static int LevelNumber;
		public int LevelNum;
		public string sceneToLoad; // the name of the scene that will charge after the loading scene.
		[Range(0, 5)]    // Slide bar.
		public int changeSceneDelay = 1;// the delay until the level changes.

		public GameObject buyPopUp;
        private void Start()
        {

			if (!PlayerPrefs.HasKey("PlayerCurrentLives"))
			{
				PlayerPrefs.SetInt("PlayerCurrentLives", 4);
			}
            /*if (PlayerPrefs.GetInt("Lock") < LevelNumber)
			{
				PlayerPrefs.SetInt("Lock", LevelNumber);
			}*/
        }
        public void loadScene(){
			if(PlayerPrefs.GetInt("PlayerCurrentLives")> 0)
			{
				StartCoroutine (WaitForLoad ()); // the time we will wait before to load the scene.

			}
			else
			{
				buyPopUp.SetActive(true);
			}

		}
		public IEnumerator WaitForLoad()
		{
			yield return new WaitForSeconds(changeSceneDelay);
			SceneManager.LoadSceneAsync (sceneToLoad); // From here we load the scene that we have previously indicated in the editor.
			LevelNumber = LevelNum;
			Debug.Log (LevelNum);
		}
        public void PlayerLives()
        {
            PlayerPrefs.SetInt("PlayerCurrentLives", 4);
			loadScene();
        }
    }
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////
