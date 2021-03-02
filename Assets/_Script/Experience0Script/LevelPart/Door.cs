/* Copyright 2021
 * author: LEROUGE Ludovic
 * TheRed Games FrameWorkRed
 * All rights reserved
 */
using System.Threading;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using TheRed.Experience0.TargetToLook;
using TheRed.Experience0.PressurePlate;
using UnityEngine;
using TheRed.Objects;

namespace TheRed.Experience0.Level
{
    [AddComponentMenu("TheRed/Experience0/LevelPart/Door")]
    public class Door : MonoBehaviour
    {
        #region Public Fields

        public GameObject objectToSub;

        #endregion

        #region Private Fields

        private Animator anim;
        [SerializeField]
        private bool openDoor = false;
        
        #endregion

        #region MonoBehaviour Callbacks

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            //Subscribe to event
            if(objectToSub.GetComponent<TargetToLookManager>())
                objectToSub.GetComponent<TargetToLookManager>().OnAllTargetDestroyedAction += OnAllTargetDestroy;
            if(objectToSub.GetComponent<PressurePlateManager>())
                objectToSub.GetComponent<PressurePlateManager>().OnAllPlatePressedAction += OnAllPlatePressed;
            if (objectToSub.GetComponent<MultiSubscriber>())
            {
                objectToSub.GetComponent<MultiSubscriber>().OnAllSubCheck += OnAllSubCheck;
                objectToSub.GetComponent<MultiSubscriber>().OnNotAllSubCheck += OnNotAllSubCheck;
            }
        }

        private void OnDisable()
        {
            //Unsubscribe event
            if(objectToSub.GetComponent<TargetToLookManager>())
                objectToSub.GetComponent<TargetToLookManager>().OnAllTargetDestroyedAction -= OnAllTargetDestroy;
            if(objectToSub.GetComponent<PressurePlateManager>())
                objectToSub.GetComponent<PressurePlateManager>().OnAllPlatePressedAction -= OnAllPlatePressed;
            if (objectToSub.GetComponent<MultiSubscriber>())
            {
                objectToSub.GetComponent<MultiSubscriber>().OnAllSubCheck -= OnAllSubCheck;
                objectToSub.GetComponent<MultiSubscriber>().OnNotAllSubCheck -= OnNotAllSubCheck;
            }
        }

        #endregion

        #region Private Callbacks

        private void OnAllPlatePressed()
        {
            this.openDoor = true;
            anim.SetBool("Open", this.openDoor);
        }

        private void OnAllTargetDestroy()
        {
            this.openDoor = true;
            anim.SetBool("Open", openDoor);
        }

        private void OnAllSubCheck()
        {
            this.openDoor = true;
            anim.SetBool("Open", openDoor);
        }

        private void OnNotAllSubCheck()
        {
            this.openDoor = false;
            anim.SetBool("Open", openDoor);
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}