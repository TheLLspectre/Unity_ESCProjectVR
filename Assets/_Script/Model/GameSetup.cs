using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheRed.Model
{
    [AddComponentMenu("TheRed/Model/GameSetup")]
    public class GameSetup : MonoBehaviour
    {
        #region Public Fields
        public static GameSetup Instance;

        public GameObject[] SpawnPoints;
        #endregion

        #region Private Fields
        #endregion

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            Instance = this;
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

        public GameObject GetSpawnPoint(int index)
        {
            if (index < SpawnPoints.Length)
            {
                return SpawnPoints[index];
            }

            return null;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}