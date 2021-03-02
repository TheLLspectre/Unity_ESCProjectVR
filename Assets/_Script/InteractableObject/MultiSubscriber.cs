using System.Collections;
using System.Collections.Generic;
using TheRed.Experience0.Desk;
using TheRed.Experience0.PressurePlate;
using TheRed.Experience0.TargetToLook;
using UnityEngine;

namespace TheRed.Objects
{
    [AddComponentMenu("TheRed/Interactable/MultiSubscriber")]
    public class MultiSubscriber : MonoBehaviour
    {
        #region Public Fields

        public GameObject[] listToSub;

        public delegate void OnAllSubCheckHandler();
        public event OnAllSubCheckHandler OnAllSubCheck;

        public delegate void OnNotAllSubCheckHandler();
        public event OnNotAllSubCheckHandler OnNotAllSubCheck;

        #endregion

        #region Private Fields

        private bool[] listBoolean;

        #endregion

        #region MonoBehaviour Callbacks

        private void OnEnable()
        {
            SubscribeEvent();
        }

        private void OnDisable()
        {
            UnsubscribeEvent();
        }

        #endregion

        #region Private Callbacks

        private void OnAllPlatePressed()
        {
            for (int i = 0; i < listToSub.Length; i++)
            {
                if (listToSub[i].GetComponent<PressurePlateManager>())
                {
                    listBoolean[i] = true;
                }
            }

            CheckAllBoolean();
        }

        private void OnAllPressedButton()
        {
            for (int i = 0; i < listToSub.Length; i++)
            {
                if (listToSub[i].GetComponent<DeskManager>())
                {
                    listBoolean[i] = true;
                }
            }

            CheckAllBoolean();
        }

        private void OnNotAllPressedButton()
        {
            for (int i = 0; i < listToSub.Length; i++)
            {
                if (listToSub[i].GetComponent<DeskManager>())
                {
                    listBoolean[i] = false;
                }
            }

            CheckAllBoolean();
        }

        private void OnAllTargetDestroyed()
        {
            for (int i = 0; i < listToSub.Length; i++)
            {
                if (listToSub[i].GetComponent<TargetToLookManager>())
                {
                    listBoolean[i] = true;
                }
            }

            CheckAllBoolean();
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods

        private void SubscribeEvent()
        {
            if (listToSub.Length > 0)
            {
                listBoolean = new bool[listToSub.Length];
                for (int i = 0; i < listToSub.Length; i++)
                {
                    listBoolean[i] = false;
                    if (listToSub[i].GetComponent<PressurePlateManager>())
                    {
                        listToSub[i].GetComponent<PressurePlateManager>().OnAllPlatePressedAction += OnAllPlatePressed;
                    }
                    else if (listToSub[i].GetComponent<DeskManager>())
                    {
                        listToSub[i].GetComponent<DeskManager>().OnAllPressedButtonAction += OnAllPressedButton;
                        listToSub[i].GetComponent<DeskManager>().OnNotAllPressedButtonAction += OnNotAllPressedButton;
                    }
                    else if (listToSub[i].GetComponent<TargetToLookManager>())
                    {
                        listToSub[i].GetComponent<TargetToLookManager>().OnAllTargetDestroyedAction += OnAllTargetDestroyed;
                    }
                }
            }
        }

        private void UnsubscribeEvent()
        {
            if (listToSub.Length > 0)
            {
                listBoolean = new bool[listToSub.Length];
                for (int i = 0; i < listToSub.Length; i++)
                {
                    listBoolean[i] = false;
                    if (listToSub[i].GetComponent<PressurePlateManager>())
                    {
                        listToSub[i].GetComponent<PressurePlateManager>().OnAllPlatePressedAction -= OnAllPlatePressed;
                    }
                    else if (listToSub[i].GetComponent<DeskManager>())
                    {
                        listToSub[i].GetComponent<DeskManager>().OnAllPressedButtonAction -= OnAllPressedButton;
                        listToSub[i].GetComponent<DeskManager>().OnNotAllPressedButtonAction -= OnNotAllPressedButton;
                    }
                    else if (listToSub[i].GetComponent<TargetToLookManager>())
                    {
                        listToSub[i].GetComponent<TargetToLookManager>().OnAllTargetDestroyedAction -= OnAllTargetDestroyed;
                    }
                }
            }
        }

        private void CheckAllBoolean()
        {
            for (int i = 0; i < listBoolean.Length; i++)
            {
                if (!listBoolean[i])
                {
                    if (OnNotAllSubCheck != null)
                        OnNotAllSubCheck();
                    return;
                }
            }
            if (OnAllSubCheck != null)
                OnAllSubCheck();
        }

        #endregion
    }
}