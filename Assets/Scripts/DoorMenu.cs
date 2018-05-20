using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DoorMenu : AbstractHackMenu
{
    [SerializeField]
    private GameObject door;
    private Door door_scr;
    [SerializeField]
    private PuzzleDifficultiesLevel level;

    private void Start()
    {
        door_scr = door.GetComponent<Door>();
    }

    public void CallOpen()
    {
        door_scr.Open();
    }

    public void CallClose()
    {
        door_scr.Close();
    }

    public void CallLock()
    {
        door_scr.Lock();
    }

    public void CallUnlock()
    {
        door_scr.Unlock();
    }

    public void Hack()
    {
        if(!HackManager.Instance.InProgress)
            HackManager.Instance.InitializeHacking(this, level);
        
    }

    public void DisplayFullMenuWithoutHack()
    {
        GameObject hack = transform.Find("HackButton").gameObject;
        GameObject open = transform.Find("OpenButton").gameObject;
        GameObject close = transform.Find("CloseButton").gameObject;
        GameObject unlock = transform.Find("UnlockButton").gameObject;
        GameObject lockb = transform.Find("LockButton").gameObject;

        if (open != null)
            open.SetActive(true);
        if (close != null)
            close.SetActive(true);

        if (unlock != null)
            unlock.SetActive(true);

        if (lockb != null)
            lockb.SetActive(true);

        if (hack != null)
            hack.SetActive(false);

        GameObject parent = transform.parent.gameObject;
        parent.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public override void NotifyHackStatus(bool status)
    {
        if(status)
        {
            DisplayFullMenuWithoutHack();
        }
    }
}
