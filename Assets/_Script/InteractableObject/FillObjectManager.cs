/* Copyright 2021
 * author: LEROUGE Ludovic
 * TheRed Games FrameWorkRed
 * All rights reserved
 */
using System.Collections;
using System.Collections.Generic;
using TheRed.Interactable;
using UnityEngine;

namespace TheRed.Objects
{
    [AddComponentMenu("TheRed/Interactable/FillObjectManager")]
    public class FillObjectManager : MonoBehaviour
    {
        #region Public Fields

        public List<GameObject> ListFillObject;
        public TriggerDialog FirstTrigger;

        // Event when all the object are filled
        public delegate void OnAllObjectFilledHandler();
        public event OnAllObjectFilledHandler OnAllObjectFilled;

        // Event when the first object is filled it doesn't matter which one it is.
        public delegate void OnFirstObjectFilledHandler();
        public event OnFirstObjectFilledHandler OnFirstObjectFilled;

        #endregion

        #region Private Fields

        private int count = 0;
        private bool[] listFilledObject;
        private bool allFilled = false;

        #endregion

        #region MonoBehaviour Callbacks

        // Start is called before the first frame update
        void Start()
        {
            listFilledObject = new bool[ListFillObject.Count]; // create a new boolean array with the side of object listenning.
        }

        // Update is called once per frame
        void Update()
        {

        }

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

        private void OnObjectFilled(GameObject go)
        {
            if (ListFillObject.Contains(go))
            {
                listFilledObject[ListFillObject.IndexOf(go)] = true;
                if (count == 0)
                {
                    Debug.Log("OnFirstObjectFilled() Launched", go);
                    if (OnFirstObjectFilled != null)
                        OnFirstObjectFilled();
                }
                if(count <= listFilledObject.Length)
                    count++;
            }

            allFilled = CheckAllFilled();
        }

        private void FirstObjectFilled()
        {
            FirstTrigger.OnTrigger(FirstTrigger);
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods

        private void SubscribeEvent()
        {
            if (ListFillObject.Count > 0)
            {
                foreach (GameObject go in ListFillObject)
                {
                    if(go != null)
                        go.GetComponent<FillObject>().OnObjectFilled += OnObjectFilled;
                }
                this.OnFirstObjectFilled += FirstObjectFilled;
            }
        }

        private void UnsubscribeEvent()
        {
            if (ListFillObject.Count > 0)
            {
                foreach (GameObject go in ListFillObject)
                {
                    if(go != null)
                        go.GetComponent<FillObject>().OnObjectFilled += OnObjectFilled;
                }
                this.OnFirstObjectFilled -= FirstObjectFilled;
            }
        }

        /// <summary>
        /// Check if all empty object are filled with the missing part.
        /// </summary>
        /// <returns> True or false </returns>
        private bool CheckAllFilled()
        {
            if (listFilledObject.Length > 0) // If the array is not empty
            {
                for (int i = 0; i < listFilledObject.Length; i++) // Check every part inside the array
                    if (!listFilledObject[i]) // If the state is false
                        return false; // return false
                if (OnAllObjectFilled != null)
                    OnAllObjectFilled();
                return true;
            }
            return false;
        }

        #endregion
    }
}