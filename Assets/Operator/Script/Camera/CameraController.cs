using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private static List<Camera> cameraList;
    private static Camera current;

    [SerializeField]
    private Camera mainCam;
    private static Camera mCam; //just a work around;

	// Use this for initialization
	void Start () {
        cameraList = new List<Camera>();

        if (mainCam != null)
        {
            current = mainCam;
            mCam = mainCam;
            cameraList.Add(current);
        }
        else
        {
            Debug.Log("Error: Add main camera to Cam Control class");
        }
	}
	
    //not needed yet
    public static void addCam(Camera c)
    {
        cameraList.Add(c);
    }

    //to be change when we figure out the camera layout scheme
    //this will either switch target display but allow camera to be active
    public static void switchCamera(Camera c)
    {
        current.gameObject.SetActive(false);
        current = c;
        current.gameObject.SetActive(true);
        //c.targetDisplay = 1;
    }

    public static void switchToMainCamera()
    {
        switchCamera(mCam);
    }
}
