using UnityEngine;
using System.Collections;

public class DoorInteraction : AbstractIconMenuButton
{
    bool isOpen;
    Vector3 position;


    private void Start()
    {
        position = InteractiveObject.transform.position;
        isOpen = false;
    }

    public override void Disable()
    {
        throw new System.NotImplementedException();
    }

    public override void Enable()
    {
        throw new System.NotImplementedException();
    }

    public override void Execute()
    {
        InteractiveObject.transform.position = new Vector3(30, InteractiveObject.transform.position.y, InteractiveObject.transform.position.z);

    }

}
