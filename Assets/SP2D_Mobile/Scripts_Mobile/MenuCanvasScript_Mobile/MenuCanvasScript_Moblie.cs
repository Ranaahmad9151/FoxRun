 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Bitboys.SuperPlaftormer2D {
public class MenuCanvasScript_Moblie : MonoBehaviour {

		public string levelToLoad;
	

	public void HomeButtonForLevelComplete()
	{
			StartCoroutine (FindObjectOfType<Door_Mobile> ().GoLevelSelect ());
			Time.timeScale = 1;
	}

	public void ReplayButton()
	{
			if(PlayerPrefs.GetInt("Coins")>10)
			{
				//NumberOfCoins_Mobile.AddPoints(-10);
                PlayerPrefs.SetInt("PlayerCurrentLives", 4); // stores the current lives in the player prefs.
                StartCoroutine (FindObjectOfType<Door_Mobile> ().GoLevel ());
				Time.timeScale = 1;

			}
			else
			{
                StartCoroutine(LevelFail());
                Time.timeScale = 1;
            }
	}

	public void NextLevelButton()
	{
			LoadLevelSelection_Mobile.LevelNumber++;
			StartCoroutine (FindObjectOfType<Door_Mobile> ().GoNextLevel ());
			Time.timeScale = 1;
	}

	public void HomeButtonForLevelFail()
	{
			StartCoroutine (LevelFail());
			Time.timeScale = 1;
	}
	

		public IEnumerator LevelFail()
		{
			float fadeTime = GameObject.Find ("Fader").GetComponent<Fading_Mobile> ().BeginFade (1); // sets the screen fade effect.
			yield return new WaitForSeconds(fadeTime);// the delay until the fade effect stops.
			//SceneManager.LoadScene (levelToLoad); // we load the scene.
			SceneManager.LoadSceneAsync (levelToLoad);
		}
		
}
}