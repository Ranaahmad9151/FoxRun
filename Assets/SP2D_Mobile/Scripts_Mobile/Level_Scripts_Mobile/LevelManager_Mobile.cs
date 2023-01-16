using UnityEngine;
using System.Collections;


namespace Bitboys.SuperPlaftormer2D {

// The Level manager handles things like respawn the player  when it's killed, the vortex of the intro or the level particles among other things.

	public class LevelManager_Mobile : MonoBehaviour {

	public GameObject currentCheckPoint; // The level star check point object/prefab.
	private PlayerController_Mobile player; // Here we call the script that controls the player.
	public GameObject deathParticle; // The Particle prefab spawned when the player dies.
    public GameObject respawnEffect; // The respawn particle prefab spawned when the player appears again in the scene.
	public GameObject respawnParticle;// Another respawn particle prefab spawned when the player appears again in the scene.
	[Range(0, 100)] // Penalty points Slide Bar.
	public int pointsPenaltyOnDeath = 25; // The points we loose each time the player dies.
	[Range(0.0f, 10.0f)] // Respawn delay Slide Bar.
	public float respawnDelay = 2.0f; // The respawn time delay between the player dies and is respawned again.
	private CameraController_Mobile cameraMain; // The Main Camera script reference variable.
	private HealthManager_Mobile healthMnager; // The Health Manager Script reference variable.
	public static CheckPoint_Mobile checkpoints; // The Checkpoint script reference variable.
	public AudioClip deadSfx; // The audio clip we want to play when the player dies.
	[Range(0.0f, 5.0f)] // Dead audio fx volume Slide Bar.
	public float deadSfxVolume = 1f; // The dead audio effect volumen.
	private Weapon1_Mobile weapon1;// With this variable we make reference to the Weapon 01 script.
	private Weapon2_Mobile weapon2;// With this variable we make reference to the Weapon 02 script.
	private Weapon3_Mobile weapon3;// With this variable we make reference to the Weapon 03 script.
	private Weapon4_Mobile weapon4;// With this variable we make reference to the Weapon 04 script.
	private DollyZoom_Mobile dolly; // The Doly Zoom Camera effect Script reference variable.
	private GlitchedCharacter_Mobile glitchCharacter;// The glitched character that appears at the Vortex intro(Script reference).
	//Vortex variables

	[Range(0.0f, 500f)]
	public float rotationSpeed = 200; // The rotation speed of the vortex sprite.
	[Range(0.0f, 1.0f)]
	public float maxScale = 1.0f; // The max size of the vortex.
	[Range(0.0f, 1.0f)]
	public float minScale = 0f; // The min size of the vortex.
	[Range(0.0f, 5.0f)]
	public float scaleSpeed = 1.5f; // The speed witch the vortex opens.
	private Vector3 targetScale; // the scale of the vortex.
	public bool openTheVortex = false; // the bool that opens the vortex.
	public bool closeTheVortex; // the bool that closes the vortex.
	public AudioClip vortexSfx; // the vortex sound effect.
	[Range(0.0f, 5.0f)]
	public float vortexSfxVolume = 1f; // the vortex sound effect volume amount.
	public GameObject vortexCloseEffect; // the effect prefab that appears when the vortex closes.

	void Awake () {
			
		// The script references to find with the names that previously we named the variables.
		player = FindObjectOfType<PlayerController_Mobile> ();
		cameraMain = FindObjectOfType<CameraController_Mobile> ();
		healthMnager = FindObjectOfType<HealthManager_Mobile> ();
		checkpoints= FindObjectOfType<CheckPoint_Mobile> ();
		glitchCharacter= FindObjectOfType<GlitchedCharacter_Mobile> ();
		dolly = FindObjectOfType<DollyZoom_Mobile> ();


	// Here we call the Weapons Scripts to make use of them.
		weapon1 = FindObjectOfType<Weapon1_Mobile> ();
		weapon2 = FindObjectOfType<Weapon2_Mobile> ();
		weapon3 = FindObjectOfType<Weapon3_Mobile> ();
		weapon4 = FindObjectOfType<Weapon4_Mobile> ();

		//The vortex opens automatically at the beginning of the level unless the Player Controller has the option disabled.
		if (player.vortexIntro == true) {
			openTheVortex = true; // Bool that opens the vortex.
			GetComponent<AudioSource> ().PlayOneShot (vortexSfx, vortexSfxVolume); // vortex sound effect.
			}
	}
		// Update is called once per frame
		void Update () {	
			// VORTEX INTRO FALSE //
			//If the open vortex bool hosted on the player controller script is deactivated, the vortex will not open.
			if (player.vortexIntro == false && player.isInGame == true ) {
			openTheVortex = false;
			glitchCharacter.gameObject.SetActive(false);// The glitched character will be deactivated wile the open vortex option is false.
			
		}

			// VORTEX INTRO TRUE //
		if (player.vortexIntro == true) {
				
			this.transform.localScale = Vector3.Lerp (transform.localScale, targetScale, Time.deltaTime * scaleSpeed); // We use Vector3.Lerp to smooth change the scale of the vortex object.
			if (openTheVortex == true) {
			StartCoroutine ("OpenVortex"); // We call the open vortex Coroutine.
			player.controllerActive = false; // if the vortex intro is active you can not control the character until the vortex closes.
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionY;// for a few seconds we froze the vertical movement of the player to create the feeling that it appears in the center of the vortex.
			player.transform.position = this.transform.position * 1.4f;// We modify the position of the character transform to place it a little above from its natural position.
			glitchCharacter.transform.position = this.transform.position * 1.4f;// Also we modify the position of the glitched player to place it a little above from its natural position.

			} else {
			StopCoroutine ("OpenVortex");// if "openthevortex"bool is false we stop the open vortex coroutine.
			}

				// We activate the closeTheVortex bool at the end of the "OpenVortex" coroutine.
			if (closeTheVortex == true) {
			openTheVortex = false;
			StartCoroutine ("CloseVortex");
			player.UnfreezeConstraints ();
			
				} else { // we use the "else" expression to ensure that in the opposite case the CloseVortex coroutine stops.
			StopCoroutine ("CloseVortex");
			}
				// While the vortex remains open will continue spinning.
			if (openTheVortex == true || closeTheVortex == true) {
			transform.Rotate (0, 0, rotationSpeed * -Time.deltaTime);
			} else {
					// Otherwise if it is not open, it will stop spinning and the scale will be zero.
			transform.Rotate (0, 0, 0);
			this.transform.localScale = new Vector3 (0, 0, 0);
			}
		}
			//When the vortex is closed character will be activated and can control it.
		if (player.vortexIntro == false) {
          player.controllerActive = true;
} 

}

    // The iEnumerator that open the vortex.
     public IEnumerator OpenVortex()
	{
	yield return new WaitForSeconds (0.3f); // the time between a task and expect another.
	targetScale.Set (maxScale, maxScale, maxScale); // this sets the vortex to their max scale.
	yield return new WaitForSeconds (1);// the time between a task and expect another.
	closeTheVortex = true; // this activates the close vortex bool.
}
	// The iEnumerator that closes the vortex.
	public IEnumerator CloseVortex(){
			
	glitchCharacter.enabled = false; // we disable the glitched sprite character animation and their script.
	glitchCharacter.gameObject.SetActive(false); // here we deactivate the glitched character object.
	yield return new WaitForSeconds (0.5f);// the time between a task and expect another.
	targetScale.Set (minScale, minScale, minScale);
	yield return new WaitForSeconds (0.5f);// the time between a task and expect another.
	this.transform.localScale = new Vector3(0, 0, 0); // set the vortex scale to the minimum size.
	GameObject go = vortexCloseEffect;
	go.SetActive (true); // Deactivate the vortex game object.
	dolly.inDollyZoomZone = false; // disable the dolly zoom camera effect.
	yield return new WaitForSeconds (1);// the time between a task and expect another.
	//GameObject vort = vortexCloseEffect;
	//vort.SetActive (false); // disable the vortex close effect when the vortex is closed.
	closeTheVortex = false; // finally we ends  changing  the close the vortex bool to fake.

	}
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
		//RESPAWN THE PLAYER WHEN DIES//

		//When the player dies we activate the respawn player coroutine and disable the gamepad vibration activated when the character dies.
		public void RespawnPlayer()
	{
		StartCoroutine ("RespawnPlayerCo"); // Respawn Coroutine.

	}
		// Here is the respawn coroutine and all the steps taken since the player dies and until it returns to be spawned on the last checkpoint.
	public IEnumerator RespawnPlayerCo()
	{
			GameObject.Find ("Fader").GetComponent<Fading_Mobile> ().BeginFade (1); // Activates the camera fade effect when the player dies.
		player.enabled = false; // turn of the player to avoid after death.
		player.gameObject.SetActive(false); // set the entire player object to false.
		dolly.dollyZoom = false; // disable the main camera dolly zoom effect.
		dolly.inDollyZoomZone = false; // even though we are in a dolly zoom area, we force the variable to be false in order to make the camera return to its initial position.
		Instantiate (deathParticle, player.transform.position, player.transform.rotation); //We instantiate the dead particles.
		GetComponent<AudioSource> ().PlayOneShot (deadSfx, deadSfxVolume); // the dead sound effects.
		player.touchingLeftWall = false;// if at the moment of death we are hooked to a wall, we deactivate the "touch wall" option in order to be regenerated in a normal position.
		player.touchingRightWall = false;// if at the moment of death we are hooked to a wall, we deactivate the "touch wall" option in order to be regenerated in a normal position.

	    // Disable all weapons that we collected during the gameplay. The character will be respawned again but without weapons.
		weapon1.gotWeapon1 = false; 
		weapon1.wp1Selected = false;
		weapon2.gotWeapon2 = false;
		weapon2.wp2Selected = false;
		weapon3.gotWeapon3 = false;
		weapon3.wp3Selected = false;
		weapon4.gotWeapon4 = false;
		weapon4.wp4Selected = false;



		player.weapon0Shooting = false; // if the character was shooting at the time of death, the shooting stops.
		player.transform.Find ("PlayerGraphics").GetComponent<SpriteRenderer>().enabled = false; // Disable the player graphics (sprites) when dies.
		cameraMain.isFollowing = false; // the camera stops following the player.
		Debug.Log ("Player Respawn"); // we make a little debug log.

		yield return new WaitForSeconds (respawnDelay);// the delay time between the player dies and until it returns to be regenerated




		player.transform.position = currentCheckPoint.transform.position; // after being regenerated we appear at the last checkpoint for which we have passed.
		player.knockbackCounter = 0; // Sets the knockback counter to cero.
		player.enabled = true; // reactivate the player.
		player.gameObject.SetActive(true);// sets active the player object.
		player.transform.Find ("PlayerGraphics").GetComponent<SpriteRenderer>().enabled = true; // Set active the player sprite renderer component.
		player.transform.Find ("PlayerGraphics").localScale = new Vector3(1, 1, 1); // Set the graphics scale to their normal size.
		player.transform.localScale = new Vector3(1, 1, 1); // Adjust the horizontal scale of the player to look to the right whenever it is respawned.
		player.GetComponent<CircleCollider2D>().sharedMaterial.friction = 0f; // set the player's physic material friction to 0.
		cameraMain.isFollowing = true;// the camera returns to follow the character.

		yield return new WaitForSeconds (0.5f);// the delay time between the player dies and until it returns to be regenerated


			GameObject.Find ("Fader").GetComponent<Fading_Mobile> ().BeginFade (-1); // sets the screen fade effect to 0.

		healthMnager.FullHealth (); // we call "Full Health" variable located on the health manager script to recover the full character energy. 
		healthMnager.isDead = false; // we ensure that the player is not dead!
		Instantiate (respawnParticle, player.transform.position, player.transform.rotation); // we instantiate the respawn effects and particles in the player respawn position.
		Instantiate (respawnEffect, player.transform.position, player.transform.rotation);// we instantiate the respawn effects and particles in the player respawn position.
	}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by BITBOYS ///////////////////////////////////////////////////////////////////////////////////////////////