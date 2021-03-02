using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TRG = TheRed.Player.Controller;

namespace TheRed.UI
{
    [AddComponentMenu("TheRed/UI/PlayerUI")]
    public class PlayerUI : MonoBehaviour
    {
        #region Public Fields

        [Tooltip("Pixel offset from the player target")]
        [SerializeField]
        private Vector3 screenOffset = new Vector3(0f, 30f, 0f);

        #endregion

        #region Private Fields

        private TRG.PlayerController target; // The player to follow
        [Tooltip("UI Text to display Player's Name")]
        [SerializeField]
        private TextMeshProUGUI playerNameText;

        private Transform targetTransform;
        private Renderer targetRenderer;
        private CanvasGroup _canvasGroup;
        private Vector3 targetPosition;
        private float characterControllerHeight = 0f;

        #endregion

        #region MonoBehaviours Callbacks

        private void Awake()
        {
            
        }

        // Start is called before the first frame update
        void Start()
        {
            this.transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);// .Find() is not the best to do but the quickest
            _canvasGroup = this.GetComponent<CanvasGroup>();
        }

        // Update is called once per frame
        void Update()
        {
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }

            //Reflect the player Health for example -->
            /*if (playerHealthSlider != null)
            {
                playerHealthSlider.value = target.Health;
            }*/
        }

        void LateUpdate()
        {
            // Do not show the UI if we are not visible to the camera, thus avoid potential bugs with seeing the UI, but not the player itself.
            if (targetRenderer != null)
            {
                this._canvasGroup.alpha = targetRenderer.isVisible ? 1f : 0f;
            }

            // #Critical
            // Follow the Target GameObject on screen.
            if (targetTransform != null)
            {
                targetPosition = targetTransform.position;
                targetPosition.y += characterControllerHeight;
                this.transform.position = this.GetComponent<Camera>().WorldToScreenPoint(targetPosition) + screenOffset;
            }
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
            //Cache reference for efficiency
            target = _target;

            targetTransform = this.target.GetComponent<Transform>();
            targetRenderer = this.target.GetComponentInChildren<Renderer>();
            CharacterController characterController = _target.GetComponent<CharacterController>();
            // Get data from the Player that won't change during the lifetime of this Component
            if (characterController != null)
            {
                characterControllerHeight = characterController.height;
            }

            if (playerNameText != null)
            {
                playerNameText.text = target.photonView.Owner.NickName;
            }
        }

        #endregion
        #region Private Methods



        #endregion
    }
}