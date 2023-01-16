using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


namespace Bitboys.SuperPlaftormer2D {
[System.Serializable]
public class QuestionCategory : MonoBehaviour {
	
	public AudioSource audioSource;
	public AudioClip correct;
	public AudioClip wrong;

	public GameObject LevelComplete;
	public GameObject AnsButton; // button Prefabs which instantiat for possible answers
	public Transform AnswerBG;   // Answer_Button's Parent
	public Text QuestionText;	 // Text in Which Question Placed Randomly 
	public int QuestionLength;	// Count of Quention Length
	public string CategoryName;	// Category of this Round ( fruits, Vegetables, Animals
	public QuestionClass[] Questions; // Array of QuestionData Class 
	void OnEnable() 
	{
		CreateNewQuestion ();
	}


	private void CreateNewQuestion()
	{
			int levelNumber = FindObjectOfType<LevelIndicator_Mobile>().LevelNumber-1;
			QuestionText.text = Questions [levelNumber].Question;
			int AnswerLength = 4;
			Debug.Log (AnswerLength);

			for (int i = 0; i < AnswerLength; i++) 
			{
				GameObject Buton = Instantiate (AnsButton ,AnswerBG);
				//Buton.transform.parent = AnswerBG;
				string ansName = Questions [levelNumber].Answers [i].Answer;
				Buton.transform.GetChild (0).gameObject.GetComponent<Text> ().text = ansName;
				Buton.GetComponent<BoolClass> ().IsCorrect = Questions [levelNumber].Answers [i].IsCorrect;
				Buton.GetComponent<Button> ().onClick.AddListener (AnswerButtonFunction);
			}
			QuestionLength--;
	}

		public bool giveAchance = true;
	public void AnswerButtonFunction()
	{
		bool IsCorrect = EventSystem.current.currentSelectedGameObject.GetComponent<BoolClass>().IsCorrect ;
			if (IsCorrect)
			{
				Debug.Log("Answer is Correct ");

				audioSource.PlayOneShot(correct);

				if (QuestionLength != 0) 
				{
					transform.parent.gameObject.SetActive(false);
					GameObject.Find("MenuCanvas").transform.GetChild(0).gameObject.SetActive(true);
				}
			}

			else 
			{
				audioSource.PlayOneShot(wrong);
				if (!giveAchance)
				{
					FindObjectOfType<MenuCanvasScript_Moblie>().ReplayButton();
					GameObject.Find("MenuCanvas").transform.GetChild(0).gameObject.SetActive(true);
				}
				giveAchance = false;
			}
		
	}
		
}

[System.Serializable]
public class AnswerClass  {
	public string Answer;
	public bool IsCorrect;
}

[System.Serializable]
public class QuestionClass  {

	public string Question;
	public AnswerClass[] Answers;

}
}



