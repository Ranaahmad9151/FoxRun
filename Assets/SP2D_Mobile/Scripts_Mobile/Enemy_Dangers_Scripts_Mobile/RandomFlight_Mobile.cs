using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	// This script handles the random flight of the flying enemies.
	
	public class RandomFlight_Mobile : MonoBehaviour {

	[Range(0, 20)] // slide bar.
	public int moveSpeed = 2;  //per second
	Vector3 moveDirection = new Vector3(0, -1f, 0);
	public bool movingUp = false;
	
	void Update () 
	{ 
	
		if(!movingUp && transform.localPosition.y <= -0.5f)
		{
			moveDirection = new Vector3(0,0.5f,0);
			movingUp = true;
		}
		

		if(movingUp && transform.localPosition.y >= 0.5f)
		{
			moveDirection = new Vector3(0,-0.5f,0);
			movingUp = false;
		}
		
		transform.Translate(moveSpeed * Time.deltaTime * moveDirection);
		
	} 
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////