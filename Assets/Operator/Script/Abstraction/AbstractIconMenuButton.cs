using UnityEngine;
using System.Collections;

public abstract class AbstractIconMenuButton : MonoBehaviour
{
    //interactiveObject is the object it's acting upon
    //ex. doors, camera, etc...
    [HideInInspector]
    public GameObject InteractiveObject { get; set; }

    public abstract void Disable();
    public abstract void Enable();
    public abstract void Execute();

}
