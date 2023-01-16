using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Bitboys.SuperPlaftormer2D {

	// This script stores the amount of gems that the player collects.
	
	public class NumberOfGems_Mobile : MonoBehaviour {

	public static int score;
	private PlayerController_Mobile player;
	Text text;
	public GameObject redGem;
	public GameObject yellowGem;
	public GameObject blueGem;
	public GameObject lilaGem;
	public GameObject greenGem;
	
	void Start () 
	{
		text = GetComponent<Text> ();
		
		score = 0;

		player = FindObjectOfType<PlayerController_Mobile>();
	}
	
	void Update () 
	{
		if (score < 0)
			score = 0;
		text.text = "" + score;

		if(player.redDiamond == true)
		{
		redGem.SetActive(true);
		} else {
		redGem.SetActive(false);
		}
		if(player.yellowDiamond == true)
		{
		yellowGem.SetActive(true);
		} else {
		yellowGem.SetActive(false);
		}
		if(player.blueDiamond == true)
		{
		blueGem.SetActive(true);
		} else {
		blueGem.SetActive(false);
		}
		if(player.lilaDiamond == true)
		{
		lilaGem.SetActive(true);
		} else {
		lilaGem.SetActive(false);
		}
		if(player.greenDiamond == true)
		{
     	greenGem.SetActive(true);
		} else {
			greenGem.SetActive(false);
		}
	}
	public static void AddPoints (int NumberOfGems)
	{
		score += NumberOfGems;
	}
	public static void Reset()
	{
		score = 0;
	}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D By Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////