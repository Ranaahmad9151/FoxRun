using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	// the sound played by the chatacter when its damaged.
	
	public class DamageSounds_Mobile : MonoBehaviour {

	
	public AudioClip damageSfx;
	[Range(0.0f, 5.0f)] // slide bar.
	public float damageSfxVolume = 1f;

	// Use this for initialization
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") {
        GetComponent<AudioSource>().PlayOneShot(damageSfx, damageSfxVolume);

		}
	}
}
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////