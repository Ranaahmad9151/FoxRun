using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Bitboys.SuperPlaftormer2D {

	// the Life Manager is used to count the amount of lives that we have.
	
	public class LifeManager_Mobile : MonoBehaviour {

	public int lifeCounter ; // the integer number that we will use to determine how much lives we have in every moment.
	private Text theText; // the text component responsible of display the amount of lives that the player has.
	public PlayerController_Mobile player; // the reference to the player controller script.
	public ParticleSystem lifeUpParticle; // the particle system that will be activated in the ui when we pick a live up item.
	public string levelToLoad; 
	

	
	void Awake () {
			
		theText = GetComponent<Text> (); // set the lives counter text component.
		//PlayerPrefs.SetInt ("PlayerCurrentLives", 0); // For Testing Only to Set 0 
		lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives"); // this option will make that the lives that we collect are stored in the project preferences or in the device wich we play.
		player = FindObjectOfType<PlayerController_Mobile> ();

	}
        private void Start()
        {
			ResetLives();
        }
        // When the player dies the "Game Over" screen is activated.
        void Update () {
			
		

			theText.text = "x" + lifeCounter; // the text component displays the amount of lives that the player has

			// This makes reset the game when the player has no lives.
			if (lifeCounter < 0)
			{
				
				GameObject.Find ("MenuCanvas").transform.GetChild (1).gameObject.SetActive (true);
//				player.gameObject.SetActive(false);
//				SceneManager.LoadSceneAsync (levelToLoad);
//				ResetLives ();
			}
	}
		public IEnumerator ShowLevelFailDailogBox()
		{
			yield return new WaitForSeconds (0.5f);
			player.gameObject.SetActive(false);
			//ResetLives ();
			GameObject.Find ("MenuCanvas").transform.GetChild (2).gameObject.SetActive (true);
			GameObject.Find ("HUD").SetActive (false);
			GameObject.Find ("MenuCanvas").transform.GetChild (1).gameObject.SetActive (false);
		}

	public void GiveLife()
	{
		lifeCounter++; // when the player pick up a live item this adds this lives to the ui counter .
		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter); // stores the current lives in the player prefs.
		lifeUpParticle.gameObject.GetComponent<ParticleSystem> ().Play (); // activates the ui particles.

	}
		//this option remains the lives from the counter each time that the character dies.
	public void TakeLife()
	{
		lifeCounter--; 
		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);// stores the current lives in the player prefs.
	}

        public void ResetLives()
        {
            lifeCounter = 10;
            PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter); // stores the current lives in the player prefs.
			print("Life Counters " + lifeCounter);
        }
    }
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////