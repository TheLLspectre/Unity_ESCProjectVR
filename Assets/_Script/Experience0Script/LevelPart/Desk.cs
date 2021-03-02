/* Copyright 2021
 * author: LEROUGE Ludovic
 * TheRed Games FrameWorkRed
 * All rights reserved
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheRed.Experience0.Desk
{
    [AddComponentMenu("TheRed/Experience0/Desk")]
    public class Desk : MonoBehaviour
    {
        #region Public Fields

        public GameObject ButtonDesk;

        public bool IsPressed { get { return isPressed; } }

        public delegate void OnButtonDeskPressedHandler(GameObject go);
        public event OnButtonDeskPressedHandler OnButtonDeskPressedAction;

        #endregion

        #region Private Fields

        private Animator anim;
        [SerializeField]
        private bool isPressed = false;

        #endregion

        #region MonoBehaviour Callbacks

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        #endregion

        #region Public Methods

        public void PushButton()
        {
            if (!isPressed)
            {
                this.isPressed = true;
                anim.SetBool("Pressed", this.isPressed);
                if (OnButtonDeskPressedAction != null)
                    OnButtonDeskPressedAction(this.gameObject);
            }
            else 
            {
                this.isPressed = false;
                anim.SetBool("Pressed", this.isPressed);
                if (OnButtonDeskPressedAction != null)
                    OnButtonDeskPressedAction(this.gameObject);
            }
        }

        #endregion

        #region Private Methods
        #endregion
    }
}