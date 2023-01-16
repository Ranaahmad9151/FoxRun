using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace Bitboys.SuperPlaftormer2D {
	public class MainMenu_Mobile : MonoBehaviour {

	public string startLevel;
	public string levelSelect;
	public int playerLives;



	public void NewGame()
	{
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives); // Whenever we start a new level we make sure to save the current lives of the player.
		StartCoroutine (GoStartGame ());

	}
	public void LevelSelect()
	{

		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
		StartCoroutine (GoLevelSelect ());

    }

	public void QuitGame()
	{
		StartCoroutine (GoQuitGame ());


	}

		//The main functions used to start the game, select the game level or quit the game. Each function is associated to a button in the main menu.

	public IEnumerator GoStartGame(){

			float fadeTime = GameObject.Find ("Fader").GetComponent<Fading_Mobile> ().BeginFade (1);
		
		yield return new WaitForSeconds(fadeTime);
		
		SceneManager.LoadScene (startLevel);

	}
	public IEnumerator GoLevelSelect(){
		
			float fadeTime = GameObject.Find ("Fader").GetComponent<Fading_Mobile> ().BeginFade (1);
		
		yield return new WaitForSeconds(fadeTime);
		
		SceneManager.LoadScene (levelSelect);

	}
	public IEnumerator GoQuitGame(){
		
			float fadeTime = GameObject.Find ("Fader").GetComponent<Fading_Mobile> ().BeginFade (1);
		
		yield return new WaitForSeconds(fadeTime);
		
		Debug.Log ("Game Exited");
		Application.Quit ();
		
	}

}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////

