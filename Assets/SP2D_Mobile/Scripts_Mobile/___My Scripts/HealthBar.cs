using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Bitboys.SuperPlaftormer2D
{

    public class HealthBar : MonoBehaviour
    {
        public static HealthBar instance;
         private EnemyHealthManager_Mobile healthenemy;

        public Slider slider;
        public Color low;
        public Color high;
        public Vector3 offset;
        private void Awake()
        {
            instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
        }        

    }
}