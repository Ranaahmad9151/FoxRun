﻿using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {
	
	public class DisableCollider_Mobile : MonoBehaviour {

	public GameObject theObject;

	void OnCollisionEnter2D(Collision2D coll){ 
	if(coll.gameObject.tag == "Player"){
			theObject.GetComponent<CircleCollider2D>().isTrigger = enabled;

		}
	}

}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////