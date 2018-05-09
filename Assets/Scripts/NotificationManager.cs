using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{

    #region Singleton
    private static NotificationManager _instance;
    //Used only once to ensure when one thread have access to create the instance
    private static readonly object _Lock = new object();
    
    public static NotificationManager Instance
    {
        get
        {
            //thread safe!
            lock (_Lock)
            {
                if (_instance != null)
                    return _instance;
                NotificationManager[] instances = FindObjectsOfType<NotificationManager>();
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

                GameObject manage = new GameObject("NotificationManager");
                manage.AddComponent<NotificationManager>();

                return _instance = manage.GetComponent<NotificationManager>();
            }
        }
    }
    #endregion

    [SerializeField]
    [Tooltip("Allow the manager to be across all scenes.")]
    private bool _persistent = true;

    [SerializeField]
    [Tooltip("The gameobject where the notification is to be display.")]
    private GameObject _notificationBar;

    private List<GameObject> _cameras;
    private List<GameObject> _doors;
    private List<GameObject> _turrets;

    private void Awake()
    {
        if (_persistent)
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _cameras = new List<GameObject>();
        _doors = new List<GameObject>();
        _turrets = new List<GameObject>();
    }

    public void HackNotify(GameObject obj, PuzzleDifficultiesLevel level)
    {
        if (obj.tag.Equals("Untagged"))
            Debug.LogErrorFormat("Notification Manager cannot work with '%s' without tags", obj.name);
        else
        {
            switch(obj.tag)
            {
                case "Camera":
                    CameraNotification(obj, level);
                    break;
                case "Door":
                    DoorNotifcation(obj, level);
                    break;
            }
        }
    }

    private void CameraNotification(GameObject camera, PuzzleDifficultiesLevel level)
    {

    }

    private void DoorNotifcation(GameObject door, PuzzleDifficultiesLevel level)
    {

    }


}
