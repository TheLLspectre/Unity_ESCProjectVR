using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using TheRed.Multiplayer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;
using UnityEngine.XR;

namespace TheRed.Player.XRController
{
    [AddComponentMenu("TheRed/XRInteraction/XRPlayerController")]
    public class XRPlayerController : MonoBehaviourPunCallbacks, IPunObservable
    {
        //public
        #region Public Statement
        public HandPresence RightHandPresence { get { return rightHandPresence; } set { rightHandPresence = value; } }
        public HandPresence LeftHandPresence { get { return leftHandPresence; } set { leftHandPresence = value; } }

        public static GameObject LocalPlayerInstance;
        
        [Header("XR Camera :")]
        public GameObject CameraObject;
        
        [Header("XR Hands :")]
        public GameObject RightHand;
        public GameObject LeftHand;

        public bool AllowRayCursor = false;
        public float TimeToDesactivate = 5.0f;

        #endregion

        //private
        #region Private Statement
        private HandPresence rightHandPresence = null;
        private HandPresence leftHandPresence = null;
        private XRInputActions input;
        private Coroutine rayCoroutine = null;
        private Coroutine teleportCoroutine = null;

        //Right hand right stick boolean
        private bool rhrsu = false;
        private bool rhrsl = false;
        private bool rhrsr = false;
        private bool rhrsd = false;
        private bool rightTeleportSpawned = false;
        private bool rightTrigger = false;
        private bool rightRaySpawned = false;

        //Left hand left stick boolean
        private bool lhlsu = false;
        private bool lhlsl = false;
        private bool lhlsr = false;
        private bool lhlsd = false;
        private bool leftTeleportSpawned = false;
        private bool leftTrigger = false;
        private bool leftRaySpawned = false;
        #endregion

        private void Awake()
        {
                //if(photonView.IsMine)
                    XRPlayerController.LocalPlayerInstance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
            input = new XRInputActions();
        }

        // Start is called before the first frame update
        void Start()
        {
            HandInitialization();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void HandInitialization()
        {
            if (!RightHand || !LeftHand)
            {
                Debug.LogError("Any Hand in the project or their not associated so drag & drop it!");
            }
            else
            {
                if (RightHand)
                    rightHandPresence = RightHand.GetComponent<HandPresence>();
                else
                    Debug.LogWarning("The Right Hand isn't in the project or associated. So any HandPresence script detected !");

                if (LeftHand)
                    leftHandPresence = LeftHand.GetComponent<HandPresence>();
                else
                    Debug.LogWarning("The Left Hand isn't in the project or associated. So any HandPresence script detected !");
            }
        }

        #region input action
        void SubscribeEvent()
        {
            //Right XR Controller
            //Trigger
            Debug.LogError("SubToRightHandTrigger " + input.Control);
            input.Control.RightHandTrigger.started += ctx => OnRightHandTriggerStarted();
            input.Control.RightHandTrigger.performed += ctx => OnRightHandTriggerPerformed();
            input.Control.RightHandTrigger.canceled += ctx => OnRightHandTriggerCanceled();

            //Grip
            input.Control.RightHandGrip.started += ctx => OnRightHandGripStarted();
            input.Control.RightHandGrip.performed += ctx => OnRightHandGripPerformed();
            input.Control.RightHandGrip.performed += ctx => OnRightHandGripCanceled();

            //Button 1
            input.Control.RightHandButton1.started += ctx => OnRightHandButton1Started();
            input.Control.RightHandButton1.performed += ctx => OnRightHandButton1Performed();
            input.Control.RightHandButton1.performed += ctx => OnRightHandButton1Canceled();

            //Button2
            input.Control.RightHandButton2.started += ctx => OnRightHandButton2Started();
            input.Control.RightHandButton2.performed += ctx => OnRightHandButton2Performed();
            input.Control.RightHandButton2.performed += ctx => OnRightHandButton2Canceled();

            //Stick
            input.Control.RightHandStick.started += ctx => OnRightHandStickStarted();
            input.Control.RightHandStick.performed += ctx => OnRightHandStickPerformed();
            input.Control.RightHandStick.canceled += ctx => OnRightHandStickCanceled();

            //Stick Up
            input.Control.RightHandStickUp.started += ctx => OnRightHandStickUpStarted();
            input.Control.RightHandStickUp.performed += ctx => OnRightHandStickUpPerformed();
            input.Control.RightHandStickUp.canceled += ctx => OnRightHandStickUpCanceled();

            //Stick Left
            input.Control.RightHandStickX.started += ctx => OnRightHandStickXStarted();
            input.Control.RightHandStickX.performed += ctx => OnRightHandStickXPerformed();
            input.Control.RightHandStickX.canceled += ctx => OnRightHandStickXCanceled();

            //Stick Right
            input.Control.RightHandStickY.started += ctx => OnRightHandStickYStarted();
            input.Control.RightHandStickY.performed += ctx => OnRightHandStickYPerformed();
            input.Control.RightHandStickY.canceled += ctx => OnRightHandStickYCanceled();

            //Stick Down
            input.Control.RightHandStickDown.started += ctx => OnRightHandStickDownStarted();
            input.Control.RightHandStickDown.performed += ctx => OnRightHandStickDownPerformed();
            input.Control.RightHandStickDown.canceled += ctx => OnRightHandStickDownCanceled();

            //Left XR Controller
            input.Control.LeftHandTrigger.started += ctx => OnLeftHandTriggerStarted();
            input.Control.LeftHandTrigger.performed += ctx => OnLeftHandTriggerPerformed();
            input.Control.LeftHandTrigger.canceled += ctx => OnLeftHandTriggerCanceled();

            //Grip
            input.Control.LeftHandGrip.started += ctx => OnLeftHandGripStarted();
            input.Control.LeftHandGrip.performed += ctx => OnLeftHandGripPerformed();
            input.Control.LeftHandGrip.performed += ctx => OnLeftHandGripCanceled();

            //Button 1
            input.Control.LeftHandButton1.started += ctx => OnLeftHandButton1Started();
            input.Control.LeftHandButton1.performed += ctx => OnLeftHandButton1Performed();
            input.Control.LeftHandButton1.performed += ctx => OnLeftHandButton1Canceled();

            //Button2
            input.Control.LeftHandButton2.started += ctx => OnLeftHandButton2Started();
            input.Control.LeftHandButton2.performed += ctx => OnLeftHandButton2Performed();
            input.Control.LeftHandButton2.performed += ctx => OnLeftHandButton2Canceled();

            //Stick
            input.Control.LeftHandStick.started += ctx => OnLeftHandStickStarted();
            input.Control.LeftHandStick.performed += ctx => OnLeftHandStickPerformed();
            input.Control.LeftHandStick.canceled += ctx => OnLeftHandStickCanceled();

            //Stick Up
            input.Control.LeftHandStickUp.started += ctx => OnLeftHandStickUpStarted();
            input.Control.LeftHandStickUp.performed += ctx => OnLeftHandStickUpPerformed();
            input.Control.LeftHandStickUp.canceled += ctx => OnLeftHandStickUpCanceled();

            //Stick Left
            input.Control.LeftHandStickX.started += ctx => OnLeftHandStickXStarted();
            input.Control.LeftHandStickX.performed += ctx => OnLeftHandStickXPerformed();
            input.Control.LeftHandStickX.canceled += ctx => OnLeftHandStickXCanceled();

            //Stick Left
            input.Control.LeftHandStickY.started += ctx => OnLeftHandStickYStarted();
            input.Control.LeftHandStickY.performed += ctx => OnLeftHandStickYPerformed();
            input.Control.LeftHandStickY.canceled += ctx => OnLeftHandStickYCanceled();

            //Stick Down
            input.Control.LeftHandStickDown.started += ctx => OnLeftHandStickDownStarted();
            input.Control.LeftHandStickDown.performed += ctx => OnLeftHandStickDownPerformed();
            input.Control.LeftHandStickDown.canceled += ctx => OnLeftHandStickDownCanceled();
        }

        void UnsubscribeEvent()
        {
            //Right XR Controller
            //Trigger
            input.Control.RightHandTrigger.started -= ctx => OnRightHandTriggerStarted();
            input.Control.RightHandTrigger.performed -= ctx => OnRightHandTriggerPerformed();
            input.Control.RightHandTrigger.canceled -= ctx => OnRightHandTriggerCanceled();

            //Grip
            input.Control.RightHandGrip.started -= ctx => OnRightHandGripStarted();
            input.Control.RightHandGrip.performed -= ctx => OnRightHandGripPerformed();
            input.Control.RightHandGrip.performed -= ctx => OnRightHandGripCanceled();

            //Button 1
            input.Control.RightHandButton1.started -= ctx => OnRightHandButton1Started();
            input.Control.RightHandButton1.performed -= ctx => OnRightHandButton1Performed();
            input.Control.RightHandButton1.performed -= ctx => OnRightHandButton1Canceled();

            //Button2
            input.Control.RightHandButton2.started -= ctx => OnRightHandButton2Started();
            input.Control.RightHandButton2.performed -= ctx => OnRightHandButton2Performed();
            input.Control.RightHandButton2.performed -= ctx => OnRightHandButton2Canceled();

            //Stick
            input.Control.RightHandStick.started -= ctx => OnRightHandStickStarted();
            input.Control.RightHandStick.performed -= ctx => OnRightHandStickPerformed();
            input.Control.RightHandStick.canceled -= ctx => OnRightHandStickCanceled();

            //Stick Up
            input.Control.RightHandStickUp.started -= ctx => OnRightHandStickUpStarted();
            input.Control.RightHandStickUp.performed -= ctx => OnRightHandStickUpPerformed();
            input.Control.RightHandStickUp.canceled -= ctx => OnRightHandStickUpCanceled();

            //Stick Left
            input.Control.RightHandStickX.started -= ctx => OnRightHandStickXStarted();
            input.Control.RightHandStickX.performed -= ctx => OnRightHandStickXPerformed();
            input.Control.RightHandStickX.canceled -= ctx => OnRightHandStickXCanceled();

            //Stick Right
            input.Control.RightHandStickY.started -= ctx => OnRightHandStickYStarted();
            input.Control.RightHandStickY.performed -= ctx => OnRightHandStickYPerformed();
            input.Control.RightHandStickY.canceled -= ctx => OnRightHandStickYCanceled();

            //Stick Down
            input.Control.RightHandStickDown.started -= ctx => OnRightHandStickDownStarted();
            input.Control.RightHandStickDown.performed -= ctx => OnRightHandStickDownPerformed();
            input.Control.RightHandStickDown.canceled -= ctx => OnRightHandStickDownCanceled();

            //Left XR Controller
            input.Control.LeftHandTrigger.started -= ctx => OnLeftHandTriggerStarted();
            input.Control.LeftHandTrigger.performed -= ctx => OnLeftHandTriggerPerformed();
            input.Control.LeftHandTrigger.canceled -= ctx => OnLeftHandTriggerCanceled();

            //Grip
            input.Control.LeftHandGrip.started -= ctx => OnLeftHandGripStarted();
            input.Control.LeftHandGrip.performed -= ctx => OnLeftHandGripPerformed();
            input.Control.LeftHandGrip.performed -= ctx => OnLeftHandGripCanceled();

            //Button 1
            input.Control.LeftHandButton1.started -= ctx => OnLeftHandButton1Started();
            input.Control.LeftHandButton1.performed -= ctx => OnLeftHandButton1Performed();
            input.Control.LeftHandButton1.performed -= ctx => OnLeftHandButton1Canceled();

            //Button2
            input.Control.LeftHandButton2.started -= ctx => OnLeftHandButton2Started();
            input.Control.LeftHandButton2.performed -= ctx => OnLeftHandButton2Performed();
            input.Control.LeftHandButton2.performed -= ctx => OnLeftHandButton2Canceled();

            //Stick
            input.Control.LeftHandStick.started -= ctx => OnLeftHandStickStarted();
            input.Control.LeftHandStick.performed -= ctx => OnLeftHandStickPerformed();
            input.Control.LeftHandStick.canceled -= ctx => OnLeftHandStickCanceled();

            //Stick Up
            input.Control.LeftHandStickUp.started -= ctx => OnLeftHandStickUpStarted();
            input.Control.LeftHandStickUp.performed -= ctx => OnLeftHandStickUpPerformed();
            input.Control.LeftHandStickUp.canceled -= ctx => OnLeftHandStickUpCanceled();

            //Stick Left
            input.Control.LeftHandStickX.started -= ctx => OnLeftHandStickXStarted();
            input.Control.LeftHandStickX.performed -= ctx => OnLeftHandStickXPerformed();
            input.Control.LeftHandStickX.canceled -= ctx => OnLeftHandStickXCanceled();

            //Stick Left
            input.Control.LeftHandStickY.started -= ctx => OnLeftHandStickYStarted();
            input.Control.LeftHandStickY.performed -= ctx => OnLeftHandStickYPerformed();
            input.Control.LeftHandStickY.canceled -= ctx => OnLeftHandStickYCanceled();

            //Stick Down
            input.Control.LeftHandStickDown.started -= ctx => OnLeftHandStickDownStarted();
            input.Control.LeftHandStickDown.performed -= ctx => OnLeftHandStickDownPerformed();
            input.Control.LeftHandStickDown.canceled -= ctx => OnLeftHandStickDownCanceled();
        }

        /*************************LEFT CONTROLLER********************/
        #region left controller
        //Left Grip
        private void OnLeftHandGripStarted()
        {
            DesactivateRay();
            DesactivateTeleport();
            Debug.Log(input.Control.LeftHandGrip.name + " started");
        }

        private void OnLeftHandGripPerformed()
        {
            Debug.Log(input.Control.LeftHandGrip.name + " performed");
        }

        private void OnLeftHandGripCanceled()
        {
            Debug.Log(input.Control.LeftHandGrip.name + " canceled");
        }

        //Left Hand First Button
        private void OnLeftHandButton1Started()
        {
            Debug.Log(input.Control.LeftHandButton1.name + " started");
        }

        private void OnLeftHandButton1Performed()
        {
            Debug.Log(input.Control.LeftHandButton1.name + " performed");
        }

        private void OnLeftHandButton1Canceled()
        {
            Debug.Log(input.Control.LeftHandButton1.name + " canceled");
        }

        //Left Hand Secondary Button
        private void OnLeftHandButton2Started()
        {
            Debug.Log(input.Control.LeftHandButton2.name + " started");
        }

        private void OnLeftHandButton2Performed()
        {
            Debug.Log(input.Control.LeftHandButton2.name + " performed");
        }

        private void OnLeftHandButton2Canceled()
        {
            Debug.Log(input.Control.LeftHandButton2.name + " canceled");
        }

        //On Left Hand Stick 
        private void OnLeftHandStickStarted()
        {
            //Debug.Log(input.Control.LeftHandStick.name + " started");
        }

        private void OnLeftHandStickPerformed()
        {
            //Debug.Log(input.Control.LeftHandStick.ReadValue<Vector2>() + " performed");
        }
        private void OnLeftHandStickCanceled()
        {
            //Debug.Log(input.Control.LeftHandStick.name + " canceled");
        }

        //On Left Hand Trigger
        private void OnLeftHandTriggerStarted()
        {
            DesactivateTeleport();
            leftTrigger = true;
            ActivateRay();
            if (rayCoroutine != null)
                StopCoroutine(rayCoroutine);
            Debug.Log(input.Control.LeftHandTrigger.name + " started");
        }

        private void OnLeftHandTriggerPerformed()
        {
            Debug.Log(input.Control.LeftHandTrigger.name + " performed");
        }

        private void OnLeftHandTriggerCanceled()
        {
            leftTrigger = false;
            rayCoroutine = StartCoroutine(WaitAndDesactivateRay(TimeToDesactivate));
            Debug.Log(input.Control.LeftHandTrigger.name + " canceled");
        }

        //Left Hand Stick Up
        private void OnLeftHandStickUpStarted()
        {
            DesactivateRay();
            Debug.Log(input.Control.LeftHandStickUp.name + " started");
            lhlsu = true;
            ActivateTeleport();
            if (teleportCoroutine != null)
                StopCoroutine(teleportCoroutine);
        }

        private void OnLeftHandStickUpPerformed()
        {
            //Debug.Log(input.Control.LeftHandStickUp.name + " performed");
        }

        private void OnLeftHandStickUpCanceled()
        {
            if (lhlsu)
            {
                Debug.Log(input.Control.LeftHandStickUp.name + " canceled");
                lhlsu = false;
                teleportCoroutine = StartCoroutine(WaitAndDesactivateTeleport(TimeToDesactivate));
            }
        }

        //On Left Hand Stick Left
        private void OnLeftHandStickXStarted()
        {
            Debug.Log(input.Control.LeftHandStickX.name + " started");
            lhlsl = true;
        }

        private void OnLeftHandStickXPerformed()
        {
            //Debug.Log(input.Control.LeftHandStickX.name + " performed");
        }

        private void OnLeftHandStickXCanceled()
        {
            if (lhlsl)
            {
                Debug.Log(input.Control.LeftHandStickX.name + " canceled");
                lhlsl = false;
            }
        }

        //On Left Hand Stick Right
        private void OnLeftHandStickYStarted()
        {
            Debug.Log(input.Control.LeftHandStickY.name + " started");
            lhlsr = true;
        }

        private void OnLeftHandStickYPerformed()
        {
            //Debug.Log(input.Control.LeftHandStickY.name + " performed");
        }

        private void OnLeftHandStickYCanceled()
        {
            if (lhlsr)
            {
                Debug.Log(input.Control.LeftHandStickY.name + " canceled");
                lhlsr = false;
            }
        }

        // On Left Hand Stick Down
        private void OnLeftHandStickDownStarted()
        {
            Debug.Log(input.Control.LeftHandStickDown.name + " started");
            lhlsd = true;
        }

        private void OnLeftHandStickDownPerformed()
        {
            //Debug.Log(input.Control.LeftHandStickDown.name + " performed");
        }

        private void OnLeftHandStickDownCanceled()
        {
            if (lhlsd)
            {
                Debug.Log(input.Control.LeftHandStickDown.name + " canceled");
                lhlsd = false;
            }
        }
        #endregion

        /*************************RIGHT CONTROLLER*******************/
        #region right controller
        //Right Grip
        private void OnRightHandGripStarted()
        {
            DesactivateRay();
            DesactivateTeleport();
            Debug.Log(input.Control.RightHandGrip.name + " started");
        }

        private void OnRightHandGripPerformed()
        {
            Debug.Log(input.Control.RightHandGrip.name + " performed");
        }

        private void OnRightHandGripCanceled()
        {
            Debug.Log(input.Control.RightHandGrip.name + " canceled");
        }

        //Right Hand First Button
        private void OnRightHandButton1Started()
        {
            Debug.Log(input.Control.RightHandButton1.name + " started");
        }

        private void OnRightHandButton1Performed()
        {
            Debug.Log(input.Control.RightHandButton1.name + " performed");
        }

        private void OnRightHandButton1Canceled()
        {
            Debug.Log(input.Control.RightHandButton1.name + " canceled");
        }

        //Right Hand Secondary Button
        private void OnRightHandButton2Started()
        {
            Debug.Log(input.Control.RightHandButton2.name + " started");
        }

        private void OnRightHandButton2Performed()
        {
            Debug.Log(input.Control.RightHandButton2.name + " performed");
        }

        private void OnRightHandButton2Canceled()
        {
            Debug.Log(input.Control.RightHandButton2.name + " canceled");
        }

        //On Right Hand Stick 
        private void OnRightHandStickStarted()
        {
            //Debug.Log(input.Control.RightHandStick.name + " started");
        }

        private void OnRightHandStickPerformed()
        {
            //Debug.Log(input.Control.RightHandStick.ReadValue<Vector2>() + " performed");
        }
        private void OnRightHandStickCanceled()
        {
            //Debug.Log(input.Control.RightHandStick.name + " canceled");
        }

        //On Right Hand Trigger
        private void OnRightHandTriggerStarted()
        {
            DesactivateTeleport();
            rightTrigger = true;
            ActivateRay();
            if (rayCoroutine != null)
                StopCoroutine(rayCoroutine);
            Debug.Log(input.Control.RightHandTrigger.name + " started");
        }

        private void OnRightHandTriggerPerformed()
        {
            Debug.Log(input.Control.RightHandTrigger.name + " performed");
        }

        private void OnRightHandTriggerCanceled()
        {
            rightTrigger = false;
            rayCoroutine = StartCoroutine(WaitAndDesactivateRay(TimeToDesactivate));
            Debug.Log(input.Control.RightHandTrigger.name + " canceled");
        }

        //Righ Hand Stick Up
        private void OnRightHandStickUpStarted()
        {
            DesactivateTeleport();
            DesactivateRay();
            Debug.Log(input.Control.RightHandStickUp.name + " started");
            rhrsu = true;
            ActivateTeleport();
            if (teleportCoroutine != null)
                StopCoroutine(teleportCoroutine);
        }

        private void OnRightHandStickUpPerformed()
        {
            //Debug.Log(input.Control.RightHandStickUp.name + " performed");
        }

        private void OnRightHandStickUpCanceled()
        {
            if (rhrsu)
            {
                Debug.Log(input.Control.RightHandStickUp.name + " canceled");
                rhrsu = false;
                teleportCoroutine = StartCoroutine(WaitAndDesactivateTeleport(TimeToDesactivate));
            }
        }

        //On Right Hand Stick Left
        private void OnRightHandStickXStarted()
        {
            Debug.Log(input.Control.RightHandStickX.name + " started");
            rhrsl = true;
        }

        private void OnRightHandStickXPerformed()
        {
            //Debug.Log(input.Control.RightHandStickX.name + " performed");
        }

        private void OnRightHandStickXCanceled()
        {
            if (rhrsl)
            {
                Debug.Log(input.Control.RightHandStickX.name + " canceled");
                rhrsl = false;
            }
        }

        //On Right Hand Stick Right
        private void OnRightHandStickYStarted()
        {
            Debug.Log(input.Control.RightHandStickY.name + " started");
            rhrsr = true;
        }

        private void OnRightHandStickYPerformed()
        {
            //Debug.Log(input.Control.RightHandStickY.name + " performed");
        }

        private void OnRightHandStickYCanceled()
        {
            if (rhrsr)
            {
                Debug.Log(input.Control.RightHandStickY.name + " canceled");
                rhrsr = false;
            }
        }

        // On Right Hand Stick Down
        private void OnRightHandStickDownStarted()
        {
            Debug.Log(input.Control.RightHandStickDown.name + " started");
            rhrsd = true;
        }

        private void OnRightHandStickDownPerformed()
        {
            //Debug.Log(input.Control.RightHandStickDown.name + " performed");
        }

        private void OnRightHandStickDownCanceled()
        {
            if (rhrsd)
            {
                Debug.Log(input.Control.RightHandStickDown.name + " canceled");
                rhrsd = false;
            }
        }
        #endregion
        #endregion

        /*********************************METHODS**********************************/
        #region methods action
        public void ActivateRay()
        {
            if (AllowRayCursor)
            {
                if (rightTrigger)
                {
                    rightHandPresence.SpawnedRayCursor.SetActive(true);
                    rightRaySpawned = true;
                }
                else if (leftTrigger)
                {
                    leftHandPresence.SpawnedRayCursor.SetActive(true);
                    leftRaySpawned = true;
                }
            }
        }

        public void DesactivateRay()
        {
            if (AllowRayCursor)
            {
                if (rightRaySpawned)
                {
                    rightHandPresence.SpawnedRayCursor.SetActive(false);
                    rightRaySpawned = false;
                }
                else if (leftRaySpawned)
                {
                    leftHandPresence.SpawnedRayCursor.SetActive(false);
                    leftRaySpawned = false;
                }
            }
        }
        IEnumerator WaitAndDesactivateRay(float timeToDesactivate)
        {
            yield return new WaitForSeconds(timeToDesactivate);
            DesactivateRay();
        }

        public void ActivateTeleport()
        {
            if (rhrsu)
            {
                rightHandPresence.SpawnedTeleportRayCursor.SetActive(true);
                rightTeleportSpawned = true;
            }
            else if (lhlsu)
            {
                leftHandPresence.SpawnedTeleportRayCursor.SetActive(true);
                leftTeleportSpawned = true;
            }
        }

        public void DesactivateTeleport()
        {
            if (rightTeleportSpawned)
            {
                rightHandPresence.SpawnedTeleportRayCursor.SetActive(false);
                rightTeleportSpawned = false;
            }
            else if (leftTeleportSpawned)
            {
                leftHandPresence.SpawnedTeleportRayCursor.SetActive(false);
                leftTeleportSpawned = false;
            }
        }

        IEnumerator WaitAndDesactivateTeleport(float timeToDesactivate)
        {
            yield return new WaitForSeconds(timeToDesactivate);
            DesactivateTeleport();
        }
        #endregion

        void OnEnable()
        {
            input.Enable();
            SubscribeEvent();
        }

        private void OnDisable()
        {
            UnsubscribeEvent();
            input.Disable();
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            throw new NotImplementedException();
        }
    }
}