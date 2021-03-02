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
    [AddComponentMenu("TheRed/Experience0/DeskManager")]
    public class DeskManager : MonoBehaviour
    {
        #region Public Fields

        public List<GameObject> listDesk = new List<GameObject>();

        public delegate void OnAllPressedButtonHandler();
        public event OnAllPressedButtonHandler OnAllPressedButtonAction;

        public delegate void OnNotAllPressedButtonHandler();
        public event OnNotAllPressedButtonHandler OnNotAllPressedButtonAction;

        #endregion

        #region Private Fields

        [SerializeField]
        private bool[] stateDeskButton;
        [SerializeField]
        private bool allActivated = false;

        #endregion

        #region MonoBehaviour Callbacks

        // Start is called before the first frame update
        void Start()
        {
            stateDeskButton = new bool[listDesk.Count];
        }

        private void LateUpdate()
        {
            allActivated = CheckAllPressed();
        }

        private void OnEnable()
        {
            if (listDesk.Count > 0)
            {
                foreach (GameObject go in listDesk)
                {
                    if (go != null)
                    {
                        Desk d = go.GetComponent<Desk>();
                        d.OnButtonDeskPressedAction += OnButtonDeskPressed;
                    }
                }
            }
        }

        private void OnDisable()
        {
            if (listDesk.Count > 0)
            {
                foreach (GameObject go in listDesk)
                {
                    if (go != null)
                    {
                        Desk d = go.GetComponent<Desk>();
                        d.OnButtonDeskPressedAction -= OnButtonDeskPressed;
                    }
                }
            }
        }

        #endregion

        #region Private Callbacks

        private void OnButtonDeskPressed(GameObject go)
        {
            if (listDesk.Contains(go))
            {
                stateDeskButton[listDesk.IndexOf(go)] = go.GetComponent<Desk>().IsPressed;
            }

            allActivated = CheckAllPressed();
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods

        public bool CheckAllPressed()
        {
            if (listDesk.Count > 0)
            {
                foreach (GameObject go in listDesk)
                {
                    if (go != null)
                    {
                        Desk d = go.GetComponent<Desk>();
                        if (!d.IsPressed)
                        {
                            if (OnNotAllPressedButtonAction != null)
                                OnNotAllPressedButtonAction();
                            return false;
                        }
                    }
                }
                if (OnAllPressedButtonAction != null)
                    OnAllPressedButtonAction();
                return true;
            }
            return false;
        }

        #endregion
    }
}