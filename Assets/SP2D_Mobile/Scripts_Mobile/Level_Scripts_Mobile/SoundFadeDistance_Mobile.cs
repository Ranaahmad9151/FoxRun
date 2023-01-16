using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	// We use this script to activate the sound effect of an object only when the player is their area.

[RequireComponent(typeof(AudioSource))]

	public class SoundFadeDistance_Mobile : MonoBehaviour {

	[Range(0.0f, 30.0f)]// Slide Bar.
	public float playerRange = 20f;
	public LayerMask playerLayer;
	public bool playerInRange;
	private AudioSource audios;
	[Range(0.0f, 5.0f)]// Slide Bar.
	public float fadeLeft= 1f;
	[Range(-5.0f, 5.0f)]// Slide Bar.
	public float fadeRight= -1f;
	[Range(0.0f, 5.0f)]// Slide Bar.
	public float smoothSpeed = 2.0f;
	[Range(0.0f, 5.0f)]// Slide Bar.
	public float maxVolume = 0.3f;
	[Range(0.0f, 5.0f)]// Slide Bar.
	public float minVolume = 0.0f;

	
	// Use this for initialization
	void Start () {
		audios = GetComponent<AudioSource> ();
	}

	
	// Update is called once per frame
	void Update () {

		// Update the fade.
		if (playerInRange)
		{

			audios.volume = Mathf.SmoothStep (audios.volume, maxVolume, smoothSpeed * Time.deltaTime);

	
		}
		else if (!playerInRange && audios.volume >0)
		{

			audios.volume = Mathf.SmoothStep (audios.volume, minVolume, smoothSpeed * Time.deltaTime);


		}
		playerInRange = Physics2D.OverlapCircle (transform.position, playerRange, playerLayer);
	}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////
