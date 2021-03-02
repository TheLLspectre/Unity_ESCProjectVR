/* Copyright 2021
 * author: LEROUGE Ludovic
 * TheRed Games FrameWorkRed
 * All rights reserved
 */
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TRG = TheRed.Player.Controller;
using TheRed.Multiplayer;
using UnityEngine;

namespace TheRed.Objects
{
    [AddComponentMenu("TheRed/Player/ObjectManager")]
    public class ObjectManager : MonoBehaviourPun
    {
        #region Public Fields
        public GameObject[] ObjectInventory; // Fill with object can be holded
        public PhotonView pv; // It's own identity on the network
        #endregion

        #region Private Fields
        [SerializeField]
        private int indexObject = -1; // A flag in the array to know which one is holded.
        #endregion

        #region MonoBehaviour Callbacks

        // Start is called before the first frame update
        void Start()
        {
            DisableAllObjects(); // At the beginning Disable all object in the hand.
            pv = GetComponent<PhotonView>(); // Get the Photon View Component on the gameObject.
        }

        /// <summary>
        /// Subscribe to all event
        /// </summary>
        private void OnEnable()
        {
            TRG.PlayerController.OnObjectTook += OnObjectTook; // From the player controller
            TRG.PlayerController.OnDropObject += OnDropObject;
        }

        /// <summary>
        /// Unsubscribe to all event
        /// </summary>
        private void OnDisable()
        {
            TRG.PlayerController.OnObjectTook -= OnObjectTook; // From the player controller.
            TRG.PlayerController.OnDropObject -= OnDropObject;
        }

        #endregion

        #region Private Callbacks

        /// <summary>
        /// Launch with notification from an event.
        /// The player grab an object.
        /// </summary>
        /// <param name="nameObject"> The name of the object in the world to grab </param>
        private void OnObjectTook(GameObject interactableObject)
        {
            GameObject toFind = null; // Initialize an empty gameObject to receive the one to activate.
            for (int i = 0; i < ObjectInventory.Length; i++) // Go through all gameobject in the weapon manager
            {
                if (ObjectInventory[i].name.Equals(interactableObject.name) || ObjectInventory[i].name.Contains(interactableObject.name)) // When the weapon, according to its name, is finded
                {
                    toFind = ObjectInventory[i]; // Get the weapon's gameObject in toFind variable.
                    indexObject = i; // Also get the index of this weapon
                    break;
                }
            }

            if (photonView.IsMine)
            {
                Debug.Log("Allow it on" + photonView.Owner.NickName);
                if (toFind != null)
                    photonView.RPC("RPC_ActiveObject", RpcTarget.AllBuffered, toFind.GetComponent<PhotonView>().ViewID); // Pass through the network to allow all player to see you are holding something.
                //toFind.SetActive(true);
            }
            else if (GameManager.Instance.isOffline)
            {
                if (toFind != null)
                {
                    toFind.SetActive(true);
                    TRG.PlayerController.LocalPlayerInstance.GetComponent<TRG.PlayerController>().ObjectHolded = toFind; // Fill the player controller variable with the one holded.
                }
            }
        }

        /// <summary>
        /// On the notification of the dropping event.
        /// </summary>
        /// <param name="nameObject"> Get the name of the holding object </param>
        private void OnDropObject(string nameObject)
        {
            GameObject toFind = null; // Initialize an empty gameObject to receive the one to activate.
            toFind = ObjectInventory[indexObject]; // get the object holded thanks to the flag.
            indexObject = -1; // Reset the flag with nothing

            if (photonView.IsMine)
            {
                Debug.Log("Allow it on" + photonView.Owner.NickName);
                if (toFind != null)
                    photonView.RPC("RPC_DesactiveObject", RpcTarget.AllBuffered, toFind.GetComponent<PhotonView>().ViewID);
                //toFind.SetActive(true);
            }
            else if (GameManager.Instance.isOffline)
            {
                if (toFind != null)
                {
                    toFind.SetActive(false);
                    TRG.PlayerController.LocalPlayerInstance.GetComponent<TRG.PlayerController>().ObjectHolded = null;
                }
            }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods

        private void DisableAllObjects()
        {
            if (ObjectInventory.Length > 0)
            {
                foreach (GameObject go in ObjectInventory)
                {
                    if (go != null)
                        go.SetActive(false);
                }
            }
            return;
        }

        [PunRPC]
        private void RPC_ActiveObject(int pvID)
        {
            PhotonView.Find(pvID).gameObject.SetActive(true);
        }

        [PunRPC]
        private void RPC_DesactivateObject(int pvID)
        {
            PhotonView.Find(pvID).gameObject.SetActive(false);
        }
        #endregion
    }
}