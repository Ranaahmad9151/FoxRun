using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOFF : MonoBehaviour
{
	public float lifetime;
	private float varTime;
    // Use this for initialization
    private void OnEnable()
    {
		lifetime = varTime;

    }
    private void Awake()
    {
		varTime = lifetime;

	}
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		lifetime -= Time.deltaTime;

		if (lifetime < 0)
		{
			gameObject.SetActive(false);

		}
	}
}
