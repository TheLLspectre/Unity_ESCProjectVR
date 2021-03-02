using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheRed.Objects
{
    [AddComponentMenu("TheRed/Experience0/LevelPart/CupBoard")]
    public class CupBoard : MonoBehaviour
    {
        #region Public Fields

        public GameObject ToContain;

        public bool OpenState { get { return openState; } }
        public bool IsLocked { get { return isLocked; } set { isLocked = value; } }

        #endregion

        #region Private Fields

        private Collider col;
        private Animator anim;

        [SerializeField]
        private bool openState = false;
        [SerializeField]
        private bool isLocked = false;

        #endregion

        #region MonoBehaviour Callbacks

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
            if (GetComponents<Collider>().Length > 0)
            {
                for (int i = 0; i < GetComponents<Collider>().Length; i++)
                {
                    if (GetComponents<Collider>()[i].isTrigger)
                        col = GetComponents<Collider>()[i];
                }
            }

            if (anim != null) // get the state of the door
                this.openState = anim.GetBool("Open");
        }

        #endregion

        #region Public Methods

        public void OpenCloseDoor()
        {
            if (this.openState) // If the door is open.
            {
                // close it
                this.openState = false;
                anim.SetBool("Open", this.openState);
                CloseAction();
                return;
            }
            else // If the door is closed.
            {
                if (!this.isLocked)
                {
                    // open it
                    this.openState = true;
                    anim.SetBool("Open", this.openState);
                    OpenAction();
                    return;
                }
            }
        }

        public void UnLock()
        {
            if (this.isLocked)
            {
                this.isLocked = false;
            }
        }

        #endregion

        #region Private Methods

        private void OpenAction()
        {
            this.col.enabled = false;
            if(this.ToContain != null)
                this.ToContain.SetActive(true);
        }

        private void CloseAction()
        {
            this.col.enabled = true;
            if (this.ToContain != null)
                this.ToContain.SetActive(false); ;
        }

        #endregion
    }
}