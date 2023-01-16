using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	// This script allows the Main Camera Shake effect function.

public class Shake_Mobile : MonoBehaviour {

	private float shakeTimer; 
	private float shakeAmount;
	public void ShakeCamera (float shakePwr, float shakeDur)
	{
		shakeAmount = shakePwr;
		shakeTimer = shakeDur;
		
	}

	void Update(){

		if (shakeTimer >= 0) 
		{
			Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;
			transform.position = new Vector3 (transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);
			shakeTimer -= Time.deltaTime;
		}
}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D By Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////

