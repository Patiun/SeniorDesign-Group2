using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MapObjectData
{
    public GameObject Icon { get; set; }
    public GameObject Owner { get; set; }
}

public class AutoMapAdjusted : MonoBehaviour {


    public Camera BirdEyeCamera;
    //have to initialize here than awake or start since object map to view script will execute on awake
    //and awake are not in order so this might be executed last and cause errors
    public static List<MapObjectData> mapObjects = new List<MapObjectData>();
    public static List<MapObjectData> mapRealTimeObjects = new List<MapObjectData>();
    private void Start()
    {
        DrawIconLocation();
    }
    void Update () {
        DrawRealTimeMap();
    }

    public static void RegisterRealTimeMapIcon(GameObject owner, GameObject icon)
    {
        mapRealTimeObjects.Add(new MapObjectData() { Icon = icon, Owner = owner });
    }

    public static void RegisterMapIcon(GameObject owner, GameObject icon)
    {
       
        mapObjects.Add(new MapObjectData() { Icon = icon, Owner = owner });
    }

    public static void RemoveMapObject(GameObject owner)
    {
        foreach(var obj in mapObjects)
        {
            if(obj.Owner.Equals(owner))
            {
                Destroy(obj.Icon);
                mapObjects.Remove(obj);
                break;
            }
        }
    }

    private void DrawIconLocation()
    {
        foreach(var objs in mapObjects)
        {
            Vector3 screenPos = BirdEyeCamera.WorldToViewportPoint(objs.Owner.transform.position);
            RectTransform rt = GetComponent<RectTransform>();

            if(rt == null)
            {
                Debug.Log("Need to be attached to image being displayed to");
                return;
            }

            Vector3[] viewCorner = new Vector3[4];
            rt.GetWorldCorners(viewCorner);

            screenPos.x = Mathf.Clamp(screenPos.x * rt.rect.width + viewCorner[0].x, viewCorner[0].x, viewCorner[2].x);
            screenPos.y = Mathf.Clamp(screenPos.y * rt.rect.height + viewCorner[0].y, viewCorner[0].y, viewCorner[1].y);
            screenPos.z = 0;

            objs.Icon.transform.SetParent(transform);
            objs.Icon.transform.position = screenPos;
            objs.Icon.transform.localScale = Vector3.one;

        }
    }

    private void DrawRealTimeMap()
    {
        foreach (var objs in mapRealTimeObjects)
        {
            Vector3 screenPos = BirdEyeCamera.WorldToViewportPoint(objs.Owner.transform.position);
            RectTransform rt = GetComponent<RectTransform>();

            if (rt == null)
            {
                Debug.Log("Need to be attached to image being displayed to");
                return;
            }

            Vector3[] viewCorner = new Vector3[4];
            rt.GetWorldCorners(viewCorner);

            screenPos.x = Mathf.Clamp(screenPos.x * rt.rect.width + viewCorner[0].x, viewCorner[0].x, viewCorner[2].x);
            screenPos.y = Mathf.Clamp(screenPos.y * rt.rect.height + viewCorner[0].y, viewCorner[0].y, viewCorner[1].y);
            screenPos.z = 0;

            objs.Icon.transform.SetParent(transform);
            objs.Icon.transform.position = screenPos;
            objs.Icon.transform.localScale = Vector3.one;

        }
    }

}
