using UnityEngine;
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
            GameObject bullet = enemyFire.GetFirePool();
            if (bullet != null)
            {
                yield return new WaitForSeconds(0.7f);
                bullet.transform.position = bulletPosition.position;

                bullet.SetActive(true);

            }
        }

    }
}