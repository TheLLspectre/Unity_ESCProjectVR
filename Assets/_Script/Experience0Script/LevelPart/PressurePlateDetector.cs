/* Copyright 2021
 * author: LEROUGE Ludovic
 * TheRed Games FrameWorkRed
 * All rights reserved
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheRed.Experience0.PressurePlate
{
    [RequireComponent(typeof(Rigidbody), typeof(ConstantForce))]
    [AddComponentMenu("TheRed/Experience0/LevelPart/PressurePlateDetector")]
    public class PressurePlateDetector : MonoBehaviour
    {
        #region Public Fields
        public LayerMask layerAllowed;

        public bool Return = false;

        public delegate void OnPressurePlatePressedHandler(PressurePlateDetector ppd);
        public event OnPressurePlatePressedHandler OnPressurePlatePressedAction;
        #endregion

        #region Private Fields
        private ConstantForce cForce;

        private float maxForce = 50.0f;
        private float minForce = 0.0f;

        private bool isPressed = false;
        #endregion

        #region MonoBehaviour Callbacks

        void Start()
        {
            cForce = GetComponent<ConstantForce>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if ((1<other.gameObject.layer) & layerAllowed != 0) //  ***go see TriggerDialog script to the correct way TODO ****
            {
                cForce.force = new Vector3(0, minForce, 0);
                isPressed = true;

                if (OnPressurePlatePressedAction != null)
                    OnPressurePlatePressedAction(this);
            }
        }

        /*private void OnTriggerStay(Collider other)
        {
            
        }*/

        private void OnTriggerExit(Collider other)
        {
            if (Return)
            {
                if ((1 < other.gameObject.layer) & layerAllowed != 0)
                {
                    cForce.force = new Vector3(0, maxForce, 0);
                    isPressed = false;
                }
            }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}