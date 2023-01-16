using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bitboys.SuperPlaftormer2D
{

    public class BoundDeadKill : MonoBehaviour
    {
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
                HealthManager_Mobile.currentHealth = 0;
            }
        }
    }
}