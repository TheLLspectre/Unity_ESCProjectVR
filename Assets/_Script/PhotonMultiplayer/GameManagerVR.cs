/* Copyright 2021
 * author: LEROUGE Ludovic
 * TheRed Games FrameWorkRed
 * All rights reserved
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TheRed.Model;
using TheRed.UI;
using TRG = TheRed.Player.XRController;

namespace TheRed.Multiplayer
{
    [AddComponentMenu("TheRed/Multiplayer/VR/GameManagerVR")]
    public class GameManagerVR : MonoBehaviourPunCallbacks
    {
        #region Public Fields

        public static GameManagerVR Instance;

        [Tooltip("The prefab to use for representing the player")]
        public GameObject playerPrefabVR;

        [Tooltip("Offline mode")]
        public bool isOffline;
        #endregion

        #region MonoBehaviours Callbacks

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                //DontDestroyOnLoad(this.gameObject);
            }
            /*else
            {
                Destroy(this.gameObject);
            }*/
        }

        private void Start()
        {
            if (!isOffline) // If is online
            {
                if (playerPrefabVR == null)
                    Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
                else
                {
                    if (TRG.XRPlayerController.LocalPlayerInstance == null)
                    {
                        Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                        // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                        //Use a spawn point
                        GameObject sp = GameSetup.Instance.GetSpawnPoint(0);
                        if (sp != null)
                            PhotonNetwork.Instantiate(this.playerPrefabVR.name, sp.transform.position, sp.transform.rotation, 0);
                        else
                            PhotonNetwork.Instantiate(this.playerPrefabVR.name, new Vector3(0f, 10f, 0f), Quaternion.identity, 0);
                    }
                    else
                    {
                        Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
                    }
                }
            }
            else
            {
                GameObject sp = GameSetup.Instance.GetSpawnPoint(0);
                if (sp != null)
                {
                    TRG.XRPlayerController.LocalPlayerInstance.transform.position = sp.transform.position;
                    TRG.XRPlayerController.LocalPlayerInstance.transform.rotation = sp.transform.rotation;
                }
                else
                {
                    TRG.XRPlayerController.LocalPlayerInstance.transform.position = new Vector3(0, 10, 0);
                    TRG.XRPlayerController.LocalPlayerInstance.transform.rotation = Quaternion.identity;
                }
            }
        }

        private void OnEnable()
        {
            if (PhotonRoom.Instance != null) // Check if an instance of a multiplayer room is available on the loading
                if (PhotonRoom.Instance.IsOffline) // Check the offline mode
                    this.isOffline = true;
                else // If there isn't an instance
                    this.isOffline = false;
        }

        #endregion

        #region Photon Callbacks

        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player other)
        {
            Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting

            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPLayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerleftRoom

                //LoadArena();
            }
        }

        public override void OnPlayerLeftRoom(Photon.Realtime.Player other)
        {
            Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects
            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom
            }
        }

        #endregion

        #region Public Methods

        public void DisconnectPlayer()
        {
            if (!isOffline) // The player is online
            {
                StartCoroutine("DisconnectAndLoad");
            }
            else // The player is offline
            {
                ReleasedCanvas();
                //Destroy(TRG.PlayerController.LocalPlayerInstance.gameObject);
                SceneManager.LoadScene(0);
            }
        }

        IEnumerator DisconnectAndLoad()
        {
            PhotonNetwork.LeaveRoom();
            while (PhotonNetwork.InRoom)
                yield return null;
            ReleasedCanvas();
            SceneManager.LoadScene(0);
        }

        #endregion

        #region Private Methods

        void LoadArena()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
            }
            Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
            //PhotonNetwork.LoadLevel(/*SceneToLoad*/);
        }

        private void ReleasedCanvas()
        {
            Destroy(CanvasManager.Instance.gameObject);
            Destroy(CanvasMultiplayerManager.Instance.gameObject);
        }

        #endregion
    }
}