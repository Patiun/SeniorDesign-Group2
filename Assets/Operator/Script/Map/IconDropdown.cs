using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class IconDropdown : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    private GameObject container;
    public bool isOpen;

    void Awake()
    {
        container = transform.Find("Container").gameObject;
        isOpen = false;

        if (container == null)
            Debug.Log("Icon Dropdown Script: Cannot find Container object  in the child of the parent " + gameObject.name + "game object.");
    }

    void Start()
    {
        //gameObject.GetComponent<Image>().color = new Color32(193,193,193,255);
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
        gameObject.transform.SetAsLastSibling();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOpen = false;
    }
}
