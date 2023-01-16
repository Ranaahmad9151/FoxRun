using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	// This script manages the journey that makes a moving platform to make it easier to know the journey that they will do.

	public class MvPlatformVisiblePoints_Mobile : MonoBehaviour {

	public Transform[] Points;
	
	public IEnumerator<Transform> GetPathEnumerator()
	{
		if(Points == null || Points.Length < 1)
			yield break;
		
		var direction = 1;
		var index = 0;
		while (true)
		{
			yield return Points[index];
			
			if (Points.Length == 1)
				continue;
			
			if (index <= 0)
				direction = 1;
			else if (index >= Points.Length - 1)
				direction = -1;
			
			index = index + direction;
		}
	}
		// We draw the transform points to easy visualize the platform moving path.
	public void OnDrawGizmos()
	{
		if (Points == null || Points.Length < 2)
			return;
		
		for (var i = 1; i < Points.Length; i++) {
			Gizmos.DrawLine (Points [i - 1].position, Points [i].position);
		}
	}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////