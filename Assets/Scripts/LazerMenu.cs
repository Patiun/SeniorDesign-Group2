using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LazerMenu : AbstractHackMenu
{
    
    public LazerGroupBehavior _lazerObject;
    [SerializeField]
    private PuzzleDifficultiesLevel level;

    public void Disable()
    {
        _lazerObject.groupOn = false;
    }

    public void Hack()
    {
        if(!HackManager.Instance.InProgress)
            HackManager.Instance.InitializeHacking(this, level);
    }

    public override void NotifyHackStatus(bool status)
    {
        if(status)
        {
            GameObject hack = transform.Find("HackButton").gameObject;
            if (hack != null)
                hack.SetActive(false);

            DisplayFullMenuWithoutHack();
        }
    }

    //add fading to the disable button
    public void DisplayFullMenuWithoutHack()
    {
        
        GameObject disable = transform.Find("DisableButton").gameObject;

        if (disable != null)
            disable.SetActive(true);

        GameObject parent = transform.parent.gameObject;
        parent.GetComponent<Image>().color = new Color32(49, 255, 59, 203);
    }
}
