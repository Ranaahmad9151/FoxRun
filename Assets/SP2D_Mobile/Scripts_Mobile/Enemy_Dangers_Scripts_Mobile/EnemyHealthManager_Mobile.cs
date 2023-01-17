﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Bitboys.SuperPlaftormer2D {

	// This scripts handles the enemy's health.

		public class EnemyHealthManager_Mobile : MonoBehaviour {
		public GameObject[] demageParticles;
		public Animator enemyAnim;
		//public static bool isFire=true;
		[Range(0, 100)] // Slide Bar.
		public int enemyHealth = 4; // The health amount of the enemy.
		public GameObject deathEffect; // the instantiated particles when the enemy dies.
		[Range(0, 1000)] // Slide Bar.
		public int pointsOnDeath = 100; // score recieved when kill an enemy.
		public AudioClip knockBackSfx; // the sound emited whenever the enemy is damaged.
		[Range(0.0f, 5.0f)] // Slide bar.
		public float knockBackSfxVolume = 1f; // the sound effect volume.
		[Range(0.0f, 5.0f)] 
		private float    _flashSpeed = 0.5f; // the time to wait since the sprite component is disabled and until is enabled again.
		[Range(0.0f, 5.0f)] 
		private float _lengthOfTimeToFlash = 0.1f; // The lenght of the flash 
		private static Shake_Mobile shakeController;
		public GameObject catEnemy;

		public Scene scene;
		private void Start()
        {
			scene = SceneManager.GetActiveScene();
			if (this.gameObject.name=="Boss")
            {
                //print(HealthBar.instance.name);
                HealthBar.instance.slider.maxValue = enemyHealth;
                HealthBar.instance.slider.value = enemyHealth;
            }
			
			//isFire = true;
			enemyAnim =GetComponent<Animator>();
		}
		// Update is called once per frame
		void Update()
		{
		}
/*		public void AnimationEvent()
        {
			//EnemiesTarget.isEnemyFire = true;
			Debug.Log("Aniamtion");
        }*/
		void FixedUpdate () {
			
			if (enemyHealth <= 0) {
               /* if (this.gameObject.name == ("Boss"))
                {
					HealthBar.instance.slider.maxValue = enemyHealth;
					HealthBar.instance.slider.value = enemyHealth;
				}*/
                enemyAnim.SetBool("isDead",true);
				catEnemy.transform.localScale = new Vector3(1, 0.3f, 1);
				StartCoroutine(DestroyObject());
				ScoreManager_Mobile.AddPoints(pointsOnDeath); // we add some points to the score counter.
				

			}
	
      } 
        public void giveDamage(int damageToGive)
	{
			enemyHealth -= damageToGive; // substract the enemy energy.
			//shakeController.ShakeCamera(0.3f, 0.3f); // This will shake the camera when the player takes damage.
			HealthBar.instance.slider.value = enemyHealth;
			AudioSource.PlayClipAtPoint (knockBackSfx, Camera.main.transform.position, knockBackSfxVolume); // the sound we use whenever the enemy recieves an impact.
			StartCoroutine(Flash(_flashSpeed, _lengthOfTimeToFlash)); // we activate the flash coroutine to make the enemy flash.
			if(this.gameObject.name=="Boss")
            {
				foreach (GameObject demage in demageParticles)
                {
					demage.SetActive(true);

				}
               
			}
		}


		// This enumerator will make the enemy flash when receiving a fireball impact.
		IEnumerator Flash(float duration, float blinkTime)	{

		
			duration -= Time.deltaTime;

			//toggle Sprite renderer off
			GetComponent<Renderer> ().enabled = false;
			//wait for a bit
			yield return new WaitForSeconds (blinkTime);
			//toggle Sprite renderer on
			GetComponent<Renderer> ().enabled = true;
			yield return new WaitForSeconds (blinkTime);
			GetComponent<Renderer> ().enabled = false;
			yield return new WaitForSeconds (blinkTime);
			GetComponent<Renderer> ().enabled = true;
			yield return new WaitForSeconds (blinkTime);
			GetComponent<Renderer> ().enabled = false;
			yield return new WaitForSeconds (blinkTime);
			GetComponent<Renderer> ().enabled = true;

        }
		IEnumerator DestroyObject()
        {
			if(this.gameObject.name==("Boss"))
            {
				HealthBar.instance.slider.value = enemyHealth;
				/*
				SoundManager.instance.bettleZone.enabled = false;
				SoundManager.instance.gamePlay.enabled = true;*/
				//isFire = false;
				foreach (Collider2D col in GetComponents<Collider2D>())
				{
					col.enabled = false;
				}
				this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
				GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
				this.gameObject.GetComponent<HurtPlayerOnContact_Mobile>().enabled = false;
				if (scene.name == "Level 2_Mobile")
				{
					this.gameObject.GetComponent<Transform>().position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 7 * Time.deltaTime * 0.3f);

				}
                if (scene.name == "Level 5_Mobile")
                {
					this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
					this.GetComponent<FlyingEnemiesGroup_Mobile>().enabled = false;
                }
                FirePooling.instance.RemoveFirePool();
				yield return new WaitForSeconds(3);
				Destroy(gameObject);// finally destroy this object.
				Instantiate(deathEffect, transform.position, transform.rotation); // if the enemy dies we instantiate the death effect particles.
			}
			if(this.gameObject.name==("Enemy"))
            {
				yield return new WaitForSeconds(0);
				Destroy(gameObject);// finally destroy this object.
				Instantiate(deathEffect, transform.position, transform.rotation); // if the enemy dies we instantiate the death effect particles.
			}
		}
		private void OnTriggerStay2D(Collider2D collision)
		{

			if (GorillaThrowRocks.instance.isAnimationChange)
			{
				enemyAnim.SetBool("isEnemyFire", true);
				//StartCoroutine(GorillaThrowRocks.instance.FireRate());
			}
		}
		private void OnTriggerExit2D(Collider2D collision)
		{
			if (!GorillaThrowRocks.instance.isAnimationChange)
			{
				enemyAnim.SetBool("isEnemyFire", false);
				//FirePooling.instance.RemoveFirePool();
			}
		}

	}
	
}


///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////