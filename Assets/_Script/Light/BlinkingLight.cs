using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheRed.Lights
{
    [AddComponentMenu("TheRed/Light/BlinkingLight")]
    public class BlinkingLight : MonoBehaviour
    {
        #region Public Fields
        [Header("Settings")]
        public float MaxIntensity = 1.0f; // The maximum of intensity to blink
        public float MinIntensity = 0.5f; // And also the minimum to blink
        [Range(0.001f,0.1f)]
        public float BlinkingIntensity = 0.1f; // The power of update intensity
        #endregion

        #region Private Fields

        private Light _light; // Component Light from this gameObject

        private bool switchIntensity = false; // When the intensity go to a step switch variation


        #endregion

        #region MonoBehaviour Callbacks

        // Start is called before the first frame update
        void Start()
        {
            _light = GetComponent<Light>(); // Get the component of this light
        }

        // Update is called once per frame
        void LateUpdate()
        {
            Blinking(); // Call the blinking methods
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods

        /// <summary>
        /// Blinking method to update the intensity of the light
        /// </summary>
        private void Blinking()
        {
            if (_light.intensity >= MaxIntensity) // Switch pole to a step up
            {
                switchIntensity = true;
            }
            else if (_light.intensity <= MinIntensity) //Switch pole to a step down
            {
                switchIntensity = false;
            }

            if (switchIntensity)
            {
                _light.intensity -= BlinkingIntensity; // Update intensity of light
            }
            else
            {
                _light.intensity += BlinkingIntensity;
            }
        }

        #endregion
    }
}