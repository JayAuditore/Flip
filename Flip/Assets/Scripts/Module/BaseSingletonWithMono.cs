using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Flip.Module
{
    public class BaseSingletonWithMono<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<T>() as T;
                }
                if (instance == null)
                {
                    GameObject temp = new GameObject(typeof(T).ToString());
                    instance = temp.AddComponent<T>();
                }
                return instance;
            }
        }
        private static T instance = null;
    }
}
