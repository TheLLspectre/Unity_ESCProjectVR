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
    [AddComponentMenu("TheRed/Interactable/FillObject")]
    public class FillObject : MonoBehaviour
    {
        #region Public Fields

        // Event when the object is filled
        public delegate void OnObjectFilledHandler(GameObject go);
        public event OnObjectFilledHandler OnObjectFilled;

        // Event to notify the interface this one is filled remove the display
        public delegate void OnObjectFilledDisplayHandler();
        public static event OnObjectFilledDisplayHandler OnObjectFilledDisplay;

        #endregion

        #region Private Fields

        private MeshRenderer meshRenderer;
        private Collider col;
        private Collider colTrigger;

        #endregion

        #region MonoBehaviour Callbacks

        private void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>(); // Get the component mesh renderer on this gameObject
            col = GetComponents<Collider>()[0]; // Get the first collider on this gameObject
            colTrigger = GetComponents<Collider>()[1]; // Get the second collider on this gameObject is the trigger one.
        }

        #endregion

        #region Public Methods

        public void Fill()
        {
            meshRenderer.enabled = true; // Activate the mesh disable at the beginning
            col.enabled = true; // Activate the collider disable at the beginning.
            colTrigger.enabled = false;

            if (OnObjectFilled != null) // Notify the event
                OnObjectFilled(this.gameObject);
            if (OnObjectFilledDisplay != null) // Notify the canvas manager mainly
                OnObjectFilledDisplay();
        }

        #endregion

        #region Private Methods
        #endregion
    }
}