using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class IconEvent : MonoBehaviour
{

    protected GameObject cam;

    public void setCamera(GameObject cam)
    {
        this.cam = cam;
        //CameraMenu submenu = transform.GetChild(0).gameObject.GetComponent<CameraMenu>();
        //submenu.setCamera(cam.GetComponent<Camera>());
    }

    //temp go directly to camera setting
    public void OnMouseDown()
    {
        //add dropdown menu here
        //CameraController.switchCamera(cam.GetComponent<Camera>());

    }

    public void OnMouseOver()
    {
        //transform.GetChild(0).gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        //transform.GetChild(0).gameObject.SetActive(false);
    }
}
