/* Copyright 2021
 * author: LEROUGE Ludovic
 * TheRed Games FrameWorkRed
 * All rights reserved
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheRed.Experience0.TargetToLook
{
    [AddComponentMenu("TheRed/Experience0/TargetToLookManager")]
    public class TargetToLookManager : MonoBehaviour
    {
        #region Public Fields

        public List<GameObject> TargetToLookList;

        public delegate void OnAllTargetDestroyedHandler();
        public event OnAllTargetDestroyedHandler OnAllTargetDestroyedAction;

        #endregion

        #region Private Fields

        [SerializeField]
        private int destroyingCount = 0;
        private int lengthTargetToLookList = 0;
        [SerializeField]
        private bool isDone = false;

        #endregion

        #region MonoBehaviour Callbacks

        // Start is called before the first frame update
        void Start()
        {
            lengthTargetToLookList = TargetToLookList.Count;
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

        private void OnTargetToLookDestroy(TargetToLookObject ttlo)
        {
            ttlo.OnTargetToLookDestroyAction -= OnTargetToLookDestroy;
            destroyingCount += 1;
            if (destroyingCount == lengthTargetToLookList)
            {
                isDone = true;
                if (OnAllTargetDestroyedAction != null)
                    OnAllTargetDestroyedAction();
            }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods

        private void SubscribeEvent()
        {
            if (TargetToLookList.Count > 0)
            {
                foreach (GameObject target in TargetToLookList)
                {
                    target.GetComponent<TargetToLookObject>().OnTargetToLookDestroyAction += OnTargetToLookDestroy;
                }
            }
        }

        private void UnsubscribeEvent()
        {
            if (TargetToLookList.Count > 0)
            {
                foreach (GameObject target in TargetToLookList)
                {
                    if(target != null)
                        target.GetComponent<TargetToLookObject>().OnTargetToLookDestroyAction -= OnTargetToLookDestroy;
                }
            }
        }

        #endregion
    }
}