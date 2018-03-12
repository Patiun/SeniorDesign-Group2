using UnityEngine;
using System.Collections;

public class CameraMenu : MonoBehaviour
{
    private Camera camera;

    public void setCamera(Camera cam)
    {
        camera = cam;
    }
    public void viewCamera()
    {
        CameraController.switchCamera(camera);
    }

    public void enableCamera()
    {
        
    }



}
