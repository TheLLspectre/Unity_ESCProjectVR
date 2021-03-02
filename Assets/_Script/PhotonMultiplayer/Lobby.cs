/* Copyright 2021
 * author: LEROUGE Ludovic
 * TheRed Games FrameWorkRed
 * All rights reserved
 */
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheRed.Multiplayer
{
    [AddComponentMenu("TheRed/Multiplayer/Lobby")]
    public class Lobby : MonoBehaviourPunCallbacks
    {
        #region Public Fields
        public static Lobby lobby;

        public byte NumberOfRoomAvailable { get { return numberOfRoomAvailable; } }
        #endregion

        #region Private Fields
        [Tooltip("The UI Panel let the user enter the name, connect and play")]
        [SerializeField] private GameObject controlPanel;

        [Tooltip("The UI Label to inform the user that the connection is in progress")]
        [SerializeField] private GameObject progressLabel;

        [Tooltip("The button when the player want to leave the joining action.")]
        [SerializeField] private GameObject cancelButton;

        /// <summary>
        /// This client's version number. Users are separated from each other by gameversion
        /// </summary>
        private string gameVersion = "1";

        [SerializeField]
        private int framerateLocker = 30;

        /// <summary>
        /// Keep track of the current process. Since connection is asynchronous and is based on several callbacks from Photon,
        /// we need to keep track of this to properly adjust the behavior when we receive call back by Photon.
        /// Typically this is used for the OnConnectedToMaster() callback.
        /// </summary>
        private bool isConnecting;

        [Tooltip("The maximum number of players per room. When a room is ful, it can't be joinde by new players, and so new room will be created.")]
        [SerializeField] private byte defaultMaxPlayerPerRoom = 4;

        private byte numberOfRoomAvailable = 0;

        #region events
        public delegate void OnConnectedToServerHandler();
        public static event OnConnectedToServerHandler OnConnectedToServer;

        public delegate void OnDisconnectedToServerHandler();
        public static event OnDisconnectedToServerHandler OnDisconnectedToServer;

        public delegate void OnConnectActionHandler();
        public static event OnConnectActionHandler OnConnectAction;

        public delegate void OnCreateRoomActionHandler();
        public static event OnCreateRoomActionHandler OnCreateRoomAction;

        public delegate void OnJoinRoomFailedActionHandler();
        public static event OnJoinRoomFailedActionHandler OnJoinRoomFailedAction;

        private delegate void OnNumberOfRoomChangedHandler();
        private event OnNumberOfRoomChangedHandler OnNumberOfRoomChanged;
        public delegate void OnNotifyNumberOfRoomHandler();
        public static event OnNotifyNumberOfRoomHandler OnNotifyNumberOfRoom;

        #endregion

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            Application.targetFrameRate = framerateLocker;

            lobby = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            isConnecting = PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;

            OnNumberOfRoomChanged += OnNumberOfRoomChangedAction;

            numberOfRoomAvailable = (byte)PhotonNetwork.CountOfRooms;
        }

        private void LateUpdate()
        {
            if (numberOfRoomAvailable != PhotonNetwork.CountOfRooms)
                OnNumberOfRoomChanged();
        }

        /*private void OnEnable()
        {
            OnNumberOfRoomChanged += OnNumberOfRoomChangedAction;
        }

        private void OnDisable()
        {
            OnNumberOfRoomChanged -= OnNumberOfRoomChangedAction;
        }*/

        #endregion

        #region Pun Callbacks

        public override void OnConnectedToMaster()
        {
            Debug.Log("PUN Basics Tutorial/launcher: OnConnectedToMaster() was called by PUN");
            // #Critical
            // this makes sure we can use PhotonNetwork.loadLevel() on the master client and all clients in the same room sync their level automatically
            if (PhotonNetwork.IsConnected)
            {
                Debug.Log("You are connected on the Master");
                PhotonNetwork.AutomaticallySyncScene = true;

                // Trigger an event if the client is connected to the master Photon
                if (OnConnectedToServer != null)
                    OnConnectedToServer();
            }
        }

        /// <summary>
        /// When the player join a room
        /// </summary>
        /*public override void OnJoinedRoom()
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");

            // #Critical: We only load if we are the first player, else we rely on `PhotonNetwork.AutomaticallySyncScene` to sync our instance scene.
            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                Debug.Log("We load the 'Room for 1' ");


                // #Critical
                // Load the Room Level.
                PhotonNetwork.LoadLevel("Prototypage");
            }
        }*/
        public override void OnCreatedRoom()
        {
            base.OnCreatedRoom();

            if (OnCreateRoomAction != null)
                OnCreateRoomAction();
        }


        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("Joining a room failed... That's may mean there isn't room available");

            // Trigger an event when the joining room action failed
            if (OnJoinRoomFailedAction != null)
                OnJoinRoomFailedAction();

            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = defaultMaxPlayerPerRoom });
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            // Trigger an event if the client is disconnected to the master Photon
            if (OnDisconnectedToServer != null)
                OnDisconnectedToServer();

            isConnecting = false;
            Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0} ", cause);
        }

        #endregion

        #region Public Methods

        public void Connect()
        {
            if (OnConnectAction != null)
                OnConnectAction();

            //we check if we are connected or not, we join if we are, else we initiate the connection to the server.
            if (PhotonNetwork.IsConnected)
            {
                // #Critical we need at this point to attelot joining a Random Room. if it fails, we'll get notified in OnJoinrandomfailled() and we'll create one.
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                // #Critical, we must first and foremost connect to Photon Online server.
                isConnecting = PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
            }
        }

        public void JoinOffline()
        {
            PhotonNetwork.Disconnect();
            while (!PhotonNetwork.IsConnected) ;
            PhotonNetwork.OfflineMode = true;
            PhotonRoom.Instance.IsOffline = true;
            PhotonRoom.Instance.LaunchOfflineGame();
        }

        public void OnCancelButtonClicked()
        {
            cancelButton.GetComponent<Button>().interactable = false;
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
            PhotonNetwork.LeaveRoom();
        }

        #endregion

        #region Private Methods

        private void OnNumberOfRoomChangedAction()
        {
            numberOfRoomAvailable = (byte)PhotonNetwork.CountOfRooms;
            if (OnNumberOfRoomChanged != null)
                OnNotifyNumberOfRoom();
        }

        #endregion
    }
}