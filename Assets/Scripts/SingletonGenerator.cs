using UnityEngine;
using System.Collections;

public class SingletonGenerator <T>: SingletonGenerator where T : MonoBehaviour
{

        #region  Fields
        private static T _instance;

        // ReSharper disable once StaticMemberInGenericType
        private static readonly object Lock = new object();

        [SerializeField]
        private bool _persistent = false;
        #endregion

        #region  Properties
        public static T Instance
        {
            get
            {
                if (Quitting)
                {
                    return null;
                }
                lock (Lock)
                {
                    if (_instance != null)
                        return _instance;
                    var instances = FindObjectsOfType<T>();
                    var count = instances.Length;
                    if (count > 0)
                    {
                        if (count == 1)
                            return _instance = instances[0];
                        
                        for (var i = 1; i < instances.Length; i++)
                            Destroy(instances[i]);
                        return _instance = instances[0];
                    }

                   
                    return _instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                }
            }
        }
        #endregion

        #region  Methods
        private void Awake()
        {
            if (_persistent)
                DontDestroyOnLoad(gameObject);
            OnAwake();
        }

        protected virtual void OnAwake() { }
        #endregion
    }

    public abstract class SingletonGenerator : MonoBehaviour
    {
        #region  Properties
        public static bool Quitting { get; private set; }
        #endregion

        #region  Methods
        private void OnApplicationQuit()
        {
            Quitting = true;
        }
        #endregion
    }

