using UnityEngine;
using UnityEngine.EventSystems;

public class IconDropdown : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    private GameObject container;
    private bool isOpen;

    void Awake()
    {
        container = transform.Find("Container").gameObject;
        isOpen = false;

        if (container == null)
            Debug.Log("Icon Dropdown Script: Cannot find Container object  in the child of the parent " + gameObject.name + "game object.");
    }

    void Update()
    {
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
}
