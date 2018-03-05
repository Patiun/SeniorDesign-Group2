using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {

    private static Dictionary<GameObject, Camera> camDic;
    private static Camera current;

    [SerializeField]
    private Camera mainCam;

	// Use this for initialization
	void Start () {
        camDic = new Dictionary<GameObject, Camera>();

        if (mainCam != null)
        {
            current = mainCam;
            camDic.Add(this.gameObject, mainCam);
        }
        else
        {
            Debug.Log("Error: Add main camera to Cam Control class");
        }
	}
	
    public static void addCam(GameObject o, Camera c)
    {
        if (!camDic.ContainsKey(o))
            camDic.Add(o, c);
    }

    public static void switchCamera(GameObject o)
    {
        current.enabled = false;
        camDic.TryGetValue(o, out current);
        current.enabled = true;
    }
}
