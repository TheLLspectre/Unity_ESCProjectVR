using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TheRed.UI
{
    [AddComponentMenu("TheRed/UI/CMultiplayerInterface")]
    public class CanvasMultiplayerManager : MonoBehaviourPunCallbacks
    {
        #region Public Fields
        public static CanvasMultiplayerManager Instance;
        [Tooltip("The element in the canvas which allow you to display information on connexion or else to all players.")]
        public GameObject FeedGrid;
        public GameObject FeedInformationPrefab;

        #endregion

        #region Private Fields

        private GameObject feedInformation;

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            if (CanvasMultiplayerManager.Instance == null)
            {
                CanvasMultiplayerManager.Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods
        #endregion

        #region Pun Callbacks

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
        {
            //base.OnPlayerEnteredRoom(newPlayer);
            this.feedInformation = Instantiate(this.FeedInformationPrefab, this.FeedGrid.transform);
            this.feedInformation.GetComponent<TextMeshProUGUI>().text = newPlayer.NickName + " has joined the game";
            Destroy(this.feedInformation, 2.5f);
        }

        public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
        {
            this.feedInformation = Instantiate(this.FeedInformationPrefab, this.FeedGrid.transform);
            this.feedInformation.GetComponent<TextMeshProUGUI>().text = otherPlayer.NickName + " has left the game";
            Destroy(this.feedInformation, 2.5f);
        }

        #endregion
    }
}