﻿using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	// Sets how long to wait before destroying an object. Is usually used to destroy objects such bullets...

	public class DestroyAfterSeconds_Mobile : MonoBehaviour
{
	public float lifetime;
	
	void Start ()
	{
		Destroy (gameObject, lifetime);
	}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D By Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////