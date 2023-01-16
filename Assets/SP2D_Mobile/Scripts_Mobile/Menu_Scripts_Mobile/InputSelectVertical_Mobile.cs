using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Bitboys.SuperPlaftormer2D {
	
public class InputSelectVertical_Mobile : MonoBehaviour {


		public EventSystem eventSystem; // The eventsystem created automatically whenever we create a new canvas and with which we can decide the order in which we can move through our menu.
		public GameObject selectedButton; // The button used to start our movement on the menu.
		private bool buttonSelected;// With this bool will know if we are selecting a button or not.
	
	void Update ()
		{
			
			if (Input.GetAxisRaw ("Vertical") != 0 && buttonSelected == false) { // If we move by the menu in vertical direction with the keys of the keyboard or the joystick of our gamepad and the button which i want to select is not selected...
				
				eventSystem.SetSelectedGameObject (selectedButton); // We call the eventsystem to tell you that we are on the button and that the rest are not active.
				buttonSelected = true;
			}
		}
		private void OnDisable(){
			buttonSelected = false;
		}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////

