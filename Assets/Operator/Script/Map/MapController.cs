using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

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

    public static List<MapObject> mapObjs = new List<MapObject>();


    private void Start()
    {
        DrawMapIcon();
    }

    //update player icon here
    void Update()
    {
        
    }

    //keep track of the game objects with icons to be display
    public static void RegisterMapObject(GameObject o, GameObject i)
    {
        //create new game object to remove reference to prefab
        GameObject img = Instantiate(i);

        IconEvent ie = img.GetComponent<IconEvent>();

        for(int j = 0; j < o.transform.childCount; j++)
        {
            if(o.transform.GetChild(j).name == "Camera")
            {
                ie.setCamera(o.transform.GetChild(j).gameObject);
                break;
            }
        }
        mapObjs.Add(new MapObject() { Icon = img.GetComponent<Sprite>(), Self = img, Owner = o });
    }

    //remove the gameobject with its icon if the game object is destroyed
    public static void RemoveMapObject(GameObject o)
    {
        foreach(var obj in mapObjs)
        {
            if(obj.Owner == o)
            {
                Destroy(obj.Icon);
                mapObjs.Remove(obj);
                break;
            }
        }
    }

    //To update the icons in the map
    private void DrawMapIcon()
    {
        foreach(var objs in mapObjs)
        {
            Vector3 screenPos = mapCam.WorldToViewportPoint(objs.Owner.transform.position);
            RectTransform rt = this.GetComponent<RectTransform>();
            Vector3[] viewCorner = new Vector3[4];
            rt.GetWorldCorners(viewCorner);

            screenPos.x = Mathf.Clamp(screenPos.x * rt.rect.width * rt.localScale.x + viewCorner[0].x, viewCorner[0].x, viewCorner[2].x);
            screenPos.y = Mathf.Clamp(screenPos.y * rt.rect.height * rt.localScale.y * 3/4 + viewCorner[0].y, viewCorner[0].y, viewCorner[1].y);
            screenPos.z = 0;

            objs.Self.transform.SetParent(transform);
            objs.Self.transform.position = screenPos;
        }
    }

}
