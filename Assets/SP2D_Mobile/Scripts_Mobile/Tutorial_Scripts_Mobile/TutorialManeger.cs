using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Bitboys.SuperPlaftormer2D {
public class TutorialManeger : MonoBehaviour {
	public string[] TextShower;
	private string str; 
	public Text text;
	public int i;
	// Use this for initialization


	void Start ()
	{
		//St = TextShower [LoadLevelSelection_Mobile.LevelNumber - 1];
//		str = TextShower [FindObjectOfType<LevelIndicator_Mobile>().LevelNumber-1];
//		StartCoroutine ("JustWait");
	}
	
		public void StartTutorial(string str)
		{
			//
		
			switch (str) 
			{
				case "diamonds":
					this.str = "Collect 5 Daimonds To Complete the Level";
					Destroy(GameObject.Find(str).gameObject);
					StartCoroutine ("JustWait");

					break;
			
				case "jump":
					this.str = "Press \"X\" to Jump and Stick the Wall";
					//Destroy(GameObject.Find(str).gameObject);
					StartCoroutine ("JustWait");

					break;
				
				case "simple jump":
					this.str = "Press \"X\" to Jump";
					//Destroy(GameObject.Find(str).gameObject);
					StartCoroutine ("JustWait");

					break;

				case "fire":
					this.str = "Press \"□\" for Fire to Kill the Enemy";
					//Destroy(GameObject.Find(str).gameObject);
					StartCoroutine ("JustWait");

					break;
			
				case "shoot":
					this.str = "Press \"□\" for Fire ";
					Destroy(GameObject.Find(str).gameObject);
					StartCoroutine ("JustWait");

					break;

				case "weapon":
					this.str = "Press \"▲\" to Change the Weapon";
					Destroy(GameObject.Find(str).gameObject);
					StartCoroutine ("JustWait");

					break;
				
				case "door":
					this.str = "Jump into the Door For Next Level";
					//Destroy(GameObject.Find(str).gameObject);
					StartCoroutine ("JustWait");

					break;

				case "go up":
					this.str = "Go Up For the Diamond";
					Destroy(GameObject.Find(str).gameObject);
					StartCoroutine ("JustWait");

					break;

				case "life":
					this.str = "Congratulations For One More Life";
					Destroy(GameObject.Find(str).gameObject);
					StartCoroutine ("JustWait");

					break;

				case "powerUp":
					this.str = "Power Up";
					Destroy(GameObject.Find(str).gameObject);
					StartCoroutine ("JustWait");

					break;
				case "save life":
					this.str = "Go Back For Save Life";
					//Destroy(GameObject.Find(str).gameObject);
					StartCoroutine ("JustWait");

					break;
				case "boss":
					this.str = "Boss is Here";
					//Destroy(GameObject.Find(str).gameObject);
					StartCoroutine ("JustWait");

					break;
				case "spikes":
					this.str = "Save Life From Spikes";
					//Destroy(GameObject.Find(str).gameObject);
					StartCoroutine ("JustWait");

					break;
				
				case "Bee":
					this.str = "Jump Over the Bee to Kill";
					//Destroy(GameObject.Find(str).gameObject);
					StartCoroutine ("JustWait");

					break;
				case "downSpikes":
					this.str = "Save Life Form Bottom Spikes";
					//Destroy(GameObject.Find(str).gameObject);
					StartCoroutine ("JustWait");

					break;

			}


		}



	IEnumerator JustWait()
	{
		transform.GetChild(0).gameObject.SetActive(true);
		text.text = "";
		for ( i = 0; i < str.Length; i++)
		{
		text.text = text.text + str [i].ToString ();
		yield return new  WaitForSeconds(0.05f);
		}
	}




}

}
