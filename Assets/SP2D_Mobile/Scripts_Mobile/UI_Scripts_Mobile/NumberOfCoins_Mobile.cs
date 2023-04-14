using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening.Core.Easing;

namespace Bitboys.SuperPlaftormer2D {

	// This script stores the amount of tokens that the player collects.
	
	public class NumberOfCoins_Mobile : MonoBehaviour {

	public static int score;

	Text text;
	
	void Start () 
	{
            /*if (PlayerPrefs.HasKey("PlayerLive"))
            {
                GameManager.instance.livesCountText.text = PlayerPrefs.GetInt("PlayerLive").ToString();
            }
            else
            {
                PlayerPrefs.SetInt("PlayerLive", 5);
                GameManager.instance.livesCountText.text = PlayerPrefs.GetInt("PlayerLive").ToString();
            }*/
            text = GetComponent<Text> ();
			score = PlayerPrefs.GetInt("Coins");
        //score = 0;
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

        score = PlayerPrefs.GetInt("Coins") + NumberOfCoins;
        PlayerPrefs.SetInt("Coins", score);
            
    }
	public static void Reset()
	{
		score = 0;
	}


		
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D By Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////