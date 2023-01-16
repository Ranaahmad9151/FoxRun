using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bitboys.SuperPlaftormer2D
{
    public class ButtonsScript : MonoBehaviour
    {
        public GameObject pausePanel;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void PausePanel()
        {
            PauseMenu_Mobile.instance.isPaused = true;
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        public void ResumePanel()
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }

    }
}