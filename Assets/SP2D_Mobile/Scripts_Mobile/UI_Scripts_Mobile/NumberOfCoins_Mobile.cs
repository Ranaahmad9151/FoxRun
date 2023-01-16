using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Bitboys.SuperPlaftormer2D {

	// This script stores the amount of tokens that the player collects.
	
	public class NumberOfCoins_Mobile : MonoBehaviour {

	public static int score;

	Text text;
	
	void Start () 
	{
		text = GetComponent<Text> ();

		score = 0;
	}

	void Update () 
	{
	        if (score < 0)
			score = 0;
		text.text = "" + score;
	}
	public static void AddPoints (int NumberOfCoins)
	{
		score += NumberOfCoins;
	}
	public static void Reset()
	{
		score = 0;
}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D By Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////