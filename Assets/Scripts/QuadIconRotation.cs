using UnityEngine;
using System.Collections;

public class QuadIconRotation : MonoBehaviour
{

    Quaternion InitalRotation;
    // Use this for initialization
    void Start()
    {
        InitalRotation = transform.rotation;
    }

    private void FixedUpdate()
    {
        transform.rotation = InitalRotation;
    }
}
