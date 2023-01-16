// The Foreground Parallax is the effect used to move the objects that are in front of the Player like bushes, grass, flowers... Creating the feeling that the player walks through a lush forest.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Bitboys.SuperPlaftormer2D {

	public class Foreground_Parallax_Mobile : MonoBehaviour {


	private GameObject parallaxObject;		// the object that will make the Parallax Effect.
	public Transform player;		// the main character on the scene.
	private Transform mainCam; // The Main Camera.
	private Vector3 startCamPos;		// the initial position of the Camera.
	public bool xParallax;		// Horizontal Parallax Effect (Left/Right).
	public bool yParallax;		//Vertical Parallax Effect (Up/Down).
	[Range(0.0f, 10.0f)]           // Slide Bar
	public float parallaxSpeed = 0.1F;	// The speed of the Parallax Effect.
	[Range(0.0f, 10.0f)]               // Slide Bar
	public float smoothVel = 1.5f;		// The smooth speed of the Parallax Movement.

	void Awake ()
	{
		mainCam = Camera.main.transform; //Main Camera reference.
		parallaxObject = this.gameObject;	// Parallax object local variable.
	}



	void LateUpdate () 
	{
		if(xParallax) // if the parallax effect is horizontal.
			
		{
			
			Vector3 tempPos = parallaxObject.transform.position; // // Define the sprite position.
			float scroll = (startCamPos.x - mainCam.transform.position.x) / parallaxSpeed; // This sets the amount of movement based on subtract the Main Camera position and dividing it by the scroll speed.
			float targetPosX = parallaxObject.transform.position.x + scroll;// This gets the horizontal position of the sprite adds up the scroll float and set it to the horizontal position of the object.
			Vector3 targetPos = new Vector3(targetPosX,tempPos.y,tempPos.z);// get the sprite position and add in the scrolling object horizontal position.
			parallaxObject.transform.position = Vector3.Lerp(parallaxObject.transform.position,targetPos,Time.deltaTime * smoothVel); // Define the new position of the sprite subtrancting the previous position and the target position.
			startCamPos =mainCam.transform.position; // Assign the Main Camera position to the new position.
		}


		if(yParallax)//if the parallax effect is vertical.
		{
			Vector3 tempPos = parallaxObject.transform.position; // // Define the sprite position
			float scroll = (startCamPos.y - mainCam.transform.position.y) / parallaxSpeed;// This sets the amount of movement based on subtract the Main Camera position and dividing it by the scroll speed.
			float targetPosY = parallaxObject.transform.position.y + scroll;//This gets the horizontal position of the sprite adds up the scroll float and set it to the horizontal position of the object.
			Vector3 targetPos = new Vector3(tempPos.x,targetPosY,tempPos.z);// get the sprite position and add in the scrolling object horizontal position.
			parallaxObject.transform.position = Vector3.Lerp(parallaxObject.transform.position,targetPos,Time.deltaTime * smoothVel);// Define the new position of the sprite subtrancting the previous position and the target position.
			startCamPos = mainCam.transform.position;// Assign the Main Camera position to the new position.
		}
	}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////