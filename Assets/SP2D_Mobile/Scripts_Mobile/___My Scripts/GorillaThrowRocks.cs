using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Bitboys.SuperPlaftormer2D
{

    public class GorillaThrowRocks : MonoBehaviour
    {
        public static GorillaThrowRocks instance;
        public Transform bulletPosition;
        public bool isMoveRight;
        public bool isAnimationChange;
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

            StartCoroutine(GorillaThrowRocks.instance.FireRate());

        }
        private void OnTriggerStay2D(Collider2D collision)
        {

            if (collision.gameObject.tag == "Player")
            {
                
                isAnimationChange = true;
                }
                if (scene.name== "Level 1_Mobile")
                {
                StartCoroutine(GorillaThrowRocks.instance.FireRate());
                 }
                if (scene.name == "Level 2_Mobile")
                {
                    IsEnemyFire();

                }
                if (scene.name== "Level 3_Mobile")
                {
                    IsEnemyFire();

                }
                if (scene.name== "Level 4_Mobile")
                {
                    IsEnemyFire();

                }
                if (scene.name== "Level 5_Mobile")
                {
                    IsEnemyFire();

                }
        
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
            GameObject bullet = FirePooling.instance.GetFirePool();
            if (bullet != null /*&& EnemyHealthManager_Mobile.isFire == true*/)
            {
                yield return new WaitForSeconds(0.9f);
                //EnemyJump();
                yield return new WaitForSeconds(0.07f);
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