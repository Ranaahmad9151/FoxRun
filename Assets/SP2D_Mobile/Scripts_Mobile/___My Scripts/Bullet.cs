using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bitboys.SuperPlaftormer2D
{
    public class Bullet : MonoBehaviour
    {
        private float speed = 10;
        public Rigidbody2D rb;
        public float lifetime= 10f;
        // Start is called before the first frame update
        void Start()
        {

        }
        // Update is called once per frame
        void Update()
        {
            
        }




        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == ("Player"))
            {
                HurtPlayerOnContact_Mobile.shakeController.ShakeCamera(0.5f, 0.5f);
                HealthManager_Mobile.HurtPlayer(HurtPlayerOnContact_Mobile.damageToGive);
                this.gameObject.SetActive(false);
            }
        }
    }
}