using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	// Sets that the object must be destroyed when the particle system stops to play.
	
	public class DestroyFinishedParticles_Mobile : MonoBehaviour {

	private ParticleSystem thisParticleSystem;

	
	void Start () {
		thisParticleSystem = GetComponent<ParticleSystem> ();
	}
	// Update is called once per frame
	void Update () {
	if (thisParticleSystem.isPlaying)
		return;
		Destroy (gameObject);
	}

	void OnBecameInvisible()
	{

		Destroy (gameObject);
	}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D By Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////
