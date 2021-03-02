using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

namespace TheRed.Multiplayer
{
    public class Launcher : MonoBehaviourPunCallbacks
    {
        #region Private Serializable Fields
        ///<summary>
        ///The maximum number of players per room. When a room is ful, it can't be joinde by new players, and so new room will be created.
        ///</summary>
        [Tooltip("The maximum number of players per room. When a room is ful, it can't be joinde by new players, and so new room will be created.")]
        [SerializeField] private byte maxPlayersPerRoom = 4;
        #endregion

        #region Private fields
        /// <summary>
        /// This client's version number. Users are separated from each other by gameversion
        /// </summary>
        string gameVersion = "1";
        /// <summary>
        /// Keep track of the current process. Since connection is asynchronous and is based on several callbacks from Photon,
        /// we need to keep track of this to properly adjust the behavior when we receive call back by Photon.
        /// Typically this is used for the OnConnectedToMaster() callback.
        /// </summary>
        bool isConnecting;
        #endregion

        #region Public Fields
        [Tooltip("The UI Panel let the user enter the name, connect and play")]
        [SerializeField] private GameObject controlPanel;

        [Tooltip("The UI Label to inform the user that the connection is in progress")]
        [SerializeField] private GameObject progressLabel;

        [Tooltip("The button when the player want to leave the joining action.")]
        [SerializeField] private GameObject cancelButton;
        #endregion

        #region MonoBehaviour CallBacks

        /// <summary>
        /// MonoBehaviour methods called on GameObject by Unity during early initialization phase
        /// </summary>
        private void Awake()
        {
            // #Critical
            // this makes sure we can use PhotonNetwork.loadLevel() on the master client and all clients in the same room sync their level automatically
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        // Start is called before the first frame update
        void Start()
        {
            //Connect();
            progressLabel.SetActive(false);
            cancelButton.GetComponent<Button>().interactable = false;

            controlPanel.SetActive(true);
        }
        #endregion

        #region MonoBehaviourPunCallBacks CallBacks
        public override void OnConnectedToMaster()
        {
            Debug.Log("PUN Basics Tutorial/launcher: OnConnectedToMaster() was called by PUN");
            if (isConnecting)
            {
                PhotonNetwork.JoinRandomRoom();
                isConnecting = false;
            }
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);

            isConnecting = false;
            Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0} ", cause);
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was ccalled by PUN. No random room available, so we create one. \nCalling: PhotonNetwork.CreateRoom");

            // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        }

        /// <summary>
        /// When the player join a room
        /// </summary>
        public override void OnJoinedRoom()
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
        }

        #endregion

        #region Public Methods

        public void Connect()
        {
            progressLabel.SetActive(true);
            cancelButton.GetComponent<Button>().interactable = true;
            controlPanel.SetActive(false);

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

        public void OnCancelButtonClicked()
        {
            cancelButton.GetComponent<Button>().interactable = false;
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
            PhotonNetwork.LeaveRoom();
        }

        #endregion
    }
}