using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Bitboys.SuperPlaftormer2D
{

    public class GorillaThrowRocks : MonoBehaviour
    {
        public static GorillaThrowRocks instance; 
        public GameObject demage;
        public Transform bulletPosition;
        public bool isMoveRight;
        public bool isAnimationChange;
        public Scene scene;
        public FirePooling bossFire;
        public AudioSource bettleZoneSound;
        public AudioSource gamePlaySound;
        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            gamePlaySound.Play();
            demage.SetActive(true);
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
                bettleZoneSound.Play();
                gamePlaySound.Pause();
                demage.SetActive(false);
                bossFire = this.GetComponentInParent<FirePooling>();
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {

            if (collision.gameObject.tag == "Player")
            {
                
                isAnimationChange = true;
                IsEnemyFire();
            }
            

        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                bettleZoneSound.Pause();
                gamePlaySound.Play();
                demage.SetActive(true);
                isAnimationChange = false;
                FirePooling.instance.RemoveFirePool();
            }
        }
        public IEnumerator FireRate()
        {
            GameObject bullet = bossFire.GetFirePool();
            if (bullet != null)
            {
                //yield return new WaitForSeconds(0.9f);
                yield return new WaitForSeconds(0.01f);
                bullet.transform.position = bulletPosition.position;

                if(!isMoveRight)
                {
                    bullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * 3, ForceMode2D.Impulse);
                    
                }
                else
                {
                    bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 3, ForceMode2D.Impulse);
                }
                bullet.SetActive(true);
            }
        }
    }
}