using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	// We can use this script to assign it to any object. If the player collides with the object automatically will die.
	
	public class KillPlayer_Mobile : MonoBehaviour {

		public LevelManager_Mobile levelManager;

	// Use this for initialization
	void Start () {
			
			levelManager = FindObjectOfType<LevelManager_Mobile> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			levelManager.RespawnPlayer ();
		}
	}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////
