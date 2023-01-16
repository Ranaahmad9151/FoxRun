using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {
	
	public class CheckPoint_Mobile : MonoBehaviour {

	public LevelManager_Mobile levelManager;
	public GameObject desactivatedCheck;
	public GameObject activatedCheck;
	public GameObject checkParticles;

	// Use this for initialization
	void Awake () {

		levelManager = FindObjectOfType<LevelManager_Mobile> ();
	}
		//When the character comes into contact with this object we send a message to the level manager script to indicate that the character has gone through this checkpoint.
		//Then the checkpoint object that we have already achieved is deactivated. Instead a new checkpoint object containing a different animation is activated.
		//
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.name == "Player") 
		{
			levelManager.currentCheckPoint = this.gameObject;
			Debug.Log ("Activated Checkpoint" + transform.position);

			desactivatedCheck.SetActive(false);
			Instantiate(activatedCheck, transform.position, transform.rotation);
			Instantiate(checkParticles, transform.position, transform.rotation);
		}
	}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D By Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////