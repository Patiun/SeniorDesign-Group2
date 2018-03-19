using UnityEngine;
using System.Collections;

public class CameraMenuInteractions : AbstractIconMenuButton
{

    private bool enable = false;
    //will remove... this is just quick and dirty for presentation
    public override void Disable()
    {
        if (!enable)
        {
            GameObject light = InteractiveObject.transform.parent.transform.Find("Spotlight").gameObject;
            light.SetActive(false);
            enable = true;
        }
        else
        {
            GameObject light = InteractiveObject.transform.parent.transform.Find("Spotlight").gameObject;
            light.SetActive(true);
            enable = false;
        }
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
