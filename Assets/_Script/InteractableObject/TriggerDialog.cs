using System.Collections;
using System.Collections.Generic;
using TheRed.Experience0.PressurePlate;
using TheRed.Experience0.TargetToLook;
using TheRed.Objects;
using UnityEngine;
using TRG = TheRed.Player.Controller;

namespace TheRed.Interactable
{
    [AddComponentMenu("TheRed/Interactable/TriggerDialog")]
    public class TriggerDialog : MonoBehaviour
    {
        #region Public Fields

        public LayerMask layer; // The layer to allow to be detected by the trigger.
        public GameObject ObjectToSub; // If you have to triggered it after an event.
        public string[] PartsToDisplay; // Linked to the part in the dialog file to display when you enter in the trigger or you pressed the button.
        [Tooltip("Need a boolean activate from the player state or an event.")]
        public bool SpecificActionFromPlayer = false; // Need a boolean activate from the player state.
        [Tooltip("When you doesn't need to trigger the box trigger.")]
        public bool IgnoreTrigger = false; // When you doesn't need to trigger the box trigger.

        // Event when the player enter in the trigger
        public delegate void OnTriggerDialogEnterHandler(TriggerDialog td, string partToDisplay);
        public event OnTriggerDialogEnterHandler OnTriggerDialogEvent;

        public delegate void OnTriggerDialogExitHandler();
        public event OnTriggerDialogExitHandler OnTriggerDialogExitEvent;

        public delegate void OnTriggerDialogNextPartHandler(string partToDisplay);
        public static event OnTriggerDialogNextPartHandler OnTriggerDialogNextPart;

        public delegate void OnTriggerDialogEmptyHandler();
        public static event OnTriggerDialogEmptyHandler OnTriggerDialogEmpty;

        #endregion

        #region Private Fields

        private int partFlag = 0;
        [SerializeField]
        private bool isTrigger = false;

        #endregion

        #region MonoBehaviour Callbacks

        private void OnEnable()
        {
            if (ObjectToSub != null)
            {
                if (ObjectToSub.GetComponent<TargetToLookManager>())
                {
                    ObjectToSub.GetComponent<TargetToLookManager>().OnAllTargetDestroyedAction += OnAllTargetDestroyed;
                }

                if (ObjectToSub.GetComponent<PressurePlateManager>())
                {
                    ObjectToSub.GetComponent<PressurePlateManager>().OnAllPlatePressedAction += OnAllPlatePressed;
                }

                if (ObjectToSub.GetComponent<FillObject>())
                {
                    ObjectToSub.GetComponent<FillObject>().OnObjectFilled += OnObjectFilled;
                }

                if (ObjectToSub.GetComponent<FillObjectManager>())
                {
                    ObjectToSub.GetComponent<FillObjectManager>().OnAllObjectFilled += OnAllObjectFilled;
                }

                if(ObjectToSub.tag.Equals("Object/ToTake"))
                    TRG.PlayerController.OnObjectTook += OnObjectTook;
            }
        }

        private void OnDisable()
        {
            if (ObjectToSub != null)
            {
                if (ObjectToSub.GetComponent<TargetToLookManager>())
                {
                    ObjectToSub.GetComponent<TargetToLookManager>().OnAllTargetDestroyedAction -= OnAllTargetDestroyed;
                }

                if (ObjectToSub.GetComponent<PressurePlateManager>())
                {
                    ObjectToSub.GetComponent<PressurePlateManager>().OnAllPlatePressedAction -= OnAllPlatePressed;
                }

                if (ObjectToSub.GetComponent<FillObject>())
                {
                    ObjectToSub.GetComponent<FillObject>().OnObjectFilled -= OnObjectFilled;
                }

                if (ObjectToSub.GetComponent<FillObjectManager>())
                {
                    ObjectToSub.GetComponent<FillObjectManager>().OnAllObjectFilled -= OnAllObjectFilled;
                }

                if (ObjectToSub.tag.Equals("Object/ToTake"))
                    TRG.PlayerController.OnObjectTook -= OnObjectTook;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            int layerInt = (1 << other.gameObject.layer); // Get the value of the player layer.
            if (layerInt == layer.value) // Be sure the layer allowed is equal to the layer player, only player can triggered this.
            {
                if (!SpecificActionFromPlayer)
                {
                    if (OnTriggerDialogEvent != null)
                    {
                        OnTriggerDialogEvent(this, PartsToDisplay[this.partFlag]);
                        this.isTrigger = true;
                    }
                }
                else
                {
                    if (!IgnoreTrigger)
                    {
                        if (other.gameObject.GetComponent<TRG.PlayerController>().ObjectHolded != null)
                        {
                            if (OnTriggerDialogEvent != null)
                            {
                                OnTriggerDialogEvent(this, PartsToDisplay[this.partFlag]);
                                this.isTrigger = true;
                            }
                        }
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            int layerInt = (1 << other.gameObject.layer); // Get the value of the player layer.
            if (layerInt == layer.value)
            {
                if (OnTriggerDialogExitEvent != null)
                    OnTriggerDialogExitEvent();
                SetTrigger();
            }
        }

        #endregion

        #region Private Callbacks

        private void OnAllObjectFilled()
        {
            if (OnTriggerDialogEvent != null)
                OnTriggerDialogEvent(this, PartsToDisplay[this.partFlag]);
            this.isTrigger = true;
        }

        private void OnObjectFilled(GameObject go)
        {
            if (go.GetComponent<TriggerDialog>())
            {
                if (OnTriggerDialogEvent != null)
                    OnTriggerDialogEvent(this, PartsToDisplay[this.partFlag]);
                this.isTrigger = true;
            }
        }

        private void OnObjectTook(GameObject interactableObject) // To Check
        {
            if (interactableObject.GetComponent<TriggerDialog>())
            {
                if (OnTriggerDialogEvent != null)
                    OnTriggerDialogEvent(this, PartsToDisplay[this.partFlag]);
                this.isTrigger = true;
            }
        }

        private void OnAllPlatePressed()
        {
            if (OnTriggerDialogEvent != null)
                OnTriggerDialogEvent(this, PartsToDisplay[this.partFlag]);
            this.isTrigger = true;
        }

        private void OnAllTargetDestroyed()
        {
            if (OnTriggerDialogEvent != null)
                OnTriggerDialogEvent(this, PartsToDisplay[this.partFlag]);
            this.isTrigger = true;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// When the player leave the trigger, it's own state change and it destroyed.
        /// </summary>
        public void SetTrigger()
        {
            if (isTrigger)
            {
                Destroy(this, 0.250f);
            }
        }

        public void OnTrigger(TriggerDialog td)
        {
            if (OnTriggerDialogEvent != null)
                OnTriggerDialogEvent(td, PartsToDisplay[td.partFlag]);
            this.isTrigger = true;
            SetTrigger();
        }

        public void OnTriggerAndPressed()
        {
            this.partFlag++;
            if (this.partFlag >= PartsToDisplay.Length)
            {
                if (OnTriggerDialogEmpty != null)
                    OnTriggerDialogEmpty();
            }
            else
            {
                if (OnTriggerDialogNextPart != null)
                    OnTriggerDialogNextPart(PartsToDisplay[this.partFlag]);
            }
        }

        #endregion

        #region Private Methods
        #endregion
    }
}