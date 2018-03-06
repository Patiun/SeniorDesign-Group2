using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Not sure why a GameObject is being disabled?
// Attach this script to it and follow the stack trace to see which line is disabling/enabling it!
public class PrintActiveStackTrace : MonoBehaviour
{
    void OnEnable()
    {
        Debug.LogWarning("[PrintActiveStackTrace] GameObject " + gameObject.name + " has been enabled.");
    }

    void OnDisable()
    {
        Debug.LogWarning("[PrintActiveStackTrace] GameObject " + gameObject.name + " has been disabled.");
    }
}
