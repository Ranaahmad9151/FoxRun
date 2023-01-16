using UnityEngine;
using System.Collections;

namespace Bitboys.SuperPlaftormer2D {

	//Here we will control the bullets behaviors and the damage caused to the enemies.

	[RequireComponent(typeof(CircleCollider2D))]
	[RequireComponent(typeof(Rigidbody2D))]

	public class FireballController_Mobile : MonoBehaviour {
		
	[Range(0.0f, 50.0f)] // Bullet speed slide Bar.
	public float speed = 30f; // the movement speed of the bullets.
	private PlayerController_Mobile player;// Set the reference to the player controller script.
	public GameObject enemyDeathEffect; // The effects prefab that is instantiated when the fireball object collides with an enemy.
	public GameObject impactEffect;// The effects prefab that is instantiated when the fireball object collides with an enemy.
	[Range(0, 1000)] // slide bar.
	public int pointsForKill = 250; // The points received to eliminate an enemy.
	[Range(0.0f, 50.0f)] // slide bar.
	public float rotationSpeed = 0f; // the fireball transform rotation speed.
	[Range(0,5)] // slide bar.
	public int damageToGive = 1; // The damage caused to the enemy when the fireball touches it.
	
	
	void Start () {
		
			player = FindObjectOfType<PlayerController_Mobile> ();
		// This makes that if the player is not looking to the right the fireball goes and rotates to the left side.
		if (!player.facingRight) {
			rotationSpeed = -rotationSpeed; 
			speed = -speed;
		}
	}

	void Update () {
			
			//The fireball movement formula takes the Rigidbody's 2D velocity component and applies force to its vertical axis multiplying it by the moving speed.
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
		GetComponent<Rigidbody2D> ().angularVelocity = rotationSpeed;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
			//If the fireball collides with an object tagged with the name "Enemy" we call the enemy's health script to says that we are causing it damage.
			/*if (other.tag == "Enemy") { 

				other.GetComponent<EnemyHealthManager_Mobile>().giveDamage (damageToGive);
		}*/
		
			Instantiate (impactEffect, transform.position, transform.rotation); //  Instantiate the impact effects when the fireball collides with an enemy and then destroys the object.
		Destroy (gameObject);
	}
}
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D BY Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////

