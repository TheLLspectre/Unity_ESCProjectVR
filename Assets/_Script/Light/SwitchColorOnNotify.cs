using System.Collections;
using System.Collections.Generic;
using TheRed.Experience0.Desk;
using TheRed.Experience0.PressurePlate;
using TheRed.Objects;
using UnityEngine;

namespace TheRed.Lights
{
    [AddComponentMenu("TheRed/Light/SwitchColorOnNotify")]
    public class SwitchColorOnNotify : MonoBehaviour
    {
        #region Public Fields

        public GameObject ObjectToSub; // The GameObject to listen for specific event
        public Color colorToSwitch; // The color to switch when the event is trigger

        #endregion

        #region Private Fields

        private Light _light; // The light component on this gameObject
        private Color initColor; // The initial color on the light
        private BlinkingLight blinking; // The blinking script to avoid it.

        #endregion

        #region MonoBehaviour Callbacks

        // Start is called before the first frame update
        void Start()
        {
            if (ObjectToSub == null) // Just if the object to listen is empty display an error.
                Debug.LogError("ObjectToSub is NULL", this.gameObject);
            _light = GetComponent<Light>(); // Get the light component.
            initColor = _light.color; // Get the initial color on the light
            if (GetComponent<BlinkingLight>()) // If the gameobject have a blinking script
                blinking = GetComponent<BlinkingLight>(); // Get it
        }

        private void OnEnable()
        {
            if (ObjectToSub != null) // If the object to listen is not empty
            {
                //Subscribe to each event available.
                if (ObjectToSub.GetComponent<DeskManager>())
                {
                    ObjectToSub.GetComponent<DeskManager>().OnAllPressedButtonAction += OnAllPressedButton;
                    ObjectToSub.GetComponent<DeskManager>().OnNotAllPressedButtonAction += OnNotAllPressedButton;
                }

                if (ObjectToSub.GetComponent<PressurePlateManager>())
                {
                    ObjectToSub.GetComponent<PressurePlateManager>().OnAllPlatePressedAction += OnAllPlatePressed;
                }

                if (ObjectToSub.GetComponent<FillObjectManager>())
                {
                    ObjectToSub.GetComponent<FillObjectManager>().OnAllObjectFilled += OnAllObjectFilled;
                }
            }
        }

        private void OnDisable()
        {
            if (ObjectToSub != null)
            {
                //Do the same thing to unsub it.
                if (ObjectToSub.GetComponent<DeskManager>())
                {
                    ObjectToSub.GetComponent<DeskManager>().OnAllPressedButtonAction -= OnAllPressedButton;
                    ObjectToSub.GetComponent<DeskManager>().OnNotAllPressedButtonAction -= OnNotAllPressedButton;
                }

                if (ObjectToSub.GetComponent<PressurePlateManager>())
                {
                    ObjectToSub.GetComponent<PressurePlateManager>().OnAllPlatePressedAction -= OnAllPlatePressed;
                }

                if (ObjectToSub.GetComponent<FillObjectManager>())
                {
                    ObjectToSub.GetComponent<FillObjectManager>().OnAllObjectFilled -= OnAllObjectFilled;
                }
            }
        }

        #endregion

        #region Private Callbacks

        /// <summary>
        /// All button are pressed do something
        /// </summary>
        private void OnAllPressedButton()
        {
            SwitchColor();
        }

        /// <summary>
        /// Not all button are pressed do something
        /// </summary>
        private void OnNotAllPressedButton()
        {
            ResetColor();
        }

        /// <summary>
        /// All pressure plate are pressed do also something
        /// </summary>
        private void OnAllPlatePressed()
        {
            SwitchColor();
        }

        private void OnAllObjectFilled()
        {
            SwitchColor();
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods

        /// <summary>
        /// Stop the blinking action and change the color of the light. And also fix the intensity.
        /// </summary>
        private void SwitchColor()
        {
            _light.color = colorToSwitch;
            if (blinking != null)
            {
                blinking.enabled = false;
                _light.intensity = blinking.MaxIntensity / 2;
            }
        }

        /// <summary>
        /// Reset the color of the light with the initial one. And activate the blinking action if it's available.
        /// </summary>
        private void ResetColor()
        {
            _light.color = initColor;
            if (blinking != null)
                blinking.enabled = true;
        }

        #endregion
    }
}