using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bitboys.SuperPlaftormer2D
{
    public class BattleSound : MonoBehaviour
    {
        public AudioSource bettleZoneSound;
        public AudioSource gamePlaySound;
        // Start is called before the first frame update
        void Start()
        {
            gamePlaySound.Play();
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                bettleZoneSound.Play();
                gamePlaySound.Pause();
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                bettleZoneSound.Pause();
                gamePlaySound.Play();
            }
        }
    }
}