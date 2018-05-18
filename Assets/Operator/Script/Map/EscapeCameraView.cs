using UnityEngine;
using System.Collections;

public class EscapeCameraView : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            HackManager.Instance.ResetHack();
            CameraManager.Instance.SwitchMainCamera();
        }
    }
}
