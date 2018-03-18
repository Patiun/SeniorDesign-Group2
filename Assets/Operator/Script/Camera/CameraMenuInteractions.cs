using UnityEngine;
using System.Collections;

public class CameraMenuInteractions : AbstractIconMenuButton
{

    public override void Disable()
    {
        Debug.LogWarning("Camera Menu Interaction script not implemented Disable");
    }

    public override void Enable()
    {
        Debug.LogWarning("Camera Menu Interaction script not implemented Enable");
    }

    public override void Execute()
    {
        Camera cam = InteractiveObject.GetComponent<Camera>();
        CameraController.switchCamera(cam);
    }
}
