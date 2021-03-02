/* Copyright 2021
 * author: LEROUGE Ludovic
 * TheRed Games FrameWorkRed
 * All rights reserved
 */
using System.Collections;
using System.Collections.Generic;
using TheRed.Experience0.Desk;
using UnityEngine;

namespace TheRed.Experience0.StairsManager
{
    [AddComponentMenu("TheRed/Experience0/Stairs")]
    public class Stairs : MonoBehaviour
    {
        #region Public Fields

        public GameObject ToSub;

        #endregion

        #region Private Fields

        private Animator anim;
        private DeskManager deskManager = null;

        [SerializeField]
        private bool goDown = false;

        #endregion

        #region MonoBehaviour Callbacks

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            deskManager = ToSub.GetComponent<DeskManager>();
            deskManager.OnAllPressedButtonAction += OnAllPressedButton;
            deskManager.OnNotAllPressedButtonAction += OnNotAllPressedButton;
        }

        private void OnDisable()
        {
            deskManager.OnAllPressedButtonAction -= OnAllPressedButton;
            deskManager.OnNotAllPressedButtonAction -= OnNotAllPressedButton;
        }

        #endregion

        #region Private Callbacks

        private void OnAllPressedButton()
        {
            ActivateStairs();
        }

        private void OnNotAllPressedButton()
        {
            DesactivateStairs();
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods

        private void ActivateStairs()
        {
            if (!goDown)
            {
                this.goDown = true;
                anim.SetBool("GoDown", this.goDown);
            }
        }

        private void DesactivateStairs()
        {
            if (goDown)
            {
                this.goDown = false;
                anim.SetBool("GoDown", this.goDown);
            }
        }

        #endregion
    }
}