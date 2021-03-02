/* Copyright 2021
 * author: LEROUGE Ludovic
 * TheRed Games FrameWorkRed
 * All rights reserved
 */
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TheRed.Multiplayer;
using TRG = TheRed.Player.Controller;
using UnityEngine;

namespace TheRed.Player.Weapon
{
    [AddComponentMenu("TheRed/Player/WeaponManager")]
    public class WeaponManager : MonoBehaviourPun
    {
        #region Public Fields
        public GameObject[] WeaponInventory;
        public PhotonView pv;
        #endregion

        #region Private Fields
        [SerializeField]
        private int indexWeapon = -1;
        #endregion

        #region MonoBehaviour Callbacks

        // Start is called before the first frame update
        void Start()
        {
            DisableAllWeaponObjects();
            pv = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnEnable()
        {
            //TRG.PlayerController.OnWeaponTook += OnWeaponTook;
        }

        private void OnDisable()
        {
            //TRG.PlayerController.OnWeaponTook -= OnWeaponTook;
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods

        private void DisableAllWeaponObjects()
        {
            if (WeaponInventory.Length > 0)
            {
                foreach (GameObject go in WeaponInventory)
                {
                    if (go != null)
                        go.SetActive(false);
                }
            }
            return;
        }


        private void OnWeaponTook(string nameWeapon)
        {
            GameObject toFind = null; // Initialize an empty gameObject to receive the one to activate.
            for (int i = 0; i < WeaponInventory.Length; i++) // Go through all gameobject in the weapon manager
            {
                if (WeaponInventory[i].name.Equals(nameWeapon) || WeaponInventory[i].name.Contains(nameWeapon)) // When the weapon, according to its name, is finded
                {
                    toFind = WeaponInventory[i]; // Get the weapon's gameObject in toFind variable.
                    indexWeapon = i; // Also get the index of this weapon
                    break;
                }
            }

            if (photonView.IsMine)
            {
                Debug.Log("Allow it on" + photonView.Owner.NickName);
                if (toFind != null)
                    photonView.RPC("RPC_ActiveWeapon", RpcTarget.AllBuffered, toFind.GetComponent<PhotonView>().ViewID);
                    //toFind.SetActive(true);
            }
            else if (GameManager.Instance.isOffline)
            {
                if (toFind != null)
                    toFind.SetActive(true);
            }
        }

        [PunRPC]
        private void RPC_ActiveWeapon(int pvID)
        {
            PhotonView.Find(pvID).gameObject.SetActive(true);
        }
        #endregion
    }
}