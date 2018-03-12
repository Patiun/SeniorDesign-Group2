using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class item
{
    public Image Image;
    public Text Text;
}

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabItem;

    private List<item> objectives = new List<item>(); 
    // Use this for initialization
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject o = Instantiate(prefabItem);
            Image img = o.transform.GetChild(0).GetComponent<Image>();
            Text t = o.transform.GetChild(1).GetComponent<Text>();
            t.text = "Task number :" + i;
            objectives.Add(new item() { Image = img, Text = t });
            o.transform.SetParent(this.transform);
            o.transform.localScale = Vector3.one;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}
