using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class ButtonHandler : MonoBehaviour
    {

        public string Name;
		public Sprite pressedButton;
		public Sprite nonPressedButton;

        void OnEnable()
        {
        }

        public void SetDownState()
        {
            CrossPlatformInputManager.SetButtonDown(Name);
			this.gameObject.GetComponent<Image> ().sprite = pressedButton;
            
        }


        public void SetUpState()
        {
            CrossPlatformInputManager.SetButtonUp(Name);
			this.gameObject.GetComponent<Image> ().sprite = nonPressedButton;

        }


        public void SetAxisPositiveState()
        {
            CrossPlatformInputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            CrossPlatformInputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            CrossPlatformInputManager.SetAxisNegative(Name);
        }

        public void Update()
        {

        }
    }
}
