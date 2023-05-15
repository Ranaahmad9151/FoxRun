using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Bitboys.SuperPlaftormer2D
{

    // This scripts handles the player's health.

    public class HealthManager_Mobile : MonoBehaviour
    {

        public static float currentHealth;// The health amount of the player.
        public int maxPlayerHealth; // the max health that the player may have.
        public float healthBarSpeed; // the speed of the ui health bar sprite.
        private LevelManager_Mobile levelManager; // the reference to can communicate with the level manager script.
        public bool isDead; // this will be activated when player dies.
        private LifeManager_Mobile lifeSystem;// the reference to can communicate with the life manager script.
        public Image visualHealth;// the ui image that will show the amount of health of the player.
        private EnergyAnim_Mobile energy;



        void Start()
        {

            visualHealth = GetComponent<Image>();
            currentHealth = maxPlayerHealth;
            levelManager = FindObjectOfType<LevelManager_Mobile>();
            lifeSystem = FindObjectOfType<LifeManager_Mobile>();
            isDead = false; // When the scene starts we insure that the player is not dead.
            energy = FindObjectOfType<EnergyAnim_Mobile>();
        }


        void Update()
        {

            HandleHealthBar();
            if (currentHealth <= 0 && !isDead)
            {
                int life = PlayerPrefs.GetInt("PlayerCurrentLives");
                if (life > 0)
                {
                    currentHealth = 0;
                    levelManager.RespawnPlayer();
                    lifeSystem.TakeLife();
                    isDead = true;
                }

                else
                {
                    StartCoroutine(FindObjectOfType<LifeManager_Mobile>().ShowLevelFailDailogBox());
                }
            }


            if (currentHealth <= 1 && !isDead)
            {
                energy.healtDown = true;
            }
            else
            {
                energy.healtDown = false;

            }

            //if(PlayerPrefs.GetInt("Coins") > 10)
            //{
            //    healthRegenerateCoinCounter = 0;
            //}

            if (currentHealth >= 10 && !isDead)
            {
                currentHealth = 10;
            }

        }

        public static void HurtPlayer(float damageToGive)
        {
            currentHealth -= damageToGive; // the player current health can only be less or equal to the damage it recieves. Therefore we will use this variable whenever we want that the player recieves damage.
            print("Current Health: " + currentHealth);
        }
        public void FullHealth()
        {
            currentHealth = maxPlayerHealth;  // we use this variable when we wants the player's health regenerates completely.
        }
        public void KillPlayer()
        {
            currentHealth = 0; // if the player health is equal to zero this variable will be activated.
        }
        public static void AddHealth(int healthToAdd)
        {
            currentHealth += healthToAdd; // we use this variable to add health to the amount of health that the player already have.
        }
        private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
        {
            return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }
        private void HandleHealthBar()
        {
            float currentValue = MapValues(currentHealth, 0, maxPlayerHealth, 0, 1); // this formula manages the ui health bar movement.

            visualHealth.fillAmount = Mathf.Lerp(visualHealth.fillAmount, currentValue, Time.deltaTime * healthBarSpeed);
        }
    }
}
///////////////////////////////////////////////////////////////// SUPER PLATFORMER 2D by Bitboys ///////////////////////////////////////////////////////////////////////////////////////////////

