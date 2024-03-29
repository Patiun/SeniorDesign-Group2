﻿using UnityEngine;

/// <summary>
/// Be aware this will not prevent a non singleton constructor
///   such as `T myT = new T();`
/// To prevent that, add `protected T () {}` to your singleton class.
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	/*
	private static T instance;
	public static T Instance {
		get{return instance;}
		protected set{
			if(instance != null)
			{
				// If that is the case, we destroy other instances
				Destroy(value);
			}

			instance = value;
		}
	}
	*/
	
	private static T _instance;
	
	private static object _lock = new object();
	
	public static T instance
	{
		get
		{
			if (applicationIsQuitting && !FindObjectOfType<T>())
            {
				Debug.LogWarning("[Singleton] Instance "+ typeof(T)
				                 + " already destroyed on application quit."
				                 + "Won't create again - returning null.");
				return null;
			}
			
			lock(_lock)
			{
				if (_instance == null)
				{
					_instance = (T)FindObjectOfType(typeof(T));
					
					if (_instance == null)
					{
						GameObject singleton = new GameObject();
						_instance = singleton.AddComponent<T>();
						singleton.name = typeof(T).ToString();
						
						DontDestroyOnLoad(singleton);
						
						Debug.Log("[Singleton] An instance of " + typeof(T) + 
						          " is needed in the scene, so '" + singleton +
						          "' was created with DontDestroyOnLoad.");
					}
                    else
                    {
						Debug.Log("[Singleton] Using instance already created: " +
						          _instance.gameObject.name);
					}
				}
				
				return _instance;
			}
		}
		protected set{ _instance = value; }
	}

	public static bool ApplicationIsQuitting
    {
		get { return applicationIsQuitting; }  
	}

	protected static bool applicationIsQuitting = false;
	/// <summary>
	/// When unity quits, it destroys objects in a random order.
	/// In principle, a Singleton is only destroyed when application quits.
	/// If any script calls Instance after it have been destroyed, 
	///   it will create a buggy ghost object that will stay on the Editor scene
	///   even after stopping playing the Application. Really bad!
	/// So, this was made to be sure we're not creating that buggy ghost object.
	/// </summary>
	public void OnDestroy()
    {
		applicationIsQuitting = true;
	}
}