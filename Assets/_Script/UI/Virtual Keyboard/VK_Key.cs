using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TheRed.UI.Keyboard.Key
{
    [AddComponentMenu("TheRed/UI/Virtual Keyboard/VK_Key")]
    [ExecuteInEditMode]
    public class VK_Key : MonoBehaviour
    {
        #region Public Fields

        public string KeyValue;
        public bool SpecialCharacter = false;
        public TextMeshProUGUI TMP_Key;

        public delegate void OnShiftPressedHandler();
        public static event OnShiftPressedHandler OnShiftPressed;

        public delegate void OnShiftLockPressedHanlder();
        public static event OnShiftLockPressedHanlder OnShiftLockPressed;

        public delegate void OnDeletePressedHandler();
        public static event OnDeletePressedHandler OnDeletePressed;

        public delegate void OnEnterPressedHandler();
        public static event OnEnterPressedHandler OnEnterPressed;
        #endregion

        #region Private Fields

        [SerializeField]
        private VirtualKeyboard v_keyboard = null;

        #endregion

        #region MonoBehaviour Callbacks

        // Start is called before the first frame update
        void Start()
        {
            if (KeyValue == string.Empty)
                Debug.LogError("This key haven't value affected.", gameObject);
            if (v_keyboard == null)
                Debug.LogError("This key is not assign to a keyboard. ", gameObject);

            InitializeVK();
        }

        // Update is called once per frame
        void Update()
        {
#if UNITY_EDITOR
            //Only run in the editor
            if (!Application.isPlaying && Application.isEditor)
            {
                InitializeVK();
            }
#endif
        }

        private void OnEnable()
        {
            this.v_keyboard.OnUpperCase += OnUpperCase;
        }

        private void OnDisable()
        {
            this.v_keyboard.OnUpperCase -= OnUpperCase;
        }

        #endregion

        #region Private Callbacks

        private void OnUpperCase(bool uppercase)
        {

            if (TMP_Key != null)
                if (KeyValue != string.Empty)
                {
                    if (!SpecialCharacter)
                    {
                        if (uppercase)
                        {
                            //Debug.Log(TMP_Key.text + " " + KeyValue.ToUpper());
                            KeyValue = KeyValue.ToUpper();
                            TMP_Key.SetText(KeyValue); // Affect the display character to the button.
                        }
                        else
                        {
                            //Debug.Log(TMP_Key.text + " " + KeyValue.ToLower());
                            KeyValue = KeyValue.ToLower();
                            TMP_Key.SetText(KeyValue.ToLower()); // Affect the display character to the button.
                        }
                    } 
                }   
        }

        private void InitializeVK()
        {
            string[] getLetter = gameObject.name.Split(' '); // Split the gameobject name by space character
            if (getLetter.Length != 3)
            {
                if (getLetter.Length == 1)
                {
                    KeyValue = getLetter[0]; // Get the letter contain in the name of the gameObject
                }
            }
            else
            {
                KeyValue = getLetter[2]; // Get the letter contain in the name of the gameObject
            }


            if (TMP_Key != null)
                if (KeyValue != string.Empty)
                    if (TMP_Key.text != KeyValue)
                        TMP_Key.SetText(KeyValue); // Affect the display character to the button.
        }

        #endregion

        #region Public Methods

        public void LetterPressed()
        {
            //When the button is pressed
            if (SpecialCharacter)
            {
                switch (KeyValue)
                {
                    //Space Case
                    case "SPACE":
                        v_keyboard.WriteCharacter(" ");
                        break;

                        //Shift case
                    case "MAJ":
                        if (OnShiftPressed != null)
                            OnShiftPressed();
                        break;

                    case "SHIFT":
                        if (OnShiftPressed != null)
                            OnShiftPressed();
                        break;

                        //Caps Lock Case
                    case "MAJ_LOCK":
                        if (OnShiftLockPressed != null)
                            OnShiftLockPressed();
                        break;

                    case "SHIFT_LOCK":
                        if (OnShiftLockPressed != null)
                            OnShiftLockPressed();
                        break;

                        //Delete case
                    case "SUPPR":
                        if (OnDeletePressed != null)
                            OnDeletePressed();
                        break;

                    case "DEL":
                        if (OnDeletePressed != null)
                            OnDeletePressed();
                        break;

                        //Enter Case
                    case "ENTREE":
                        if (OnEnterPressed != null)
                            OnEnterPressed();
                        break;

                    case "ENTER":
                        break;
                }
            }
            else
            {
                v_keyboard.WriteCharacter(KeyValue);
            }
        }

        #endregion

        #region Private Methods
        #endregion
    }
}