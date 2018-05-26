using UnityEngine;
using System.Collections;

public class ObjectMapToView : MonoBehaviour
{

    [SerializeField]
    private GameObject _prefabIcon;

    private GameObject icon;

    void Awake()
    {
        icon = Instantiate(_prefabIcon);
        AutoMapAdjusted.RegisterMapIcon(gameObject, icon);

        AssignGameObjectToMenu();

    }

    private void AssignGameObjectToMenu()
    {
        if(icon.transform.Find("Container").GetComponent<LazerMenu>() != null)
        {
           
            GameObject container = icon.transform.Find("Container").gameObject;
            LazerMenu menu = container.GetComponent<LazerMenu>();

            if (GetComponent<LazerGroupBehavior>() != null)
            {
                menu._lazerObject = (GetComponent<LazerGroupBehavior>());
            }
            else
                Debug.LogWarning("Attached object map script to gameobject is missing lazer group behavior");

        }
        else if (icon.transform.Find("Container").GetComponent<FanMenu>() != null)
        {
            GameObject container = icon.transform.Find("Container").gameObject;
            FanMenu menu = container.GetComponent<FanMenu>();

            if(GetComponent<FanRotation>() != null)
            {
                menu.fanRotation = GetComponent<FanRotation>();
            }
        }
        else if (icon.transform.Find("Container").GetComponent<CameraMenu>() != null)
        {
            GameObject container = icon.transform.Find("Container").gameObject;
            CameraMenu menu = container.GetComponent<CameraMenu>();

            menu._cameraObject = gameObject;
        }
        else if (icon.transform.Find("Container").GetComponent<DoorMenu>() != null)
        {
            GameObject container = icon.transform.Find("Container").gameObject;
            DoorMenu menu = container.GetComponent<DoorMenu>();
            if (GetComponent<Door>() != null)
            {
                menu.door_scr = GetComponent<Door>();
            }
        }
    }
}
