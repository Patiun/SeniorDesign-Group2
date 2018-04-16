using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public struct MapObject
{
    public Sprite Icon { get; set; }
    public GameObject Self { get; set; }
    public GameObject Owner { get; set; }
    public int Region { get; set; }
}

public class MapController : MonoBehaviour
{
    [SerializeField]
    private Camera mapCam;
    public float x;
    public float y;

    public static List<MapObject> fixedMapObjects = new List<MapObject>();


    private void Start()
    {

    }

    //update player icon here
    void Update()
    {
        DrawFixedPositionMapIcon();
    }

    //keep track of the game objects with icons to be display
    //takes in the parameter of the object that owns the icon object and the icon object itself
    public static void RegisterMapObject(GameObject o, GameObject i)
    {
        //create new game object to remove reference to prefab
        GameObject img = Instantiate(i);
        IconDropdown iconDropdown = img.GetComponent<IconDropdown>();

        //assign the icon script to have the camera object
        if (iconDropdown != null)
        {
            
            GameObject cam = o.transform.Find("Camera").gameObject;
            //if (cam != null)
            //    //iconDropdown.SetInteractiveObject(cam);
            //else
            //    Debug.LogError("Map Controller script cannot find the child object 'Camera' from " + cam.name + "game object");
        }
        else
            Debug.LogError("Map Controller script cannot find container child from " + img.name);

        fixedMapObjects.Add(new MapObject() { Icon = img.GetComponent<Sprite>(), Self = img, Owner = o });
        
    }

    //remove the gameobject with its icon if the game object is destroyed
    public static void RemoveMapObject(GameObject o)
    {
        foreach(var obj in fixedMapObjects)
        {
            if(obj.Owner == o)
            {
                Destroy(obj.Icon);
                fixedMapObjects.Remove(obj);
                break;
            }
        }
    }

    //To update the icons in the map
    private void DrawFixedPositionMapIcon()
    {
        foreach(var objs in fixedMapObjects)
        {
            Vector3 screenPos = mapCam.WorldToViewportPoint(objs.Owner.transform.position);
            RectTransform rt = this.GetComponent<RectTransform>();
            Vector3[] viewCorner = new Vector3[4];
            rt.GetWorldCorners(viewCorner);

            screenPos.x = Mathf.Clamp(screenPos.x * rt.rect.width * rt.localScale.x * x+ viewCorner[0].x, viewCorner[0].x, viewCorner[2].x);
            screenPos.y = Mathf.Clamp(screenPos.y * rt.rect.height * rt.localScale.y * y+ viewCorner[0].y, viewCorner[0].y, viewCorner[1].y);
            screenPos.z = 0;

            objs.Self.transform.SetParent(transform);
            objs.Self.transform.position = screenPos;

            Debug.Log("Camera obj view space x " + screenPos.x);
            Debug.Log("Camera obj view space y " + screenPos.y);
            Debug.Log("Camera obj name " + objs.Self.name);
            
        }
    }

}
