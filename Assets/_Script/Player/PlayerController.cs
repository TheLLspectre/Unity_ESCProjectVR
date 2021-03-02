/* Copyright 2021
 * author: LEROUGE Ludovic
 * TheRed Games FrameWorkRed
 * All rights reserved
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TheRed.Multiplayer;
using UnityEngine.InputSystem;
using TheRed.Experience0.Desk;
using TheRed.Objects;
using TheRed.UI;

namespace TheRed.Player.Controller
{
    [AddComponentMenu("TheRed/Player/PlayerController")]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviourPunCallbacks, IPunObservable
    {
        //public
        #region Public Fields

        #region components
        [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
        public static GameObject LocalPlayerInstance;
        public PlayerInput InputAction { get { return inputActions; } set { inputActions = value; } }
        public Gamepad Gamepad { get { return gamepad; } set { gamepad = value; } }

        [Tooltip("The Player's UI GameObject Prefab")]
        [SerializeField]
        public GameObject PlayerUiPrefab; // The UI element to spawn when you're in the online mode.
        public GameObject CameraObject; // realy useful to control your own player during the game

        public GameObject InteractableObject { get { return interactableObject; } set { interactableObject = value; } }
        public GameObject ViewingObject { get { return viewingObject; } set { viewingObject = value; } }
        public GameObject ObjectHolded { get { return objectHolded; } set { objectHolded = value; } }
        public Transform RightHand { get { return rightHand; } set { rightHand = value; } }
        public Transform LeftHand { get { return leftHand; } set { leftHand = value; } }
        #endregion

        #region string
        public string Name { get { return playerName; } set { playerName = value; } }
        #endregion

        #region int
        #endregion

        #region float
        public float Health { get { return health; } set { health = value; } }
        public float WalkSpeed { get { return walkSpeed; } set { walkSpeed = value; } }
        public float RunSpeed { get { return runSpeed; } set { runSpeed = value; } }
        public float JumpSpeed { get { return jumpSpeed; } set { jumpSpeed = value; } }
        #endregion

        #region bool
        public bool Alive { get { return alive; } set { alive = value; } }
        public static bool LockAction { get { return lockAction; } set { lockAction = value; } }
        #endregion

        #region events
        // Event when the player push the pause button
        public delegate void OnPauseButtonActionHandler();
        public static event OnPauseButtonActionHandler OnPauseButtonAction;

        // Event when the player enter in the trigger of an object.
        public delegate void OnObjectEnterTriggerHandler();
        public static event OnObjectEnterTriggerHandler OnObjectEnterTrigger;

        // Event when the player leave the trigger of an object.
        public delegate void OnObjectExitTriggerHandler();
        public static event OnObjectExitTriggerHandler OnObjectExitTrigger;

        // Event when the player grab an object.
        public delegate void OnObjectTookHandler(GameObject interactableObject);
        public static event OnObjectTookHandler OnObjectTook;

        // Event when the player drop a holded object.
        public delegate void OnDropObjectHandler(string nameObject);
        public static event OnDropObjectHandler OnDropObject;

        // Event when the player enter in a trigger of an object to fill.
        public delegate void OnFillObjectEnterTriggerHandler();
        public static event OnFillObjectEnterTriggerHandler OnFillObjectEnterTrigger;

        // Event when the player leave the trigger of an object to fill.
        public delegate void OnFillObjectExitTriggerHandler();
        public static event OnFillObjectExitTriggerHandler OnFillObjectExitTrigger;

        //Event when the player enter in a trigger to open something
        public delegate void OnOpenObjectEnterTriggerHandler();
        public static event OnOpenObjectEnterTriggerHandler OnOpenObjectEnterTrigger;

        //Event when the player leave the trigger to open something
        public delegate void OnOpenObjectExitTriggerHandler();
        public static event OnOpenObjectExitTriggerHandler OnOpenObjectExitTrigger;

        //Event when the player active the openning of the door
        public delegate void OnOpenObjectActionHandler();
        public static event OnOpenObjectActionHandler OnOpenObjectAction;

        // Event when the player is in a trigger of a narrative part.
        public delegate void OnTriggerAndPressedHandler();
        public static event OnTriggerAndPressedHandler OnTriggerAndPressed;

        #endregion

        #endregion
        //private
        #region Private Fields

        #region components
        [Header("Physics Settings")]
        [SerializeField] private Transform checkGrounded; // The contact point, this one check if the player is on the ground.
        [SerializeField] private LayerMask groundMask; //Define on what you could stay and move with the player
        [Tooltip("This script register all objects what the player can have")]
        [SerializeField] private ObjectManager objectManager; // The object manager linked to this player.
        private CharacterController Controller = null; // The component character controller, to manage all movement.
        private Animator animator = null; // The Animator component to manage all animation from this character.

        //InputAction
        private PlayerInput inputActions = null; // The component which manage inputs.
        private Gamepad gamepad = null; // Variable to register if a gamepad is connected.

        private GameObject interactableObject = null; // Object to interact with.
        private GameObject viewingObject = null; // Object returning from the player Camera.
        private GameObject triggerObject = null; // Object which have a trigger activated.
        private GameObject objectHolded = null; // The object return by the Object Manager

        [Header("Hands")]
        [SerializeField] private Transform rightHand = null; // The right hand of the character
        [SerializeField] private Transform leftHand = null; // The left hand of the character

        // Vector3 moving is the main Vector to treat data to move the player
        private Vector3 moving = Vector3.zero; // The vector to manage update from input to move.
        private Vector2 moving2 = Vector2.zero; // The vector to manage update from view input to rotate.
        #endregion

        #region string
        [Header("Player Settings")]
        [SerializeField] private string playerName = "";
        #endregion

        #region int
        #endregion

        #region float

        [SerializeField] private float groundDistance = 0.4f; //The distance to detect the contact
        [SerializeField] private float health = 100.0f;
        [SerializeField] private float walkSpeed = 5.0f; // The walking speed
        [SerializeField] private float runSpeed = 12.5f; // The running speed
        [SerializeField] private float jumpSpeed = 1f; // The jump power.
        private float movingX = 0.0f;
        private float movingZ = 0.0f;
        
        #endregion

        #region bool
        [SerializeField]
        private bool isGrounded = false; // True when the player is on the ground.
        private bool contactObject = false; // Use when the player is in contact with an physic object like to grab it.
        private bool isInTrigger = false; // Use when the player is inside a trigger like to fill it with an holded object.
        [SerializeField]
        private bool holdObject = false; // True when the player hold an object
        private bool canFillObject = false; // True when the player is inside a trigger and he have an object which can interact with.
        private bool toOpen = false;

        private bool alive = false; // True while the player is alive.
        private bool runAction = false; // True when the input to run is pressed.
        private bool jumpAction = false; // True when the jump input is pressed.
        private static bool lockAction = false;
        #endregion

        #endregion
        #region MonoBehaviour Callbacks

        void Awake()
        {
            // #Important
            // used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
            if (!GameManager.Instance.isOffline)
            {
                if (photonView.IsMine)
                {
                    PlayerController.LocalPlayerInstance = this.gameObject;
                    CameraObject.SetActive(true);
                }
            }
            else
            {
                PlayerController.LocalPlayerInstance = this.gameObject;
                CameraObject.SetActive(true);
            }

            // #Critical
            // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
            DontDestroyOnLoad(this.gameObject);

            inputActions = new PlayerInput();
        }

        // Start is called before the first frame update
        void Start()
        {
            if (!GameManager.Instance.isOffline) // The application running online.
            {
                if (PlayerUiPrefab != null) // If the player UI Prefab is not empty.
                {
                    GameObject _uiGo = Instantiate(this.PlayerUiPrefab, this.transform); // Instantiate the ui prefab on this player.
                    _uiGo.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver); // Notify "SetTarget" methods to use them.
                }
                else
                {
                    Debug.LogWarning("<Color=Red><a>Missing</a></Color> PlayerUiPrefab reference on player Prefab.", this);
                }
            }

            Controller = GetComponent<CharacterController>(); // Get the characterController component from the gameObject
            animator = GetComponent<Animator>(); // Get the animator component from the gameObject.
            //Physics Parameters using the project Settings gravity setup from Unity
            moving.y += Physics.gravity.y * Time.deltaTime; // Update the moving vector with the gravity setting from the application.

#if UNITY_5_4_OR_NEWER
            // Unity 5.4 has a new scene management. register a method to call CalledOnLevelWasLoaded.
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
#endif
        }

        // Update is called once per frame
        void Update()
        {
            if (!GameManager.Instance.isOffline) // Always if the application run in the online mode.
            {
                if (!photonView.IsMine && PhotonNetwork.IsConnected == true) // If the online identifier is not the player one and the application is running online do nothing.
                    return;
                if (photonView.IsMine) // If the online identifier is the local player
                {
                    MovePlayer(); // Move this player

                    //ActionPlayer();
                    /**
                    *      MANAGE HEALTH'S PLAYER HERE --> like living the room
                    */

                }
            }
            else // If the application is running offline 
            {
                if (!CanvasManager.PauseAction && !lockAction)
                {
                    MovePlayer(); // Move this player
                    //ActionPlayer();
                }
                else // If the application is running offline 
                {
                    MovePlayer(); // Move this player
                    //ActionPlayer();
                }
            }
        }

        private void FixedUpdate()
        {
            // Check if a gamepad is connected
            gamepad = Gamepad.current;
            if (gamepad == null)
                return; // No gamepad connected.
            else
                Debug.Log("Gamepad Connected: " + gamepad.device + " " + gamepad.name);
        }

#if !UNITY_5_4_OR_NEWER
/// <summary>See CalledOnLevelWasLoaded. Outdated in Unity 5.4.</summary>
void OnLevelWasLoaded(int level)
{
this.CalledOnLevelWasLoaded(level);
}
#endif

        void CalledOnLevelWasLoaded(int level)
        {
            // check if we are outside the Arena and if it's the case, spawn around the center of the arena in a safe zone
            if (!Physics.Raycast(transform.position, -Vector3.up, 5f))
            {
                transform.position = new Vector3(0f, 5f, 0f);
            }

            /*GameObject _uiGo = Instantiate(this.PlayerUiPrefab);
            _uiGo.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver);*/
        }

        private void OnTriggerEnter(Collider other)
        {
            this.isInTrigger = true; // The player is inside a trigger.
            this.triggerObject = other.gameObject; // Get the object which containing the trigger activated.

            if (photonView.IsMine)
            {
                if (other.tag == "Object/ToTake") // If the object detected have a specific tag on
                {
                    if (OnObjectEnterTrigger != null) // Notify the event.
                        OnObjectEnterTrigger();
                    contactObject = true; // That mean the player can interact with the object
                    interactableObject = other.gameObject; // The object which can be interacted with is got.
                }
            }
            else if (GameManager.Instance.isOffline) // Do same action in offline mode
            {
                if (other.tag == "Object/ToTake")
                {
                    if (OnObjectEnterTrigger != null)
                        OnObjectEnterTrigger();

                    contactObject = true;
                    interactableObject = other.gameObject;
                }

                if (other.tag.Equals("Object/ToFill")) // If the object detected have a specific tag on
                {
                    if (holdObject) // If the player hold an object in the right hand.
                    {
                        if (OnFillObjectEnterTrigger != null) // Notify the event
                            OnFillObjectEnterTrigger();
                        if (other.gameObject.name.Contains(objectHolded.name)) // If the object to fill corresponding with the holded one.
                            canFillObject = true;
                        else // or not
                            canFillObject = false;
                    }   
                }

                if (other.tag.Equals("Object/ToOpen"))
                {
                    if (OnOpenObjectEnterTrigger != null)
                        OnOpenObjectEnterTrigger();

                    toOpen = true;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            this.isInTrigger = false; // The player are not longer in a trigger
            this.triggerObject = null; // Empty the object triggered.

            if (photonView.IsMine) // Do in online on the local instance.
            {
                if (other.tag == "Object/ToTake") // If the object have a specific tag on.
                {
                    if (OnObjectExitTrigger != null) // Notify the event
                        OnObjectExitTrigger();
                    contactObject = false; // The player can no longer interact with the object.
                    interactableObject = null; // The player can't grab the object so empty it.
                }

                if (other.tag.Equals("Object/ToFill")) // If the object have a specific tag on.
                {
                    if (holdObject) // If the player hold an object
                    {
                        if (OnFillObjectExitTrigger != null) // Notify the event
                            OnFillObjectExitTrigger();

                        canFillObject = false; // The player can no longer iteract with the other object.
                    }
                    else // Here the player have for example drop the object.
                        if (OnFillObjectExitTrigger != null) // Notify the event.
                            OnFillObjectExitTrigger();
                }
            }
            else if (GameManager.Instance.isOffline) // Do the same thing offline
            {
                if (other.tag == "Object/ToTake")
                {
                    if (OnObjectExitTrigger != null)
                        OnObjectExitTrigger();
                    contactObject = false;
                    interactableObject = null;
                }

                if (other.tag.Equals("Object/ToFill"))
                {
                    if (holdObject)
                    {
                        if (OnFillObjectExitTrigger != null)
                            OnFillObjectExitTrigger();

                        canFillObject = false;
                    }
                    else
                        if (OnFillObjectExitTrigger != null)
                            OnFillObjectExitTrigger();
                }

                if (other.tag.Equals("Object/ToOpen"))
                {
                    if (OnOpenObjectExitTrigger != null)
                        OnOpenObjectExitTrigger();

                    toOpen = false;
                }
            }
        }

        private void OnEnable()
        {
            inputActions.Enable(); // Active the new input system.
            SubscribeEvent(); // Subscribe to events
        }

        private void OnDisable()
        {
            inputActions.Disable(); // Disable the new input system.
            UnsubscribeEvent(); // Unsubscribe to events.
            UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded; // Unload the scene
        }

        #endregion
        #region Photon Callbacks
        /// <summary>
        /// Manage all informations to send or receive like health or firing
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="info"></param>
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            Debug.Log("OnPhotonSerializeView() called by PUN on player");
            if (stream.IsWriting)
            {
                // We own this player: send the others our data
                stream.SendNext(isGrounded);
                stream.SendNext(holdObject);
                //stream.SendNext(IsFiring);
                //stream.SendNext(Health);
            }
            else
            {
                // Network player, receive data
                this.isGrounded = (bool)stream.ReceiveNext();
                this.holdObject = (bool)stream.ReceiveNext();
                //this.IsFiring = (bool)stream.ReceiveNext();
                //this.Health = (float)stream.ReceiveNext();
            }
        }

        #endregion
        #region Private Methods

        private void MovePlayer()
        {
            isGrounded = Physics.CheckSphere(checkGrounded.position, groundDistance, groundMask);
            if (isGrounded)
            {
                if (moving.y < 0)
                {
                    moving.y = -2f;
                }

                if (!CanvasManager.PauseAction && !lockAction)
                {
                    moving2 = inputActions.Player.Move.ReadValue<Vector2>();
                    movingX = moving2.x;
                    movingZ = moving2.y;

                    // Allow the player to move
                    moving = transform.right * movingX + transform.forward * movingZ;
                    if (runAction)
                    {
                        moving *= this.RunSpeed;
                    }
                    else
                    {
                        moving *= this.WalkSpeed;
                    }
                    Controller.Move(moving * Time.deltaTime);

                    // Allow the player to jump
                    if (jumpAction)
                    {
                        // (racine carré)\/---jump * -2f * gravity
                        moving.y = Mathf.Sqrt(this.JumpSpeed * -2f * Physics.gravity.y);
                        moving.y += Physics.gravity.y * Time.deltaTime;
                    }

                    Controller.Move(moving * Time.deltaTime);
                }
            }
            else
            {
                moving.y += Physics.gravity.y * Time.deltaTime;
                //deltaY = 1/2gravity * time²
                Controller.Move(moving * Time.deltaTime);
            }
        }

        // Pause Action
        /// <summary>
        /// When the pause input is pressed Notify the interface to display menu online and offline.
        /// </summary>
        private void OnPauseActionStarted()
        {
            if (photonView.IsMine)
            {
                if (OnPauseButtonAction != null)
                    OnPauseButtonAction();
            }
            else if (GameManager.Instance.isOffline)
            {
                if (OnPauseButtonAction != null)
                    OnPauseButtonAction();
            }
        }

        //Jump Action
        /// <summary>
        /// At the beginning of the pressure on the jump input
        /// </summary>
        private void OnJumpActionStarted()
        {
            if (lockAction && !CanvasManager.PauseAction)
            {
                if (OnTriggerAndPressed != null)
                    OnTriggerAndPressed();
            }
            else
            {
                jumpAction = true; // Player is jumping
            }
        }

        private void OnJumpActionPerformed()
        {

        }

        private void OnJumpActionCanceled()
        {
            jumpAction = false; // Player is no longer jumping
        }

        //Run Action
        private void OnRunActionStarted()
        {
            runAction = true;
        }

        private void OnRunActionPerformed()
        {

        }

        private void OnRunActionCanceled()
        {
            runAction = false;
        }

        //Fire Action
        private void OnFireActionStarted()
        {
            if (!holdObject && photonView.IsMine)
            {
                animator.SetBool("RightHandPunch", true);
            }
            else if (!holdObject && GameManager.Instance.isOffline)
            {
                animator.SetBool("RightHandPunch", true);
            }

            if (viewingObject != null) // If there is an interactable object available
            {
                if (viewingObject.tag.Equals("Target/ToPress")) // If the interactable object is a to press one.
                {
                    viewingObject.GetComponentInParent<Desk>().PushButton(); // Get the function from the object to trigger it.
                }
            }
        }

        private void OnFireActionPerformed()
        {
            if (!holdObject && photonView.IsMine)
            {
                animator.SetBool("RightHandPunch", true);
            }
            else if (!holdObject && GameManager.Instance.isOffline)
            {
                animator.SetBool("RightHandPunch", true);
            }
        }

        private void OnFireActionCanceled()
        {
            animator.SetBool("RightHandPunch", false);
        }

        //Take Action
        /// <summary>
        /// When the player press the take button.
        /// </summary>
        private void OnTakeActionStarted()
        {
            //Take Action
            if (photonView.IsMine)
            {
                photonView.RPC("RPC_TestTakeAction", RpcTarget.AllBuffered);
            }


            // The player doesn't hold an object.
            if (contactObject && photonView.IsMine) // If there is a physic object in contact and you're online
            {
                holdObject = true; // The player take the object so switch to true
                contactObject = false; // Taking the object so the physic one disappear.

                if (OnObjectTook != null) // Notify the event.
                    OnObjectTook(interactableObject);

                // RPC Photon methods send & synchronize data to the network. USE ONLY BASIC TYPE
                photonView.RPC("RPC_Destroy", RpcTarget.MasterClient, interactableObject.GetComponent<PhotonView>().ViewID);
            }
            else if (GameManager.Instance.isOffline) // Do the same offline
            {
                if (contactObject)
                {
                    holdObject = true;
                    contactObject = false;
                    if (OnObjectTook != null)
                        OnObjectTook(interactableObject);
                    Destroy(interactableObject); //Destroy the gameObject
                    return;
                }

                if (toOpen)
                {
                    if (this.triggerObject != null)
                        if (this.triggerObject.GetComponent<CupBoard>())
                        {
                            this.triggerObject.GetComponent<CupBoard>().OpenCloseDoor();
                            toOpen = false;
                            return;
                        }
                        else
                            this.triggerObject = null;
                }

                if (viewingObject != null)
                {
                    if (viewingObject.tag.Equals("Object/ToOpen"))
                    {
                        viewingObject.GetComponent<CupBoard>().OpenCloseDoor();
                        return;
                    }
                }

                if (isInTrigger) // Do the same offline, if the player is in a trigger
                {
                    if (canFillObject && holdObject) // The player hold an object and is in front of an other one which can interact with the holded object.
                    {
                        this.triggerObject.GetComponent<FillObject>().Fill(); // From the trigger object launch fill methods
                        this.holdObject = false; // Drop the object so false
                        this.canFillObject = false; // And the player can no longer be interacted with.

                        if (OnDropObject != null) // Notify the event
                            OnDropObject(this.triggerObject.name);
                        return;
                    }
                    else //Wrong Object displaying
                    {

                    }
                }
            }
        }

        [PunRPC]
        private void RPC_TestTakeAction()
        {
            Debug.Log("Test Launching RPC from " + photonView.Owner.NickName);
        }

        [PunRPC]
        private void RPC_Destroy(int pv)
        {
            PhotonNetwork.Destroy(PhotonView.Find(pv).gameObject);
        }

        private void OnTakeActionPerformed()
        {

        }

        private void OnTakeActionCanceled()
        {

        }

        /// <summary>
        /// Subscribe to all event
        /// A big part is from the new input system.
        /// </summary>
        private void SubscribeEvent()
        {
            //Move Action
            /*inputActions.Player.Move.started += ctx => OnMoveActionStarted();
            inputActions.Player.Move.performed += ctx => OnMoveActionPerformed();
            inputActions.Player.Move.canceled += ctx => OnMoveActionCanceled();*/

            //Jump Action
            inputActions.Player.Jump.started += ctx => OnJumpActionStarted();
            inputActions.Player.Jump.performed += ctx => OnJumpActionPerformed();
            inputActions.Player.Jump.canceled += ctx => OnJumpActionCanceled();

            //Pause Action
            inputActions.Player.Pause.started += ctx => OnPauseActionStarted();
            /*inputActions.Player.Pause.performed += ctx => OnPauseActionPerformed();
            inputActions.Player.Pause.canceled += ctx => OnPauseActionCanceled;*/

            //Take Action
            inputActions.Player.Take.started += ctx => OnTakeActionStarted();
            inputActions.Player.Take.performed += ctx => OnTakeActionPerformed();
            inputActions.Player.Take.canceled += ctx => OnTakeActionCanceled();

            //Run Action
            inputActions.Player.Run.started += ctx => OnRunActionStarted();
            inputActions.Player.Run.performed += ctx => OnRunActionPerformed();
            inputActions.Player.Run.canceled += ctx => OnRunActionCanceled();

            //Fire Action
            inputActions.Player.Fire.started += ctx => OnFireActionStarted();
            inputActions.Player.Fire.performed += ctx => OnFireActionPerformed();
            inputActions.Player.Fire.canceled += ctx => OnFireActionCanceled();
        }

        /// <summary>
        /// Unsubscribe to all event
        /// A big part is from the new input system.
        /// </summary>
        private void UnsubscribeEvent()
        {
            //Move Action
            /*inputActions.Player.Move.started -= ctx => OnMoveActionStarted();
            inputActions.Player.Move.performed -= ctx => OnMoveActionPerformed();
            inputActions.Player.Move.canceled -= ctx => OnMoveActionCanceled();*/

            //Jump Action
            inputActions.Player.Jump.started -= ctx => OnJumpActionStarted();
            inputActions.Player.Jump.performed -= ctx => OnJumpActionPerformed();
            inputActions.Player.Jump.canceled -= ctx => OnJumpActionCanceled();

            //Pause Action
            inputActions.Player.Pause.started -= ctx => OnPauseActionStarted();
            /*inputActions.Player.Pause.performed -= ctx => OnPauseActionPerformed();
            inputActions.Player.Pause.canceled -= ctx => OnPauseActionCanceled();*/

            //Take Action
            inputActions.Player.Take.started -= ctx => OnTakeActionStarted();
            inputActions.Player.Take.performed -= ctx => OnTakeActionPerformed();
            inputActions.Player.Take.canceled -= ctx => OnTakeActionCanceled();

            //Run Action
            inputActions.Player.Run.started -= ctx => OnRunActionStarted();
            inputActions.Player.Run.performed -= ctx => OnRunActionPerformed();
            inputActions.Player.Run.canceled -= ctx => OnRunActionCanceled();

            //Fire Action
            inputActions.Player.Fire.started -= ctx => OnFireActionStarted();
            inputActions.Player.Fire.performed -= ctx => OnFireActionPerformed();
            inputActions.Player.Fire.canceled -= ctx => OnFireActionCanceled();
        }

#if UNITY_5_4_OR_NEWER
        void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode loadingMode)
        {
            this.CalledOnLevelWasLoaded(scene.buildIndex);
        }
#endif

        #endregion
        #region Public Methods

        public void InitCharacter()
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(float damagePoint)
        {
            this.health -= damagePoint;
        }

        public bool IsAlive()
        {
            if (this.health <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(checkGrounded.position, groundDistance);
        }
#endif
    }
}