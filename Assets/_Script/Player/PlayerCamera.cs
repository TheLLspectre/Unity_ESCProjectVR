/* Copyright 2019
 * author: LEROUGE Ludovic
 * TheRed Games FrameWorkRed
 * All rights reserved
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TheRed.Multiplayer;
using TRG = TheRed.Player.Controller;
using System;
using TheRed.UI;
using TheRed.Objects;

namespace TheRed.Player.Camera
{
    /*
 * This script is on the Camera ! Or the head in a multiplayer FPS
 */
    [AddComponentMenu("TheRed/Player/PlayerCamera")]
    public class PlayerCamera : MonoBehaviourPun
    {
        #region Public Fields
        //public

        // Event when the ray from the camera enter with a collider
        public delegate void OnRayEnterHandler(GameObject hit);
        public event OnRayEnterHandler OnRayEnterAction;

        // Event when the ray from the camera stay in a collider
        public delegate void OnRayStayHandler(GameObject hit);
        public event OnRayStayHandler OnRayStayAction;

        // Event when the ray from the camera leave a collider
        public delegate void OnRayExitHandler(GameObject hit);
        public event OnRayExitHandler OnRayExitAction;

        // Event when the ray from the camera is looking something to press
        public delegate void OnLookingToPressHandler();
        public static event OnLookingToPressHandler OnLookingToPressAction;

        // Event when the ray from the camera is no longer looking something to press
        public delegate void OnNotLookingToPressHandler();
        public static event OnNotLookingToPressHandler OnNotLookingToPressAction;

        // Event when the ray from the camera is looking something to open or close
        public delegate void OnLookingToOpenHandler();
        public static event OnLookingToOpenHandler OnLookingToOpenAction;

        // Event when the ray from the camera is no longer looking something to open or close.
        public delegate void OnNotLookingToOpenHandler();
        public static event OnNotLookingToOpenHandler OnNotLookingToOpenAction;

        #endregion

        #region Private Fields
        //private
        [Header("Settings")]
        [SerializeField] private Transform playerBody;
        [SerializeField] private float mouseSensitivity = 100;
        [SerializeField] private float stickSensitivity = 100;

        //Controller import
        private TRG.PlayerController playerController = null;
        private PlayerInput inputActions = null;

        // Manipulating value
        private GameObject lookingObject = null;

        private float xRotation = 0f;
        private float lookX = 0.0f;
        private float lookY = 0.0f;
        private Vector2 looking = Vector2.zero;

        private float timeToStay = 0.0f;
        private float distanceToObject = 0.0f;

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {

        }

        // Start is called before the first frame update
        void Start()
        {
            playerController = playerBody.gameObject.GetComponent<TRG.PlayerController>();
            inputActions = playerController.InputAction;
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            if (!GameManager.Instance.isOffline)
            {
                if (photonView.IsMine)
                {
                    if (!CanvasManager.PauseAction && !TRG.PlayerController.LockAction)
                    {
                        MoveCamera();
                    }
                    SendRaycast();
                }
            }
            else
            {
                if (!CanvasManager.PauseAction && !TRG.PlayerController.LockAction)
                {
                    MoveCamera();
                }
                SendRaycast();
            }

        }

        private void FixedUpdate()
        {
            if (playerController.Gamepad == null)
                return; // No gamepad connected.
            else
                Debug.Log("Gamepad Connected: " + playerController.Gamepad.device + " " + playerController.Gamepad.name);
        }

        private void OnEnable()
        {
            playerController = playerBody.gameObject.GetComponent<TRG.PlayerController>();
            inputActions = playerController.InputAction;

            //Subscribe event
            this.OnRayEnterAction += OnRayEnter;
            this.OnRayStayAction += OnRayStay;
            this.OnRayExitAction += OnRayExit;
        }

        private void OnDisable()
        {
            //Unsubscribe event
            this.OnRayEnterAction -= OnRayEnter;
            this.OnRayStayAction -= OnRayStay;
            this.OnRayExitAction -= OnRayExit;
        }

        #endregion

        #region Private Methods

        //methods
        void SendRaycast()
        {
            RaycastHit hit;
            //int layerMask = 12032; // This int represents 0010111100000000 in binary that mean I choose the layer 8, 9 and 13 to exclude them from the raycast collision, but with this line is only those three layers which have the collision with the raycast
            //layerMask = ~layerMask; // And this line is to inverse every bits, so 1101000011111111. And now it's only those three layers (8, 9 and 13) which are exclude from the raycast's collision
            //Vector3 fwd = reticleObject.position - transform.position;
            if (Physics.Raycast(transform.position, transform.forward, out hit/*, 200.0f , layerMask*/))
            {
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
                //Debug.Log(hit.transform.name);

                if (lookingObject != hit.transform.gameObject) // if the hit point object is different from the one register
                {
                    if(lookingObject != null)
                        OnRayExit(lookingObject); // trigger exit event on the previous looking object
                    OnRayEnter(hit.transform.gameObject); // that's mean you enter in the object
                }
                else
                {
                    OnRayStay(lookingObject);
                }

                //reticleObject.position = hit.point;
            }
        }

        void MoveCamera()
        {
            looking = inputActions.Player.Look.ReadValue<Vector2>();


            if (playerController.Gamepad == null)
            {
                lookX = looking.x * mouseSensitivity * Time.deltaTime;
                lookY = looking.y * mouseSensitivity * Time.deltaTime;
            }
            else
            {
                lookX = looking.x * stickSensitivity * Time.deltaTime;
                lookY = looking.y * stickSensitivity * Time.deltaTime;
            }

            xRotation -= lookY;
            xRotation = Mathf.Clamp(xRotation, -85f, 85f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * lookX);
        }


        #endregion

        #region Private Callbacks

        private void OnRayEnter(GameObject go)
        {
            //Debug.LogFormat("Player looking {0}", go);
            lookingObject = go;
            timeToStay = 0.0f;
            distanceToObject = 0.0f;

            if (go.tag.Equals("Target/ToPress"))
            {
                distanceToObject = Vector3.Distance(this.transform.position, go.transform.position);
                if (distanceToObject < 2.0f)
                {
                    playerController.ViewingObject = lookingObject;
                    if (OnLookingToPressAction != null)
                        OnLookingToPressAction();
                }
            }

            if (go.tag.Equals("Object/ToOpen"))
            {
                distanceToObject = Vector3.Distance(this.transform.position, go.transform.position);
                if (distanceToObject < 3.0f)
                {
                    if (go.GetComponent<CupBoard>())
                    {
                        if (go.GetComponent<CupBoard>().OpenState)
                        {
                            playerController.ViewingObject = lookingObject;
                            if (OnLookingToOpenAction != null)
                                OnLookingToOpenAction();
                        }
                    }
                }
            }
        }

        private void OnRayStay(GameObject go)
        {
            //Debug.LogFormat("Player keep looking at {0}", go);
            timeToStay += Time.deltaTime;
            //Debug.LogFormat("Looking since: {0}", timeToStay);
            if (go.tag.Equals("Target/ToLook"))
            {
                if (timeToStay >= 2.0f)
                {
                    Destroy(go);
                }
            }

            if (go.tag.Equals("Target/ToPress"))
            {
                distanceToObject = Vector3.Distance(this.transform.position, go.transform.position);
                if (distanceToObject < 2.0f)
                {
                    playerController.ViewingObject = lookingObject;
                    if (OnLookingToPressAction != null)
                        OnLookingToPressAction();
                }
                else
                {
                    playerController.ViewingObject = null;
                    if (OnNotLookingToPressAction != null)
                        OnNotLookingToPressAction();
                }
            }

            if (go.tag.Equals("Object/ToOpen"))
            {
                distanceToObject = Vector3.Distance(this.transform.position, go.transform.position);
                if (distanceToObject < 3.0f)
                {
                    if (go.GetComponent<CupBoard>())
                    {
                        if (go.GetComponent<CupBoard>().OpenState)
                        {
                            playerController.ViewingObject = lookingObject;
                            if (OnLookingToOpenAction != null)
                                OnLookingToOpenAction();
                        }
                    }
                }
            }
        }

        private void OnRayExit(GameObject go)
        {
            //Debug.LogFormat("Player doesn't look {0} anymore", go);
            timeToStay = 0.0f;
            lookingObject = null;

            if (go.tag.Equals("Target/ToPress"))
            {
                playerController.InteractableObject = lookingObject;
                if (OnNotLookingToPressAction != null)
                    OnNotLookingToPressAction();
            }

            if (go.tag.Equals("Object/ToOpen"))
            {
                playerController.ViewingObject = lookingObject;
                if (OnNotLookingToOpenAction != null)
                    OnNotLookingToOpenAction();
            }
        }

        #endregion
    }
}