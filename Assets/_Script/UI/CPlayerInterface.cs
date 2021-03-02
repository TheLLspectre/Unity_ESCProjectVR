/* Copyright 2021
 * author: LEROUGE Ludovic
 * TheRed Games FrameWorkRed
 * All rights reserved
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TheRed.UI
{
    [AddComponentMenu("TheRed/UI/CPlayerInterface")]
    public class CPlayerInterface : MonoBehaviour
    {
        #region Public Fields
        public TextMeshProUGUI ActionInfoText { get { return actionInfoText; } }
        public TextMeshProUGUI DialogBoxText { get { return dialogBoxText; } }

        [Tooltip("The panel to show basics information to the player")]
        public GameObject ActionInfoPanel;
        [Tooltip("The UI to illustrate where the player is looking.")]
        public GameObject ReticleUI;
        [Tooltip("The dialog box to display dialog or informations to player.")]
        public GameObject DialogBox;

        #endregion

        #region Private Fields

        private TextMeshProUGUI actionInfoText;
        private TextMeshProUGUI dialogBoxText;

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            actionInfoText = ActionInfoPanel.GetComponentInChildren<TextMeshProUGUI>();
            dialogBoxText = DialogBox.GetComponentInChildren<TextMeshProUGUI>();
        }

        // Start is called before the first frame update
        void Start()
        {
            ActivateUI(ReticleUI);
        }

        /*// Update is called once per frame
        void Update()
        {

        }*/

        #endregion

        #region Public Methods

        public void SetText(TextMeshProUGUI textField, string text)
        {
            textField.text = text;
        }

        public void SetTextAndActive(TextMeshProUGUI textField, string text, GameObject go)
        {
            textField.text = text;
            go.SetActive(true);
        }

        public void ActivateUI(GameObject go)
        {
            go.SetActive(true);
        }

        public void DesactivateUI(GameObject go)
        {
            go.SetActive(false);
        }

        #endregion

        #region Private Methods



        #endregion
    }
}