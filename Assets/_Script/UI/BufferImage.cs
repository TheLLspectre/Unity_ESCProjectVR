/* Copyright 2020
 * author: LEROUGE Ludovic
 * TheRed Games Projet: BoxIt!
 * All rights reserved
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEditor;

[AddComponentMenu("TheRed/UI/BufferImage")]
public class BufferImage : UnityEngine.Object
{
    //public
    public Texture2D[] image;

    //private

    public BufferImage()
    {
        this.image = new Texture2D[1];
    }

    //methods
}