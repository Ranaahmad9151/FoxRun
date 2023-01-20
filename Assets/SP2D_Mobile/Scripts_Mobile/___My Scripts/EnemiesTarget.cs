﻿using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
namespace Bitboys.SuperPlaftormer2D
{
    public class EnemiesTarget : MonoBehaviour
    {
        public static EnemiesTarget instance;
        public Transform bulletPosition;
        public bool isMoveRight;
        public bool isAnimationChange;
        public FirePooling enemyFire;
        public Scene scene;
        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            scene = SceneManager.GetActiveScene();
        }

        // Update is called once per frame
        void Update()
        {
        }
        public void IsEnemyFire()
        {

            StartCoroutine(FireRate());

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                enemyFire = this.GetComponentInParent<FirePooling>();
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {

            if (collision.gameObject.tag == "Player")
            {

                isAnimationChange = true;
                IsEnemyFire();
            }
            //if (scene.name == "Level 1_Mobile")
            //{
            //    IsEnemyFire();
            //}
            //if (scene.name == "Level 2_Mobile")
            //{

            //    IsEnemyFire();

            //}
            //if (scene.name == "Level 3_Mobile")
            //{
            //    IsEnemyFire();
            //}
            //if (scene.name == "Level 4_Mobile")
            //{
            //    IsEnemyFire();

            //}
            //if (scene.name == "Level 5_Mobile")
            //{
            //    IsEnemyFire();

            //}

        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                isAnimationChange = false;
                FirePooling.instance.RemoveFirePool();

            }
        }
        public IEnumerator FireRate()
        {
            //isEnemyFire = true;
            GameObject bullet = enemyFire.GetFirePool();
            //GameObject bullet = FirePooling.instance.GetFirePool();
            if (bullet != null /*&& EnemyHealthManager_Mobile.isFire == true*/)
            {
               // yield return new WaitForSeconds(0.9f);
                //EnemyJump();
                yield return new WaitForSeconds(0.7f);
                print("bullet.transform.position" + bullet.name);
                print("bulletPosition" + bulletPosition.name);

                bullet.transform.position = bulletPosition.position;
                //FirePooling.instance.RemoveFirePool();
                /*if (isMoveRight == true)
                {
                    bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;
                    // EnemyHealthManager.enemyAnim.SetBool("isEnemyFire", true);
                }
                else
                {
                    bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * 10;
                    // EnemyHealthManager.enemyAnim.SetBool("isEnemyFire", true);
                }*/

                bullet.SetActive(true);

            }
        }

    }
}