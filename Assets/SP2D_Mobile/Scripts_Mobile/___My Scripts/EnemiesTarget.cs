using UnityEngine;
using System.Collections;
using DG.Tweening;
namespace Bitboys.SuperPlaftormer2D
{
    public class EnemiesTarget : MonoBehaviour
    {
        public static EnemiesTarget instance;
        private EnemyHealthManager_Mobile EnemyHealthManager;
        public Transform bulletPosition;
        public static bool isMoveRight;
        public Transform gorilla;
        public Transform player;
        public static bool isEnemyFire=false;
        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
        }

        void Update()
        {
        
        }

        public void EnemyJump()
        {
            gorilla.transform.DOJump(new Vector2(230, 0), 1, 1, 3);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == ("Player"))
            {
                StartCoroutine(FireRate());
            }
        }
        public IEnumerator FireRate()
        {
            //isEnemyFire = true;
                yield return new WaitForSeconds(0.5f);
             GameObject bullet = FirePooling.instance.GetFirePool();
                bullet.transform.position = bulletPosition.position; 
            if (bullet != null/*&&EnemyHealthManager_Mobile.isFire==true*/)
            {
                Debug.Log("Force");
                /*yield return new WaitForSeconds(2);
                EnemyJump();*/
                bullet.SetActive(true);
                if (EnemyPatrol_Mobile.instance.moveRight/*isMoveRight == true*/)
                {
                  // bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(10,0 ), ForceMode2D.Impulse);
                    Debug.Log("ForceiNNER");
                   // bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;
                   // EnemyHealthManager.enemyAnim.SetBool("isEnemyFire", true);
                }
                else
                {
                    //bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0), ForceMode2D.Impulse);
                    // bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * 10;
                    // EnemyHealthManager.enemyAnim.SetBool("isEnemyFire", true);
                }


            }
        }


    }
}