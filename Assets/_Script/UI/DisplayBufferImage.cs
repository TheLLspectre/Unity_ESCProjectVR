/* Copyright 2020
 * author: LEROUGE Ludovic
 * TheRed Games Projet: BoxIt!
 * All rights reserved
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBufferImage : MonoBehaviour
{
    //public
    public BufferImage[] tabBufferImage;

    //private


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //methods
    /// <summary>
    /// Need a EditorDisplayBuffer script
    /// </summary>
    public void BuildBuffer()
    {
        tabBufferImage = AddBuffer();
    }

    /// <summary>
    /// Add an image buffer in the buffer
    /// </summary>
    /// <returns> Return the buffer image with one more inside</returns>
    private BufferImage[] AddBuffer()
    {
        List<BufferImage> listBuffer = new List<BufferImage>();
        listBuffer.InsertRange(listBuffer.Count, tabBufferImage);
        BufferImage tmp = new BufferImage();
        listBuffer.Add(tmp);
        return listBuffer.ToArray();
    }

    public void ChangeSizeBuffer(int length, int num)
    {
        int tmp = 0;
        if (num < length)
        {
            tmp = length - num;
            for (int i = 0; i < tmp; i++)
            {
                tabBufferImage = RemoveBuffer();
            }
        }
        else if (num > length)
        {
            tmp = num - length;
            for (int i = 0; i < tmp; i++)
            {
                tabBufferImage = AddBuffer();
            }
        }
    }

    /// <summary>
    /// Remove an image buffer in the buffer
    /// </summary>
    /// <returns> Return the buffer without the element selected </returns>
    public BufferImage[] RemoveBuffer()
    {
        tabBufferImage = RemoveElement(tabBufferImage);
        return tabBufferImage;
    }

    /// <summary>
    /// Add an image in the image buffer
    /// </summary>
    /// <param name="index"> Find the buffer in the buffer image </param>
    public void AddTexture(int index)
    {
        tabBufferImage[index].image = AddElement(tabBufferImage[index].image);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TypeOfValue"></typeparam>
    /// <param name="tab"></param>
    /// <param name="index"></param>
    /// <param name="num"></param>
    public void ChangeSize<TypeOfValue>(TypeOfValue[] tab, int index,  int num)
    {
        int tmp = 0;
        if (num < tab.Length)
        {
            tmp = tab.Length - num;
            for (int i = 0; i < tmp; i++)
            {
                RemoveTexture(index);
            }
        }
        else if (num > tab.Length)
        {
            tmp = num - tab.Length;
            for (int i = 0; i < tmp; i++)
            {
                AddTexture(index);
            }
        }
    }

    /// <summary>
    /// Remove the last image in the image buffer
    /// </summary>
    /// <param name="index"></param>
    public void RemoveTexture(int index)
    {
        tabBufferImage[index].image = RemoveElement(tabBufferImage[index].image);
    }

    /// <summary>
    /// Generic function to add an element in an array
    /// </summary>
    /// <typeparam name="TypeOfValue"> Any Type </typeparam>
    /// <param name="tab"> Any array </param>
    /// <returns> Return the tab with one element more </returns>
    private TypeOfValue[] AddElement<TypeOfValue>(TypeOfValue[] tab) where TypeOfValue: class
    {
        List<TypeOfValue> listObj = new List<TypeOfValue>();
        listObj.InsertRange(listObj.Count, tab);
        TypeOfValue tmp = null;
        listObj.Add(tmp);
        return listObj.ToArray();
    }

    /// <summary>
    /// Generic function to remove an element in an array
    /// </summary>
    /// <typeparam name="TypeOfValue"> Any Type </typeparam>
    /// <param name="tab"> Any array </param>
    /// <returns> Return the tab without the last element </returns>
    private TypeOfValue[] RemoveElement<TypeOfValue>(TypeOfValue[] tab)
    {
        List<TypeOfValue> listObj = new List<TypeOfValue>();
        listObj.InsertRange(listObj.Count, tab);
        if (listObj.Count - 1 >= 0)
        {
            listObj.RemoveAt(listObj.Count - 1);
        }
        return listObj.ToArray();
    }
}