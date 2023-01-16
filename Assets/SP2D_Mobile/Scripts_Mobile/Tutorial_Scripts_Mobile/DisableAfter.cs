using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class DisableAfter : MonoBehaviour {
	
	public float Seconds;


	void OnEnable()
	{
		Invoke ("ThisGameObjectDisable", Seconds);
	}


	void ThisGameObjectDisable()
	{
		gameObject.SetActive(false);
		this.gameObject.GetComponent<ParticleSystem>().Stop();
	}


}
