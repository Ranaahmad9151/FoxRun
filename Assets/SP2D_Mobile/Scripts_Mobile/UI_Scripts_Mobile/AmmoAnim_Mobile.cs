using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	public class AmmoAnim_Mobile : MonoBehaviour {


	public bool outAmmo;
	private Animator anim;
	private Weapon1_Mobile weap1;
	private Weapon2_Mobile weap2;
	private Weapon3_Mobile weap3;
	private Weapon4_Mobile weap4;


   

	void Awake () {
		anim = this.GetComponent<Animator> ();
		weap1 = FindObjectOfType<Weapon1_Mobile> ();
		weap2 = FindObjectOfType<Weapon2_Mobile> ();
		weap3 = FindObjectOfType<Weapon3_Mobile> ();
		weap4 = FindObjectOfType<Weapon4_Mobile> ();

	}

	// Update is called once per frame
	void Update () {

			//If ammo is less than or equal to 25 the "Ammo" Ui text will blink.
			if (weap1.weapon1AmmoAmount <= 25 || weap2.weapon2AmmoAmount <= 50|| weap3.weapon3AmmoAmount <= 20 || weap4.weapon4AmmoAmount <= 20) {
				this.outAmmo = true;
			} else {
				this.outAmmo = false;
			}

		if (outAmmo) {
			this.anim.SetBool ("OutAmmo", outAmmo);
		} 

		if (!outAmmo) {
		}
		this.anim.SetBool ("OutAmmo",!outAmmo);

	}

}
}