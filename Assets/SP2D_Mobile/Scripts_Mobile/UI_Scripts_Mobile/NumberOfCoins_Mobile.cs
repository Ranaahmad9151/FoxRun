using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening.Core.Easing;

namespace Bitboys.SuperPlaftormer2D
{

    // This script stores the amount of tokens that the player collects.

    public class NumberOfCoins_Mobile : MonoBehaviour
    {

        public static int score;
        public static int healthRegenerateCoinCounter;
        public static ParticleSystem healthParticle;
        public ParticleSystem healthParticleReference;

        Text text;

        void Start()
        {
            /*if (PlayerPrefs.HasKey("PlayerLive"))
            {
                GameManager.instance.livesCountText.text = PlayerPrefs.GetInt("PlayerLive").ToString();
            }
            else
            {
                PlayerPrefs.SetInt("PlayerLive", 5);
                GameManager.instance.livesCountText.text = PlayerPrefs.GetInt("PlayerLive").ToString();
            }*/
            text = GetComponent<Text>();
            score = PlayerPrefs.GetInt("Coins");
            //score = 0;
            healthParticleReference= GameObject.Find("HealthParticle").GetComponent<ParticleSystem>();
            healthParticle = healthParticleReference;
        }

        void Update()
        {
            if (score < 0)
                score = 0;
            text.text = "" + score;
        }
        public static void AddPoints(int NumberOfCoins)
        {

            healthRegenerateCoinCounter += NumberOfCoins;
            print("Counter: " + healthRegenerateCoinCounter);
            if (healthRegenerateCoinCounter % 10 == 0)
            {
                HealthManager_Mobile.currentHealth += 0.5f;
                healthParticle.Play();
            }
            score += NumberOfCoins;

            score = PlayerPrefs.GetInt("Coins") + NumberOfCoins;
            PlayerPrefs.SetInt("Coins", score);
            print("Score below: " + score);

        }
        public static void Reset()
        {
            score = 0;
        }

        public void HealthDecreaseTest()
        {
            HealthManager_Mobile.currentHealth -= 0.5f;
        }

        public void HealthIncreaseTest()
        {
            HealthManager_Mobile.currentHealth += 0.5f;
            healthParticle.Play();
        }

    }
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// SUPER PLATFORMER 2D By Bitboys //////////////////////////////////////////////////////////////////////////////////////////////////////