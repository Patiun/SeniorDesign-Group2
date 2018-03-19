using UnityEngine;
using UnityEngine.EventSystems;

public class IconDropdown : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    private GameObject container;
    private bool isOpen;
    private GameObject obj; //obj can be camera, door, etc...

    public GameObject camera;

    void Awake()
    {
        container = transform.Find("Container").gameObject;
        isOpen = false;

        if (container == null)
            Debug.Log("Icon Dropdown Script: Cannot find Container object  in the child of the parent " + gameObject.name + "game object.");

        SetMenuInteraction();
    }

	void Update () {
        if (container != null)
        {
            Vector3 scale = container.GetComponent<RectTransform>().localScale;
            scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 12); //smooth the transition opening and closing the menu
            container.GetComponent<RectTransform>().localScale = scale;
        }
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOpen = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOpen = false;
    }

    public void SetInteractiveObject(GameObject o)
    {
        obj = o;
        SetMenuInteraction();
    }

    //find the child object container to get the script to set the interaction with the object
    private void SetMenuInteraction()
    {
        AbstractIconMenuButton aimb = container.GetComponent<AbstractIconMenuButton>();     

        if(aimb != null)
        {
            //aimb.InteractiveObject = obj;
            aimb.InteractiveObject = camera;
        }
        else
        {
            Debug.LogError("IconDropDown script in the " + gameObject.name + " cannot find the 'AbstractIconMenuButton' script in the child");
        }

    }
}
