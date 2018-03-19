using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnableDisableTextChange : MonoBehaviour
{

    public void switchText()
    {
        Text t = gameObject.GetComponent<Text>();

        if (t.text == "Enable")
        {
            t.text = "Disable";
        }
        else
            t.text = "Enable";
    }
}
