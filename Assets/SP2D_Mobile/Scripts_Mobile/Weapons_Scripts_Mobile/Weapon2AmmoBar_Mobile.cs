using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Bitboys.SuperPlaftormer2D {

	// This scripts allows the Weapon 01 UI Ammo Bar functions.

	public class Weapon2AmmoBar_Mobile : MonoBehaviour {

		//Variables
		private static int currentAmmo; // The of ammo amount counted in integer numbers.
		[Range(0, 500)]// Slide Bar.
		public int maxWeaponAmmo; // The max ammo that we can provide to the weapon.
		[Range(0.0f, 20.0f)]// Slide Bar.
		public float wp2BarSpeed; // the speed at which increases or decreases the ammo bar.
		public Image wp2VisualAmmo; // The ammo bar sprite.
		private Weapon2_Mobile wp2; // Set the call of the weapon script.
		public bool outAmmo;
		public Animator anim;

		void Awake () {

			wp2VisualAmmo = GetComponent<Image>(); // assign the ammo sprite to the image component located on this object.
			wp2 = FindObjectOfType<Weapon2_Mobile>(); // the reference to call the weapon control script.

		}
		void Update () {

			HandleAmmoBar ();// call the handle ammo bar void to activate the bar movement.
			currentAmmo = wp2.weapon2AmmoAmount; // The amount of ammunition that we have is equal to the ammo bar size.

			//If ammo is less than or equal to 15 the "Ammo" Ui text will blink.
			if (wp2.weapon2AmmoAmount <= 15 ) {
				outAmmo = true;
			} else {
				outAmmo = false;
			}

			if (outAmmo) {
				anim.SetBool ("OutAmmo", outAmmo);
			} 

			if (!outAmmo) {
			}
			anim.SetBool ("OutAmmo",!outAmmo);
		}


		private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
		{
			return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
		}

		private void HandleAmmoBar()
		{
			float currentValue = MapValues(currentAmmo,0,maxWeaponAmmo,0,1);

			wp2VisualAmmo.fillAmount = Mathf.Lerp (wp2VisualAmmo.fillAmount, currentValue, Time.deltaTime * wp2BarSpeed); // this formula sets the ammo bar image size to the current ammo amount and multiplies the delta time by the bar speed.
		}
	}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////

