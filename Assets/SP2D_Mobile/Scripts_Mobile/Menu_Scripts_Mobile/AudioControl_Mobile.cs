using UnityEngine;
using System.Collections;

// Audio control is the script used to be able to control the master volume of the game. It is normally associated to a slider inside a menu, with which we can modify the volume.

namespace Bitboys.SuperPlaftormer2D {


public class AudioControl_Mobile : MonoBehaviour {
		

		public void AdjustVolume (float newVolume) { //We create a new variable for the volume, we assign float value to indicate the new volume amount that we get when we move the slider.
		AudioListener.volume = newVolume;
	}
	
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////
