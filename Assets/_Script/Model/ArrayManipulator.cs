using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace TheRed.Model
{
    public static class ArrayManipulator<T>
    {
        #region Public Fields
        #endregion

        #region Private Fields
        private static List<T> listManip = new List<T>();
        #endregion

        #region Public Methods

        /// <summary>
        /// Allow to add an element in any Array
        /// </summary>
        /// <param name="tabObj"> The array which you want to add an element</param>
        /// <param name="obj"> The element to add</param>
        /// <returns> The array with the new element at the end </returns>
        public static T[] AddElementInArray(T[] tabObj, T obj)
        {
            listManip = tabObj.ToList();
            listManip.Add(obj);
            tabObj = listManip.ToArray();
            return tabObj;
        }

        public static T GetElementInArray(T[] tabObj, int index)
        {
            return tabObj[index];
        }

        public static T GetElementByNameInArray(T[] tabObj, string name)
        {
            listManip = tabObj.ToList();
            foreach (T t in listManip)
            {
                if (ContainName(listManip, name))
                {
                    if (t.ToString().Contains(name))
                        return t;
                }
            }

            return default(T); // return null
        }

        #endregion

        #region Private Methods

        private static bool ContainName(List<T> list, string name)
        {
            foreach (T t in listManip)
            {
                if (t.ToString().Equals(name))
                    return true;
            }
            return false;
        }

        #endregion
    }
}