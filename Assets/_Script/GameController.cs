/* Copyright 2021
 * author: LEROUGE Ludovic
 * TheRed Games FrameWorkRed
 * All rights reserved
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("TheRed/GameController")]
public class GameController : MonoBehaviour
{
    public enum GameMode
    { 
        XR,
        PC
    }

    //public
    #region Public Field
    public GameMode gameMode;
    public GameObject XRPlayer;
    public GameObject PCPlayer;
    #endregion

    //private
    #region Private Field
    #endregion

    private void Awake()
    {
        if (gameMode == GameMode.XR)
        {
            if (PCPlayer)
                PCPlayer.SetActive(false);
            if (XRPlayer)
                XRPlayer.SetActive(true);
        }
        else if (gameMode == GameMode.PC)
        {
            if (PCPlayer)
                PCPlayer.SetActive(true);
            if (XRPlayer)
                XRPlayer.SetActive(false);
        }
    }
}