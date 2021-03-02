/* Copyright 2021
 * author: LEROUGE Ludovic
 * TheRed Games FrameWorkRed
 * All rights reserved
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TheRed.Model;
using Photon.Pun;
using TheRed.Multiplayer;
using TRG = TheRed.Player.Controller;
using TheRed.Player.Camera;
using TheRed.Interactable;
using SimpleJSON;
using TheRed.Objects;

namespace TheRed.UI
{ 
    [AddComponentMenu("TheRed/Model/CanvasManager")]
    public class CanvasManager : MonoBehaviourPunCallbacks
    {
        #region Public Fields
        public static CanvasManager Instance; // Singleton of the canvas manager

        public static bool PauseAction { get { return pauseAction; } } // The pause state.

        public GameObject CanvasPlayerMenu; // The main menu of the game of the player.
        public GameObject CanvasPlayerInterface; // The interface of the player when the game is running.
        //public GameObject CanvasMultiplayerInterface; // The interface for all player in online mode, like for the feed.

        #endregion

        #region Private Fields

        private JSONNode dialogJson; // The dialog file to load according to the application langage system
        private static bool pauseAction = false; // false the game is running else if it's true the game is in pause.

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            /*if (Instance == null)
            {
                Instance = this;
                //DontDestroyOnLoad(this.gameObject);
            }
            /*else
            {
                Destroy(this.gameObject);
            }*/

            if (CanvasManager.Instance == null)
            {
                CanvasManager.Instance = this;
            }
            else
            {
                if (CanvasManager.Instance != this)
                {
                    Destroy(CanvasManager.Instance.gameObject);
                    CanvasManager.Instance = this;
                }
            }
            DontDestroyOnLoad(this.gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {
            CanvasPlayerMenu.SetActive(pauseAction); /// Disable the player menu at the beginning
            ReadNarrativeFile(); // Get the narrative file
        }

        private void OnEnable()
        {
            // Action Event in the world
            TRG.PlayerController.OnObjectEnterTrigger += OnObjectEnterTrigger;
            TRG.PlayerController.OnObjectExitTrigger += OnObjectExitTrigger;
            TRG.PlayerController.OnObjectTook += OnObjectTook;

            TRG.PlayerController.OnFillObjectEnterTrigger += OnFillObjectEnterTrigger;
            TRG.PlayerController.OnFillObjectExitTrigger += OnFillObjectExitTrigger;

            TRG.PlayerController.OnOpenObjectEnterTrigger += OnOpenObjectEnterTrigger;
            TRG.PlayerController.OnOpenObjectExitTrigger += OnOpenObjectExitTrigger;

            PlayerCamera.OnLookingToPressAction += OnLookingToPress;
            PlayerCamera.OnNotLookingToPressAction += OnNotLookingToPress;

            PlayerCamera.OnLookingToOpenAction += OnLookingToOpen;
            PlayerCamera.OnNotLookingToOpenAction += OnNotLookingToOpen;

            // Interface Action
            TRG.PlayerController.OnPauseButtonAction += OnPauseButtonAction;

            // Dialog Interface Text
            TriggerDialogManager.OnActiveTriggerDialog += OnTriggerDialogEvent;
            //TriggerDialog.OnTriggerDialogEvent += OnTriggerDialogEvent;
            TriggerDialog.OnTriggerDialogNextPart += OnTriggerDialogEvent;
            TriggerDialog.OnTriggerDialogEmpty += OnTriggerDialogEmpty;
            // From an Object Filled
            FillObject.OnObjectFilledDisplay += OnFillObjectExitTrigger;
        }

        private void OnDisable()
        {
            // Action Event in the world
            TRG.PlayerController.OnObjectEnterTrigger -= OnObjectEnterTrigger;
            TRG.PlayerController.OnObjectExitTrigger -= OnObjectExitTrigger;
            TRG.PlayerController.OnObjectTook -= OnObjectTook;

            TRG.PlayerController.OnFillObjectEnterTrigger -= OnFillObjectEnterTrigger;
            TRG.PlayerController.OnFillObjectExitTrigger -= OnFillObjectExitTrigger;

            TRG.PlayerController.OnOpenObjectEnterTrigger -= OnOpenObjectEnterTrigger;
            TRG.PlayerController.OnOpenObjectExitTrigger -= OnOpenObjectExitTrigger;

            PlayerCamera.OnLookingToPressAction -= OnLookingToPress;
            PlayerCamera.OnNotLookingToPressAction -= OnNotLookingToPress;

            PlayerCamera.OnLookingToOpenAction -= OnLookingToOpen;
            PlayerCamera.OnNotLookingToOpenAction -= OnNotLookingToOpen;

            // Interface Action
            TRG.PlayerController.OnPauseButtonAction -= OnPauseButtonAction;

            // Dialog Interface Text
            TriggerDialogManager.OnActiveTriggerDialog -= OnTriggerDialogEvent;
            TriggerDialog.OnTriggerDialogNextPart -= OnTriggerDialogEvent;
            TriggerDialog.OnTriggerDialogEmpty -= OnTriggerDialogEmpty;
            // From an Object Filled
            FillObject.OnObjectFilledDisplay -= OnFillObjectExitTrigger;

        }
        #endregion

        #region Private Callbacks

        private void OnTriggerDialogEmpty()
        {
            CPlayerInterface cp = CanvasPlayerInterface.GetComponent<CPlayerInterface>(); // Get the player interface
            if (CanvasPlayerInterface.activeSelf) // if the canvas is already activated
            {
                cp.SetText(cp.DialogBoxText, string.Empty); // Empty the dialog box.
                cp.DesactivateUI(cp.DialogBox); // Desactivate the ui dialogbox.
                TRG.PlayerController.LockAction = false; // Release the lock state from the player.
                //CanvasPlayerInterface.SetActive(false); // Desactivate the canvas player interface.
            }
            else
            {
                cp.SetText(cp.DialogBoxText, string.Empty);
                cp.DesactivateUI(cp.DialogBox);
                TRG.PlayerController.LockAction = false;
            }
        }

        /// <summary>
        /// When the player enter in a trigger which activate the dialog box with the part of text to display.
        /// </summary>
        /// <param name="partToDisplay"> The id of the text to display in the json file </param>
        private void OnTriggerDialogEvent(string partToDisplay)
        {
            CPlayerInterface cp = CanvasPlayerInterface.GetComponent<CPlayerInterface>(); // Get the player interface
            if (CanvasPlayerInterface.activeSelf)
            {
                cp.SetTextAndActive(cp.DialogBoxText, dialogJson[partToDisplay], cp.DialogBox); // Change the text from the text mesh pro component and activate it.
                TRG.PlayerController.LockAction = true; // Switch state of the lock action state from the player.
            }
            else
            {
                CanvasPlayerInterface.SetActive(true); // If it's not already activated turn on.
                cp.SetTextAndActive(cp.DialogBoxText, dialogJson[partToDisplay], cp.DialogBox);
                TRG.PlayerController.LockAction = true;
            }
        }

        /// <summary>
        /// When the player look something to interact with, display the information to push button.
        /// </summary>
        private void OnLookingToPress()
        {
            CPlayerInterface cp = CanvasPlayerInterface.GetComponent<CPlayerInterface>(); // Get the player interface.
            if (CanvasPlayerInterface.activeSelf)
            {
                cp.SetTextAndActive(cp.ActionInfoText, "Appuyer sur le clic gauche pour activer", cp.ActionInfoPanel);
            }
            else
            {
                CanvasPlayerInterface.SetActive(true);
                cp.SetTextAndActive(cp.ActionInfoText, "Appuyer sur le clic gauche pour activer", cp.ActionInfoPanel);
            }
        }

        /// <summary>
        /// When the player view leave the trigger of an object to watch to interact with. Removing the display to show the button to press.
        /// </summary>
        private void OnNotLookingToPress()
        {
            CPlayerInterface cp = CanvasPlayerInterface.GetComponent<CPlayerInterface>();
            if (CanvasPlayerInterface.activeSelf)
            {
                cp.SetText(cp.ActionInfoText, string.Empty);
                cp.DesactivateUI(cp.ActionInfoPanel);
                //CanvasPlayerInterface.SetActive(false);
            }
            else
            {
                cp.SetText(cp.ActionInfoText, string.Empty);
                cp.DesactivateUI(cp.ActionInfoPanel);
            }
        }

        /// <summary>
        /// When the player is in front of a cupboard, display the input to open it.
        /// </summary>
        private void OnLookingToOpen()
        {
            CPlayerInterface cp = CanvasPlayerInterface.GetComponent<CPlayerInterface>();
            if (CanvasPlayerInterface.activeSelf)
            {
                cp.SetTextAndActive(cp.ActionInfoText, "Appuyer sur la touche d'action pour activer", cp.ActionInfoPanel);
            }
            else
            {
                CanvasPlayerInterface.SetActive(true);
                cp.SetTextAndActive(cp.ActionInfoText, "Appuyer sur la touche d'action pour activer", cp.ActionInfoPanel);
            }
        }

        /// <summary>
        /// When the player view leave the trigger to a cupboard, remove the display of the input to press.
        /// </summary>
        private void OnNotLookingToOpen()
        {
            CPlayerInterface cp = CanvasPlayerInterface.GetComponent<CPlayerInterface>();
            if (CanvasPlayerInterface.activeSelf)
            {
                cp.SetText(cp.ActionInfoText, string.Empty);
                cp.DesactivateUI(cp.ActionInfoPanel);
                //CanvasPlayerInterface.SetActive(false);
            }
            else
            {
                cp.SetText(cp.ActionInfoText, string.Empty);
                cp.DesactivateUI(cp.ActionInfoPanel);
            }
        }

        /// <summary>
        /// When the player enter in a trigger of an object to grab, display the input to press.
        /// </summary>
        private void OnObjectEnterTrigger()
        {
            CPlayerInterface cp = CanvasPlayerInterface.GetComponent<CPlayerInterface>();
            if (CanvasPlayerInterface.activeSelf) //if the canvas is already activated
            {
                cp.SetText(cp.ActionInfoText, "Appuyer sur la touche d'action pour prendre l'objet");
                cp.ActivateUI(cp.ActionInfoPanel);
            }
            else
            {
                CanvasPlayerInterface.SetActive(true);
                cp.SetText(cp.ActionInfoText, "Appuyer sur la touche d'action pour prendre l'objet");
                cp.ActivateUI(cp.ActionInfoPanel);
            }
        }

        /// <summary>
        /// When the player leave a trigger of an object to grab, remove the display of the input to press.
        /// </summary>
        private void OnObjectExitTrigger()
        {
            CPlayerInterface cp = CanvasPlayerInterface.GetComponent<CPlayerInterface>();
            if (CanvasPlayerInterface.activeSelf) //if the canvas is already activated
            {
                cp.SetText(cp.ActionInfoText, string.Empty);
                cp.DesactivateUI(cp.ActionInfoPanel);
                //CanvasPlayerInterface.SetActive(false);
            }
            else
            {
                cp.SetText(cp.ActionInfoText, string.Empty);
                cp.DesactivateUI(cp.ActionInfoPanel);
            }
        }

        /// <summary>
        /// When the player took the object, call the method to remove the display.
        /// </summary>
        /// <param name="nameObject"> The name of the object grabbed </param>
        private void OnObjectTook(GameObject interactableObject)
        {
            OnObjectExitTrigger();
            /*if (photonView.IsMine)
            {
                OnObjectExitTrigger();
            }
            else if (GameManager.Instance.isOffline)
            {
                OnObjectExitTrigger();
            }*/
        }

        /// <summary>
        /// When the player enter in a trigger of an object to drop another one, display the input to press
        /// </summary>
        private void OnFillObjectEnterTrigger()
        {
            CPlayerInterface cp = CanvasPlayerInterface.GetComponent<CPlayerInterface>();
            if (CanvasPlayerInterface.activeSelf) //if the canvas is already activated
            {
                cp.SetText(cp.ActionInfoText, "Appuyer sur la touche d'action pour lâcher l'objet");
                cp.ActivateUI(cp.ActionInfoPanel);
            }
            else
            {
                CanvasPlayerInterface.SetActive(true);
                cp.SetText(cp.ActionInfoText, "Appuyer sur la touche d'action pour lâcher l'objet");
                cp.ActivateUI(cp.ActionInfoPanel);
            }
        }

        /// <summary>
        /// When the player leave the trigger of an object to drop another one, remove the display of the input to press.
        /// </summary>
        private void OnFillObjectExitTrigger()
        {
            CPlayerInterface cp = CanvasPlayerInterface.GetComponent<CPlayerInterface>();
            if (CanvasPlayerInterface.activeSelf) //if the canvas is already activated
            {
                cp.SetText(cp.ActionInfoText, string.Empty);
                cp.DesactivateUI(cp.ActionInfoPanel);
                //CanvasPlayerInterface.SetActive(false);
            }
            else
            {
                cp.SetText(cp.ActionInfoText, string.Empty);
                cp.DesactivateUI(cp.ActionInfoPanel);
            }
        }

        private void OnOpenObjectEnterTrigger()
        {
            CPlayerInterface cp = CanvasPlayerInterface.GetComponent<CPlayerInterface>();
            if (CanvasPlayerInterface.activeSelf) //if the canvas is already activated
            {
                cp.SetText(cp.ActionInfoText, "Appuyer sur la touche action pour ouvrir");
                cp.ActivateUI(cp.ActionInfoPanel);
            }
            else
            {
                CanvasPlayerInterface.SetActive(true);
                cp.SetText(cp.ActionInfoText, "Appuyer sur la touche action pour ouvrir");
                cp.ActivateUI(cp.ActionInfoPanel);
            }
        }

        private void OnOpenObjectExitTrigger()
        {
            CPlayerInterface cp = CanvasPlayerInterface.GetComponent<CPlayerInterface>();
            if (CanvasPlayerInterface.activeSelf) //if the canvas is already activated
            {
                cp.SetText(cp.ActionInfoText, string.Empty);
                cp.DesactivateUI(cp.ActionInfoPanel);
                //CanvasPlayerInterface.SetActive(false);
            }
            else
            {
                cp.SetText(cp.ActionInfoText, string.Empty);
                cp.DesactivateUI(cp.ActionInfoPanel);
            }
        }

        private void OnPauseButtonAction()
        {
            if (pauseAction) // When the game is not in pause.
            {
                pauseAction = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                CanvasPlayerMenu.SetActive(pauseAction);
                return;
            }
            else // When the game is in pause
            {
                pauseAction = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                CanvasPlayerMenu.SetActive(pauseAction);
                return;
            }
        }

        #endregion

        #region Public Methods



        #endregion

        #region Private Methods

        /// <summary>
        /// Read all the narrative part save in a .txt file recorded in json
        /// </summary>
        private void ReadNarrativeFile()
        {
            if (Application.systemLanguage == SystemLanguage.French)
            {
                dialogJson = JSON.Parse(Resources.Load<TextAsset>("Narrative/FR/dialogTextExp0").text);
            }
        }

        #endregion
    }
}