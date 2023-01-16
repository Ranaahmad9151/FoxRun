using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	// This script allows the moving platforms performance.
	
	public class MovingPlatform_Mobile : MonoBehaviour {

	public GameObject platform; // The moving platform object/sprite.
	[Range(0.0f, 20.0f)] // Moving platform speed Slide Bar.
	public float moveSpeed = 3.0f; // the platform move speed.
	public Transform currentPoint; // The transform point from wich the platform begins to move.
	public Transform[] points; // the multiple transform point by wich the platform will moves.
	public int pointSelection;// the point where the platform is in real time.
	public Rigidbody2D rb; // the platform object Rigidbody 2D component.

		void Awake () {

		currentPoint = points[pointSelection];
		rb = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {
			// Set the platform movement forward force applied to the transform multiplied by the time in seconds it took to complete the last frame.
		rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
		platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
	    if(platform.transform.position == currentPoint.position)
		{
		pointSelection++;
		if(pointSelection == points.Length)
		{
			pointSelection = 0;
		}
			currentPoint = points[pointSelection];
		}
	}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////