using UnityEngine;
using System.Collections;

public class FanMenu : AbstractHackMenu
{
    [SerializeField]
    private FanRotation fanRotation;
    [SerializeField]
    private PuzzleDifficultiesLevel level;

    public void Disable()
    {
        fanRotation.on = false;
    }

    public void Hack()
    {
        if (!HackManager.Instance.InProgress)
            HackManager.Instance.InitializeHacking(this, level);
    }

    public override void NotifyHackStatus(bool status)
    {
        if (status)
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
