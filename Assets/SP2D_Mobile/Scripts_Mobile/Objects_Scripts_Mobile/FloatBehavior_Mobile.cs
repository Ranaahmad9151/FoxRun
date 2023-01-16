using UnityEngine;
using System;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	// We use this function for creating the floating bubble effect.
	
	public class FloatBehavior_Mobile : MonoBehaviour
{
	float originalY;
	
	public float floatStrength = 1; // You can change this in the Unity Editor to change the range of y positions that are possible.
	
	void Start()
	{
		this.originalY = this.transform.position.y;
	}
	
	void Update()
	{
		transform.position = new Vector3(transform.position.x, originalY + ((float)Mathf.Sin(Time.time) * floatStrength), transform.position.z);


	}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////