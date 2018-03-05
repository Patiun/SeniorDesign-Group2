using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
//need to be refactor for strategy pattern
public class IconEvent : MonoBehaviour
{

    private void Start()
    {
        EventTrigger head = this.gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback = new EventTrigger.TriggerEvent();
        UnityEngine.Events.UnityAction<BaseEventData> call = new UnityAction<BaseEventData>(goToCamera);
        entry.callback.AddListener(call);
        head.triggers.Add(entry);
    }
    public void addCam(Camera c)
    {
        CamControl.addCam(this.gameObject, c);
    }

    public void goToCamera(UnityEngine.EventSystems.BaseEventData baseEvent)
    {
        CamControl.switchCamera(this.gameObject);
        Debug.Log("Hello!");
    }

    public void disableObject()
    {

    }

    public void enableObject()
    {

    }

    public void gainAccess()
    {

    }
}
