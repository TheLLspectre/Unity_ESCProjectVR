using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TRG = TheRed.Player.Controller;


namespace TheRed.Interactable
{
    public class TriggerDialogManager : MonoBehaviour
    {
        #region Public Fields

        public TriggerDialog[] TriggerDialogObjects;
        public TriggerDialog ActiveTriggerDialog;

        public delegate void OnActiveTriggerDialogHandler(string partToDisplay);
        public static event OnActiveTriggerDialogHandler OnActiveTriggerDialog;

        #endregion

        #region Private Fields

        private GameObject activeGOTrigger = null;

        #endregion

        #region MonoBehaviour Callbacks

        private void OnEnable()
        {
            if (TriggerDialogObjects.Length != 0)
            {
                for (int i = 0; i < TriggerDialogObjects.Length; i++)
                {
                    if (TriggerDialogObjects[i] != null)
                    {
                        TriggerDialogObjects[i].OnTriggerDialogEvent += OnTriggerDialogEvent;
                        TriggerDialogObjects[i].OnTriggerDialogExitEvent += OnTriggerDialogExitEvent;
                    }
                }
                TRG.PlayerController.OnTriggerAndPressed += OnTriggerAndPressed;
            }
        }

        private void OnDisable()
        {
            if (TriggerDialogObjects.Length != 0)
            {
                for (int i = 0; i < TriggerDialogObjects.Length; i++)
                {
                    if (TriggerDialogObjects[i] != null)
                    {
                        TriggerDialogObjects[i].OnTriggerDialogEvent -= OnTriggerDialogEvent;
                        TriggerDialogObjects[i].OnTriggerDialogExitEvent -= OnTriggerDialogExitEvent;
                    }
                        
                }
                TRG.PlayerController.OnTriggerAndPressed -= OnTriggerAndPressed;
            }
        }

        #endregion

        #region Private Callbacks

        private void OnTriggerAndPressed()
        {
            ActiveTriggerDialog.OnTriggerAndPressed();
        }

        private void OnTriggerDialogEvent(TriggerDialog td, string partToDisplay)
        {
            if (ActiveTriggerDialog != td)
            {
                ActiveTriggerDialog = td;
                if (OnActiveTriggerDialog != null)
                    OnActiveTriggerDialog(partToDisplay);
            }
            else
            {
                if (OnActiveTriggerDialog != null)
                    OnActiveTriggerDialog(partToDisplay);
            }
        }

        private void OnTriggerDialogExitEvent()
        {
            ActiveTriggerDialog = null;
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}