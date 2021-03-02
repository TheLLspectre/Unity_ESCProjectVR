/* Copyright 2020
 * author: LEROUGE Ludovic
 * TheRed Games Projet: BoxIt!
 * All rights reserved
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(DisplayBufferImage))]
public class EditorDisplayBuffer : Editor
{
    //public UnityEngine.Object bufferImage;
    public BufferImage bufferImage;
    private int scalingTexture = 0;
    private int scalingBuffer = 0;
    SerializedObject objectSerialized;
    SerializedProperty propertySerialized;

    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();
        serializedObject.Update();
        DisplayBufferImage buffer = (DisplayBufferImage)target;

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Display Buffer Array Size: ");
        scalingBuffer = EditorGUILayout.IntField(buffer.tabBufferImage.Length);
        if (scalingBuffer != buffer.tabBufferImage.Length)
        {
            buffer.ChangeSizeBuffer(buffer.tabBufferImage.Length, scalingBuffer);
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        for (int i = 0; i < buffer.tabBufferImage.Length; i++)
        {
            try
            {
                EditorGUILayout.BeginHorizontal();
                try
                {
                    EditorGUILayout.LabelField("Buffer " + i + " Size : ");
                    /*buffer.tabBufferImage[i].image.Length =*/ scalingTexture = EditorGUILayout.IntField(buffer.tabBufferImage[i].image.Length);
                    if (scalingTexture != buffer.tabBufferImage[i].image.Length)
                    {
                        buffer.ChangeSize(buffer.tabBufferImage[i].image, i, scalingTexture);
                    }
                }
                catch (NullReferenceException)
                {
                    EditorGUILayout.LabelField("Buffer " + i);
                    EditorGUILayout.LabelField("Size : " + 0);
                    if (scalingTexture != 0)
                    {
                        buffer.ChangeSize(buffer.tabBufferImage[i].image, i, scalingTexture);
                    }
                }
                
                EditorGUILayout.EndHorizontal();

                if (buffer.tabBufferImage[i].image.Length > 0)
                {
                    if (buffer.tabBufferImage[i].image != null)
                    {
                        for (int j = 0; j < buffer.tabBufferImage[i].image.Length; j++)
                        {
                            EditorGUILayout.BeginHorizontal();
                            EditorGUILayout.PrefixLabel("Image : " + j);
                            buffer.tabBufferImage[i].image[j] = (Texture2D)EditorGUILayout.ObjectField(buffer.tabBufferImage[i].image[j], typeof(Texture2D), true);
                            EditorGUILayout.EndHorizontal();
                        }
                    }
                    else
                    {
                        buffer.tabBufferImage[i].image[0] = (Texture2D)EditorGUILayout.ObjectField(null, typeof(Texture2D), true);
                    }
                }
                else
                {
                    if (buffer.tabBufferImage[i].image != null)
                    {
                        buffer.RemoveBuffer();
                    }
                    else
                    {
                        buffer.tabBufferImage[i].image[0] = (Texture2D)EditorGUILayout.ObjectField(null, typeof(Texture2D), true);
                    }
                }

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("");
                if (GUILayout.Button("Add Image"))
                {
                    buffer.AddTexture(i);
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("");
                if (GUILayout.Button("Remove Image"))
                {
                    buffer.RemoveTexture(i);
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("");
                if (GUILayout.Button("Remove Buffer"))
                {
                    buffer.RemoveBuffer();
                }
                EditorGUILayout.EndHorizontal();

            }
            catch (NullReferenceException e)
            {
                buffer.RemoveBuffer();
                //Debug.LogError(e);
            }
        }
        EditorGUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Add Buffer Image"))
        {
            buffer.BuildBuffer();
        }
    }
}