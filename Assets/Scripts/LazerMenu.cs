using UnityEngine;
using System.Collections;

public class LazerMenu : AbstractHackMenu
{
    [SerializeField]
    private LazerGroupBehavior _lazerObject;
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
    }
}
