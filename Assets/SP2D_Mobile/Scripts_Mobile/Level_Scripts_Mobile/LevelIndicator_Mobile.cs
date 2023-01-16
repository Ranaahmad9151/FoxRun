using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Bitboys.SuperPlaftormer2D {

public class LevelIndicator_Mobile : MonoBehaviour {


	public Text text;
	private string St;
	private int i;
		public int LevelNumber;

	void Start () {
		this.gameObject.transform.GetChild (0).gameObject.SetActive (true);
			St = "Level \"" + LevelNumber  + "\" Begins "; 
			StartCoroutine ("JustWait");
	}
	
	
	IEnumerator JustWait()
	{
		for ( i = 0; i < St.Length; i++)
		{
			text.text = text.text + St [i].ToString ();
			yield return new  WaitForSeconds(0.05f);
		}

	}
}
}