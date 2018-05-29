using UnityEngine;
using System.Collections;

public class PlayerIconRotation : MonoBehaviour
{

    public Camera agent;
    public int y = 0;

    // Update is called once per frame
    void Update()
    {
        if (agent != null)
        {
            transform.localEulerAngles = new Vector3(0, 0, -agent.transform.localEulerAngles.y - y);
        }
            
    }
}
