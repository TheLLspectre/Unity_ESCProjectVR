using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TheRed.UI.Keyboard
{
    [AddComponentMenu("TheRed/UI/Virtual Keyboard/VK_Instantiation")]
    public class VK_Instantiation : MonoBehaviour
    {
        #region Public Fields

        public GameObject VirtualKeyboardPrefab;
        public GameObject SceneVirtualKeyboard;

        #endregion

        #region Private Fields

        private GameObject virtualKeyboard = null;
        private VirtualKeyboard vk = null;

        #endregion

        #region MonoBehaviour Callbacks

        #endregion

        #region Public Methods

        public void SelectTMPInput()
        {
            if (SceneVirtualKeyboard != null)
            {
                virtualKeyboard = SceneVirtualKeyboard;
                virtualKeyboard.SetActive(true);
            }
            else
            {
                virtualKeyboard = Instantiate(VirtualKeyboardPrefab, this.transform.parent) as GameObject;
            }
            
            vk = virtualKeyboard.GetComponent<VirtualKeyboard>();
            vk._VK_Instantiation = this;
            vk.IField = this.GetComponent<TMP_InputField>();
            vk.ActualiseKeyboard();
            Debug.Log("Actualise");
        }

        public void DeselectTMPInput()
        {
            if (SceneVirtualKeyboard != null && virtualKeyboard != null)
            {
                virtualKeyboard.SetActive(false);
                vk._VK_Instantiation = null;
                vk = null;
                virtualKeyboard = null;
            }
            else
            {
                Destroy(virtualKeyboard);
            }
        }

        #endregion

        #region Private Methods
        #endregion
    }
}