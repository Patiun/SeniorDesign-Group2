using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    #region Singleton
    private static CameraManager _instance;
    //Used only once to ensure when one thread have access to create the instance
    private static readonly object _Lock = new object();

    public static CameraManager Instance
    {
        get
        {
            //thread safe!
            lock (_Lock)
            {
                if (_instance != null)
                    return _instance;
                CameraManager[] instances = FindObjectsOfType<CameraManager>();
                //see if there are any already more instance of this
                if (instances.Length > 0)
                {
                    //yay only 1 instance so give it back
                    if (instances.Length == 1)
                        return _instance = instances[0];

                    //remove all other instance of it other than the 1st one
                    for (int i = 1; i < instances.Length; i++)
                        Destroy(instances[i]);
                    return _instance = instances[0];
                }

                GameObject manage = new GameObject("CameraManager");
                manage.AddComponent<HackManager>();

                return _instance = manage.GetComponent<CameraManager>();
            }
        }
    }
    #endregion

    [SerializeField]
    [Tooltip("Allow the manager to be across all scenes.")]
    private bool _persistent = true;

    [SerializeField]
    [Tooltip("Main camera is the camera to switch when escaping from the keyboard")]
    private GameObject _mainCamera;
    private GameObject _currentCamera;

    private void Awake()
    {
        if (_persistent)
            DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        if (_mainCamera == null)
            Debug.LogWarning("Camera Manager is missing the main camera.");
        else
            _currentCamera = _mainCamera;
    }

    public void SwitchCamera(GameObject ToBeSwitch)
    {
        _currentCamera.SetActive(false);
        _currentCamera = ToBeSwitch;
        _currentCamera.SetActive(true);
    }

    public void SwitchMainCamera()
    {
        SwitchCamera(_mainCamera);
    }

}
