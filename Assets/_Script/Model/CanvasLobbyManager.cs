using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using TheRed.Multiplayer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TheRed.Model
{
    /*
     * This class allow to manage all canvas and interface from the lobby scene of the game
     */
    [AddComponentMenu("TheRed/Model/CanvasLobbyManager")]
    public class CanvasLobbyManager : MonoBehaviour
    {
        #region Public Fields
        public static CanvasLobbyManager Instance;
        public GameObject PlayerPanel;
        public GameObject ControlPanel;
        public GameObject CreatePanel;
        public GameObject CancelButton;
        public GameObject ProgressLabel;
        public GameObject ConnexionInfomation;
        public GameObject NumberRoom;
        #endregion

        #region Private Fields
        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            Instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            NumberRoom.GetComponent<TextMeshProUGUI>().text = "Room Available: " + PhotonNetwork.CountOfRooms;
        }

        private void OnEnable()
        {
            Lobby.OnConnectedToServer += OnConnectedToServerEvent;
            Lobby.OnDisconnectedToServer += OnDisconnectedToServerEvent;
            Lobby.OnConnectAction += OnConnectActionEvent;
            Lobby.OnCreateRoomAction += OnCreateActionEvent;
            Lobby.OnJoinRoomFailedAction += OnJoinRoomFailedEvent;
            Lobby.OnNotifyNumberOfRoom += OnNotifyNumberOfRoomAction;
        }

        private void OnDisable()
        {
            Lobby.OnConnectedToServer -= OnConnectedToServerEvent;
            Lobby.OnDisconnectedToServer -= OnDisconnectedToServerEvent;
            Lobby.OnConnectAction -= OnConnectActionEvent;
            Lobby.OnCreateRoomAction -= OnCreateActionEvent;
            Lobby.OnJoinRoomFailedAction -= OnJoinRoomFailedEvent;
            Lobby.OnNotifyNumberOfRoom -= OnNotifyNumberOfRoomAction;
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        /// <summary>
        /// Disable the progress label when you doesn't need it
        /// </summary>
        private void DisableProgressLabel()
        {
            ProgressLabel.SetActive(false);
        }

        #endregion

        #region Private Callbacks

        /// <summary>
        /// When the lobby is connected to the server let available the interface
        /// </summary>
        private void OnConnectedToServerEvent()
        {
            ProgressLabel.SetActive(false);
            CancelButton.GetComponent<Button>().interactable = false;
            ControlPanel.SetActive(true);
            ConnexionInfomation.GetComponent<TextMeshProUGUI>().text = "Connected to the online server";
            ConnexionInfomation.GetComponentInChildren<Image>().color = Color.green;
            ConnexionInfomation.SetActive(true);
            NumberRoom.SetActive(true);
        }

        private void OnDisconnectedToServerEvent()
        {
            ProgressLabel.SetActive(false);
            CancelButton.GetComponent<Button>().interactable = false;
            ControlPanel.SetActive(true);
            ConnexionInfomation.GetComponent<TextMeshProUGUI>().text = "Disconnected to the online server";
            ConnexionInfomation.GetComponentInChildren<Image>().color = Color.red;
            ConnexionInfomation.SetActive(true);
            NumberRoom.GetComponent<TextMeshProUGUI>().text = "Room Available: " + PhotonNetwork.CountOfRooms;
            NumberRoom.SetActive(false);
        }

        private void OnConnectActionEvent()
        {
            ProgressLabel.GetComponent<TextMeshProUGUI>().text = "Connecting ...";
            ProgressLabel.SetActive(true);
            CancelButton.GetComponent<Button>().interactable = true;
            ControlPanel.SetActive(false);
        }

        private void OnCreateActionEvent()
        {
            CancelInvoke("DisableProgressLabel");
            ProgressLabel.GetComponent<TextMeshProUGUI>().text = "Creating a room ...";
            ProgressLabel.SetActive(true);
            CancelButton.GetComponent<Button>().interactable = true;
            ControlPanel.SetActive(true);
            Invoke("DisableProgressLabel", 2.0f);
        }

        private void OnJoinRoomFailedEvent()
        {
            CancelInvoke("DisableProgressLabel");
            ProgressLabel.GetComponent<TextMeshProUGUI>().text = "Joining a room failed !";
            ProgressLabel.SetActive(true);
            CancelButton.GetComponent<Button>().interactable = true;
            ControlPanel.SetActive(true);
            Invoke("DisableProgressLabel", 2.0f);
        }

        private void OnNotifyNumberOfRoomAction()
        {
            NumberRoom.GetComponent<TextMeshProUGUI>().text = "Room Available: " + PhotonNetwork.CountOfRooms;
        }

        #endregion
    }
}