using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public struct MapObject
{
    public Image Icon { get; set; }
    public GameObject Owner { get; set; }
}

public class MapController : MonoBehaviour
{
    [SerializeField]
    private Camera mapCam;

    public static List<MapObject> mapObjs = new List<MapObject>();


    // Update is called once per frame
    void Update()
    {
        DrawMapIcon();
    }

    //keep track of the game objects with icons to be display
    public static void RegisterMapObject(GameObject o, Image i)
    {
        //create new game object to remove reference to prefab
        Image img = Instantiate(i);
        IconEvent ie = img.GetComponent<IconEvent>();

        for(int j = 0; j < o.transform.childCount; j++)
        {
            if(o.transform.GetChild(j).name == "Camera")
            {

                ie.addCam(o.transform.GetChild(j).GetComponent<Camera>());
                break;
            }
        }
        mapObjs.Add(new MapObject() { Icon = img, Owner = o });
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
            //to be fix as it's not updating tor relative location
            screenPos.x = Mathf.Clamp(screenPos.x * rt.rect.width * rt.localScale.x  + viewCorner[0].x, viewCorner[0].x, viewCorner[2].x);
            screenPos.y = Mathf.Clamp(screenPos.y * rt.rect.height * rt.localScale.y * 3/4 + viewCorner[0].y, viewCorner[0].y, viewCorner[1].y);
            screenPos.z = 0;

            objs.Icon.transform.SetParent(this.transform);
            objs.Icon.transform.position = screenPos;
        }
    }

}
