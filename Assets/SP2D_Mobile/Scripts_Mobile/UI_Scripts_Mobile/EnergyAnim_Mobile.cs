using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	//When the player's health is equal to 1, the "Energy" ui text animation is activated.

	public class EnergyAnim_Mobile : MonoBehaviour {



	public bool healtDown;
	private Animator anim;


	void Awake () {
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (healtDown) {
			anim.SetBool ("LowHealth", healtDown);
		} 

		if (!healtDown) {
		}
		anim.SetBool ("LowHealth",!healtDown);

		}

	}
}


	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////// SUPER PLATFORMER 2D By Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////