/**
 * MIT License 
 *  
 * Samuele Padalino @R4ndomThunder
 * https://samuelepadalino.dev
 */

using UnityEngine;

namespace RTDK.Utility
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public bool IsPersistent = false;

        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        public virtual void Awake()
        {
            if (IsPersistent)
                DontDestroyOnLoad(gameObject);

            if (instance == null)
            {
                instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }
}