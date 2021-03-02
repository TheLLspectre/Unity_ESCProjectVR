using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheRed.Multiplayer
{
    [AddComponentMenu("TheRed/Multiplayer/Room")]
    public class PhotonRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks
    {
        #region Public Fields
        public static PhotonRoom Instance;

        public int SceneToLoad = 1;

        public bool IsOffline { get { return isOffline; } set { isOffline = value; } }
        #endregion
        
        #region Private Fields
        private Scene currentScene;
        private PhotonView pv;
        [SerializeField] private Photon.Realtime.Player[] playerList;
        [SerializeField] private int playersInRoom;

        private bool isOffline = false; // Variable to send data to the next scene
        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            /*if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }*/

            if (PhotonRoom.Instance == null)
            {
                PhotonRoom.Instance = this;
            }
            else
            {
                if (PhotonRoom.Instance != this)
                {
                    Destroy(PhotonRoom.Instance.gameObject);
                    PhotonRoom.Instance = this;
                }
            }
            DontDestroyOnLoad(this.gameObject);
            
        }

        // Start is called before the first frame update
        void Start()
        {
            pv = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void OnEnable()
        {
            base.OnEnable();
            PhotonNetwork.AddCallbackTarget(this);
            SceneManager.sceneLoaded += OnSceneFinishedLoading;
        }

        public override void OnDisable()
        {
            base.OnDisable();
            PhotonNetwork.RemoveCallbackTarget(this);
            SceneManager.sceneLoaded -= OnSceneFinishedLoading;
        }

        #endregion

        #region Pun Callbacks

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            Debug.LogWarning("Has joined room");
            playerList = PhotonNetwork.PlayerList;
            playersInRoom = playerList.Length;
            if (!PhotonNetwork.IsMasterClient)
                return;
            StartGame();
        }

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
        {
            base.OnPlayerEnteredRoom(newPlayer);
            Debug.LogWarning("New player has joined room");
            playerList = PhotonNetwork.PlayerList;
            playersInRoom = playerList.Length;
        }

        public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
        {
            base.OnPlayerLeftRoom(otherPlayer);
            Debug.LogWarning("New player has left room");
            playerList = PhotonNetwork.PlayerList;
            playersInRoom = playerList.Length;
        }

        #endregion

        #region Public Methods

        public void LaunchOfflineGame()
        {
            if (isOffline)
            {
                StartGame();
            }
        }

        #endregion

        #region Private Methods

        private void StartGame()
        {
            Debug.Log("Loading Level");
            PhotonNetwork.LoadLevel(this.SceneToLoad); // you can use the int index from the build list
        }

        private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
        {
            currentScene = scene;
        }

        #endregion
    }
}