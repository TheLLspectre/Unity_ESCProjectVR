using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using TheRed.UI.Keyboard.Key;
using UnityEngine.EventSystems;

namespace TheRed.UI.Keyboard
{
    [AddComponentMenu("TheRed/UI/Virtual Keyboard/VirtualKeyboard")]
    public class VirtualKeyboard : MonoBehaviour
    {
        #region Public Fields

        public TMP_InputField IField;

        [Header("Keyboard states:")]
        public bool UpperCase = false;
        public bool UpperCaseLocked = false;
        public bool SpecialCharater = false;

        // Event when the upper case is Active or not
        public delegate void OnUpperCaseHandler(bool uppercase);
        public event OnUpperCaseHandler OnUpperCase;
        #endregion

        #region Private Fields

        private List<char> listChar = new List<char>();

        private string t_IField;

        #endregion

        #region MonoBehaviour Callbacks

        // Start is called before the first frame update
        void Start()
        {
            if (IField != null)
                t_IField = IField.text;
            else
                Debug.LogError("This keyboard is not assign to an inputField.", gameObject);

            //Notify every input from this keyboard the uppercase aren't activated
            if (OnUpperCase != null)
                OnUpperCase(UpperCase);
        }

        private void OnEnable()
        {
            VK_Key.OnShiftPressed += SetShift;
            VK_Key.OnShiftLockPressed += SetShiftLock;
            VK_Key.OnDeletePressed += DeleteCharacter;
            VK_Key.OnEnterPressed += OnEnterPressed;
        }

        private void OnDisable()
        {
            VK_Key.OnShiftPressed -= SetShift;
            VK_Key.OnShiftLockPressed -= SetShiftLock;
            VK_Key.OnDeletePressed -= DeleteCharacter;
            VK_Key.OnEnterPressed -= OnEnterPressed;
        }

        #endregion

        #region Private Callbacks

        private void OnEnterPressed()
        {
            t_IField = IField.text;
            IField.onValueChanged.Invoke(t_IField);
            //IField.onSubmit.Invoke(t_IField);
        }

        private void DeleteCharacter()
        {
            if (IField.text != string.Empty)
            {
                t_IField = IField.text;
                char[] charArray = t_IField.ToCharArray();
                listChar = charArray.ToList();
                listChar.RemoveAt(listChar.Count - 1);
                charArray = listChar.ToArray();
                IField.SetTextWithoutNotify(charArray.ArrayToString());
            }
        }

        private void SetShift()
        {
            if (UpperCase)
                UpperCase = false;
            else
                UpperCase = true;

            if (OnUpperCase != null)
                OnUpperCase(UpperCase);
        }

        private void SetShiftLock()
        {
            if (UpperCaseLocked)
            {
                UpperCaseLocked = false;
                UpperCase = false;
            }
            else
            {
                UpperCaseLocked = true;
                UpperCase = true;
            }

            if (OnUpperCase != null)
                OnUpperCase(UpperCase);
        }

        #endregion

        #region Public Methods

        public void WriteCharacter(string characterReceived)
        {
            Debug.Log(characterReceived);
            t_IField = IField.text; // get the current text from the input field.

            if (UpperCase)
            {
                IField.SetTextWithoutNotify(t_IField + characterReceived.ToUpper());
                if (!UpperCaseLocked)
                {
                    SetShift();
                }
            }
            else
            {
                IField.SetTextWithoutNotify(t_IField + characterReceived.ToLower());
            }

            //Not realy sur of what happen here.
            IField.stringPosition += 1;
            IField.caretPosition += 1;
            IField.caretBlinkRate = 1.0f;
            
        }

        #endregion

        #region Private Methods
        #endregion
    }
}