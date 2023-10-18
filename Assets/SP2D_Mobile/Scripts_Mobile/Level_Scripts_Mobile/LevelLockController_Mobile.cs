using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelLockController_Mobile : MonoBehaviour {

	public Image[] Locks;
	private int LockNumber;
	private GameObject ButtonPerant;
	public string PerantName;//Name the Perant GameObject of Buttons 
	public int LastNumber;// LastNumber set the value not more then lock images that resist the exection;

	void Start ()
	{
		ButtonPerant = GameObject.Find (PerantName);
        LockNumber = PlayerPrefs.GetInt("Lock");

        if (LockNumber >= LastNumber)
        {
            LockNumber = LastNumber - 1;
        }
        Debug.Log(LockNumber);
        for (int i = 0; i <= LockNumber; i++)
        {
            Locks[i].gameObject.SetActive(false);
        }



        // if Buttons are not in proper shape like triangle etc
        for (int i = LockNumber + 1; i <= Locks.Length - 1; i++)
        {
            ButtonPerant.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }


        // My Code
        LockNumber = 0;
		for (int i = 0; i <= LockNumber; i++)
		{
			Locks[i].gameObject.SetActive(false);
			print("Lock Level " + LockNumber);
		}

	}
	

}
