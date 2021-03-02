using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TRG = TheRed.Player.Controller;

namespace TheRed.UI
{
    [AddComponentMenu("TheRed/UI/PlayerUIFPS")]
    public class PlayerUIFPS : MonoBehaviour
    {
        #region Public Fields

        [Tooltip("Pixel offset from the player target")]
        [SerializeField]
        private Vector3 screenOffset = new Vector3(0f, 2f, 0f);
        public TextMesh playerNameText;

        #endregion

        #region Private Fields

        private TRG.PlayerController target;

        #endregion

        #region MonoBehaviour Callbacks
        // Start is called before the first frame update
        void Start()
        {
            target = this.transform.parent.GetComponent<TRG.PlayerController>();
            this.transform.position = this.transform.position + screenOffset;
        }

        // Update is called once per frame
        void Update()
        {
            if (target == null)
            {
                Destroy(this.gameObject);
                return;
            }
        }

        private void LateUpdate()
        {
            
        }

        #endregion

        #region Public Methods

        public void SetTarget(TRG.PlayerController _target)
        {
            if (_target == null)
            {
                Debug.LogError("<Color=Red><a>Missing</a></Color> PlayMakerManager target for PlayerUI.SetTarget.", this);
                return;
            }
            target = _target;

            if (playerNameText != null)
            {
                playerNameText.text = target.photonView.Owner.NickName;
            }
        }

        #endregion
    }
}