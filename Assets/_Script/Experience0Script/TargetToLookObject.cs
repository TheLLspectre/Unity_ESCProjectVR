using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheRed.Experience0.TargetToLook
{
    [AddComponentMenu("TheRed/Experience0/TargetToLookObject")]
    public class TargetToLookObject : MonoBehaviour
    {
        #region Public Fields

        public delegate void OnTargetToLookObjectDestroyHandler(TargetToLookObject ttlo);
        public event OnTargetToLookObjectDestroyHandler OnTargetToLookDestroyAction;

        #endregion

        #region Private Fields
        #endregion

        #region MonoBehaviour Callbacks

        private void OnDestroy()
        {
            if (OnTargetToLookDestroyAction != null)
                OnTargetToLookDestroyAction(this); ;
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}