/* Copyright 2021
 * author: LEROUGE Ludovic
 * TheRed Games FrameWorkRed
 * All rights reserved
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TheRed.Experience0.PressurePlate;

namespace TheRed.Experience0.PressurePlate
{
    [AddComponentMenu("TheRed/Experience0/LevelPart/PressurePlateManager")]
    public class PressurePlateManager : MonoBehaviour
    {
        #region Public Fields
        public List<GameObject> listPressurePlate = new List<GameObject>();

        public delegate void OnAllPlatePressedHandler();
        public event OnAllPlatePressedHandler OnAllPlatePressedAction;
        #endregion

        #region Private Fields

        private bool[] listActivationPlate;

        #endregion

        #region MonoBehaviour Callbacks

        private void OnEnable()
        {
            listActivationPlate = new bool[listPressurePlate.Count];
            SubscribeAllPressurePlateEvent();
        }

        private void OnDisable()
        {
            UnsubscribeAllPressuerPlateEvent();
        }

        #endregion

        #region Private Callbacks

        private void OnPressurePlatePressed(PressurePlateDetector ppd)
        {
            GameObject toFind = ppd.transform.parent.gameObject;

            for (int i = 0; i < listPressurePlate.Count; i++)
            {
                if (listPressurePlate.ElementAt(i) == toFind)
                {
                    listActivationPlate[i] = true;
                    break;
                }
            }

            if (CheckAllTrue())
            { 
                if(OnAllPlatePressedAction != null)
                    OnAllPlatePressedAction();
            }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods

        private bool CheckAllTrue()
        {
            for (int i = 0; i < listActivationPlate.Length; i++)
            {
                if (!listActivationPlate[i])
                    return false;
            }
            return true;
        }

        private void SubscribeAllPressurePlateEvent()
        {
            if (listPressurePlate.Count > 0)
            {
                foreach (GameObject go in listPressurePlate)
                {
                    if (go != null)
                    {
                        go.GetComponentInChildren<PressurePlateDetector>().OnPressurePlatePressedAction += OnPressurePlatePressed;
                        listActivationPlate[listPressurePlate.IndexOf(go)] = false;
                    }
                }
            }
        }

        private void UnsubscribeAllPressuerPlateEvent()
        {
            if (listPressurePlate.Count > 0)
            {
                foreach (GameObject go in listPressurePlate)
                {
                    if (go != null)
                    {
                        go.GetComponentInChildren<PressurePlateDetector>().OnPressurePlatePressedAction -= OnPressurePlatePressed;
                    }
                }
            }
        }

        #endregion
    }
}