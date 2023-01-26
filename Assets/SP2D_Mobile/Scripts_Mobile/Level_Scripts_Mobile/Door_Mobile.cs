using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Bitboys.SuperPlaftormer2D {


	public class Door_Mobile : MonoBehaviour {

		private PlayerController_Mobile player; // Here we call the script that controls the player.
		public bool playerInZone; // We use this variable to know if the player is within an area that activates the gateway for travel between scenes.
		public string levelToLoad; // In this space we will indicate the scene name of the level wich we want to travel.
		public string NextlevelToLoad;
		[Range(0, 5)]    // Slide bar.
		public int changeSceneDelay = 2;// the delay until the level changes.
		public bool isInGame;
		public GameObject vortexSound;
		public GameObject travelCharacter;
		public int prefabCount = 0;
		public int prefabLimit = 1;
		public bool spawnTraveller = false;
		public GameObject QuestionModule;
		public AudioSource levelCompleteMusic;
	//Vortex variables

	[Range(0.0f, 500f)]
	public float rotationSpeed = 200; // The rotation speed of the vortex sprite.
	[Range(0.0f, 1.0f)]
	public float maxScale = 0.3767523f; // The max size of the vortex.
	[Range(0.0f, 1.0f)]
	public float minScale = 0f; // The min size of the vortex.
	[Range(0.0f, 5.0f)]
	public float scaleSpeed = 1.5f; // The speed witch the vortex opens.
	private Vector3 targetScale; // the scale of the vortex.
	public bool openDoor;
	public bool closeDoor; // the bool that closes the vortex.
	public GameObject vortexCloseEffect; // the effect prefab that appears when the vortex closes.
	public GameObject redGem;
	public GameObject yellowGem;
	public GameObject blueGem;
	public GameObject lilaGem;
	public GameObject greenGem;




	void Awake () {
			
			player = FindObjectOfType<PlayerController_Mobile> ();
			playerInZone = false; // we will ensure that this variable is disabled when the level starts.

	}
	
	
	// Update is called once per frame
	void Update () {

			this.transform.localScale = Vector3.Lerp (transform.localScale, targetScale, Time.deltaTime * scaleSpeed); // We use Vector3.Lerp to smooth change the scale of the vortex object.

			if (player.allGemsCollected == true) {
				openDoor = true;
				StartCoroutine ("OpenDoor"); // We call the open vortex Coroutine.
				//SoundManager.Instance.PlayGamePlaySound();
			} 


			if (player.allGemsCollected == true && isInGame == true && playerInZone == true) {
				StartCoroutine (GoLevelLevelCompleteScreen ());

			}

			if (isInGame == false && playerInZone == true) {
				StartCoroutine (GoLevel ());
				openDoor = true;
			}

			if (openDoor == true) {
				vortexSound.gameObject.SetActive (true);// The glitched character will be deactivated wile the open vortex option is false.

			} else {
				vortexSound.gameObject.SetActive(false);// The glitched character will be deactivated wile the open vortex option is false.

			}


			//Door Gems Sprites
			if (player.redDiamond == true) { // RED GEM
			redGem.gameObject.SetActive (true); 
			} else {
			redGem.gameObject.SetActive (false); 
			}

			if (player.yellowDiamond == true) { // YELLOW GEM
				yellowGem.gameObject.SetActive (true); 
			} else {
				yellowGem.gameObject.SetActive (false); 
			}

			if (player.blueDiamond == true) { // BLUE GEM
				blueGem.gameObject.SetActive (true); 
			} else {
				blueGem.gameObject.SetActive (false); 
			}

			if (player.lilaDiamond == true) { // LILA GEM
				lilaGem.gameObject.SetActive (true); 
			} else {
				lilaGem.gameObject.SetActive (false); 
			}

			if (player.greenDiamond == true) { // GREEN GEM
				greenGem.gameObject.SetActive (true); 
			} else {
				greenGem.gameObject.SetActive (false); 
			}
				
			}

		// The iEnumerator that open the vortex.
		public IEnumerator OpenDoor()
		{
			yield return new WaitForSeconds (0.1f);// the time between a task and expect another.
			targetScale.Set (maxScale, maxScale, maxScale); // this sets the vortex to their max scale.
			transform.Rotate (0, 0, rotationSpeed * -Time.deltaTime);

		}
		// The iEnumerator that closes the vortex.
		public IEnumerator CloseDoor(){
		    targetScale.Set (minScale, minScale, minScale);
			yield return new WaitForSeconds (0.5f);// the time between a task and expect another.
			this.transform.localScale = new Vector3(0, 0, 0); // set the vortex scale to the minimum size.
			GameObject go = vortexCloseEffect;
			go.SetActive (true); // Deactivate the vortex game object.
			yield return new WaitForSeconds (0.5f);// the time between a task and expect another.
			GameObject vort = vortexCloseEffect;
			vort.SetActive (true); // disable the vortex close effect when the vortex is closed.
			yield return new WaitForSeconds (2);// the time between a task and expect another.
			closeDoor = false; // finally we ends  changing  the close the vortex bool to fake.
			openDoor = false;
		}
		public IEnumerator GoLevel(){

			yield return new WaitForSeconds(changeSceneDelay); // the delay until the level changes.

			float fadeTime = GameObject.Find ("Fader").GetComponent<Fading_Mobile> ().BeginFade (1); // sets the screen fade effect.

			yield return new WaitForSeconds(fadeTime);// the delay until the fade effect stops.

			SceneManager.LoadScene (SceneManager.GetActiveScene().name); // we load the scene.



		}

		public IEnumerator GoLevelSelect ()
		{
			spawnTraveller = true;
			yield return new WaitForSeconds(0.001f); // the delay until the level changes.
			player.gameObject.SetActive(false); // set the entire player object to false.
			player.controllerActive = false; // if the vortex intro is active you can not control the character until the vortex closes.
			player.enabled = false; // turn of the player to avoid after death.

			yield return new WaitForSeconds(1f); // the delay until the level changes.

			StartCoroutine ("CloseDoor"); // We call the open vortex Coroutine.

			yield return new WaitForSeconds(changeSceneDelay); // the delay until the level changes.
			float fadeTime = GameObject.Find ("Fader").GetComponent<Fading_Mobile> ().BeginFade (1); // sets the screen fade effect.
			yield return new WaitForSeconds(fadeTime);// the delay until the fade effect stops.
			SceneManager.LoadScene (levelToLoad); // we load the scene.

		}

		public IEnumerator GoNextLevel ()
		{
			spawnTraveller = true;
			yield return new WaitForSeconds(0.001f); // the delay until the level changes.
			player.gameObject.SetActive(false); // set the entire player object to false.
			player.controllerActive = false; // if the vortex intro is active you can not control the character until the vortex closes.
			player.enabled = false; // turn of the player to avoid after death.

			yield return new WaitForSeconds(1f); // the delay until the level changes.

			StartCoroutine ("CloseDoor"); // We call the open vortex Coroutine.

			yield return new WaitForSeconds(changeSceneDelay); // the delay until the level changes.
			float fadeTime = GameObject.Find ("Fader").GetComponent<Fading_Mobile> ().BeginFade (1); // sets the screen fade effect.
			yield return new WaitForSeconds(fadeTime);// the delay until the fade effect stops.
			SceneManager.LoadScene (NextlevelToLoad); // we load the scene.

		}
		public IEnumerator GoLevelLevelCompleteScreen ()
		{
			spawnTraveller = true;
			yield return new WaitForSeconds(0.001f); // the delay until the level changes.
			player.gameObject.SetActive(false); // set the entire player object to false.
			player.controllerActive = false; // if the vortex intro is active you can not control the character until the vortex closes.
			player.enabled = false; // turn of the player to avoid after death.

			yield return new WaitForSeconds(1f); // the delay until the level changes.

			StartCoroutine ("CloseDoor"); // We call the open vortex Coroutine.

			yield return new WaitForSeconds(changeSceneDelay);

			//GameObject.Find ("QuizModule").transform.GetChild (0).gameObject.SetActive (true);

			GameObject.Find ("MenuCanvas").transform.GetChild (1).gameObject.SetActive (true);

			int LevelNumber = FindObjectOfType<LevelIndicator_Mobile> ().LevelNumber;
			Debug.Log (LevelNumber);
			GorillaThrowRocks.instance.gamePlaySound.Pause();
			levelCompleteMusic.Play();
			if (PlayerPrefs.GetInt ("Lock") < LevelNumber)
			{
				PlayerPrefs.SetInt ("Lock", LevelNumber);
			}

			// the delay until the level changes.
			//float fadeTime = GameObject.Find ("Fader").GetComponent<Fading_Mobile> ().BeginFade (1); // sets the screen fade effect.
			//yield return new WaitForSeconds(fadeTime);// the delay until the fade effect stops.
			//SceneManager.LoadScene (levelToLoad); // we load the scene.



		}
	
	
}
}


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY BITBOYS //////////////////////////////////////////////////////////////////////////////////////////////////////

