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
                isAnimationChange = false;
                FirePooling.instance.RemoveFirePool();
            }
        }
        public IEnumerator FireRate()
        {
            GameObject bullet = bossFire.GetFirePool();
            if (bullet != null)
            {
                yield return new WaitForSeconds(0.9f);
                yield return new WaitForSeconds(0.07f);
                bullet.transform.position = bulletPosition.position;
                bullet.SetActive(true);

            }
        }
    }
}