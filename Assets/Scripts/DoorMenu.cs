using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DoorMenu : AbstractHackMenu
{
    [SerializeField]
    private GameObject door;
    public Door door_scr;
    [SerializeField]
    private PuzzleDifficultiesLevel level;


    GameObject hack;
    GameObject open;
    GameObject close;
    GameObject unlock;
    GameObject lockb;

    private void Start()
    {
        if(door != null)
            door_scr = door.GetComponent<Door>();
        lockb = transform.Find("LockButton").gameObject;
        unlock = transform.Find("UnlockButton").gameObject;
        close = transform.Find("CloseButton").gameObject;
        open = transform.Find("OpenButton").gameObject;
        hack = transform.Find("HackButton").gameObject;
    }

    public void CallOpen()
    {
        door_scr.Open();
        open.SetActive(false);
        close.SetActive(true);
    }

    public void CallClose()
    {
        door_scr.Close();
        open.SetActive(true);
        close.SetActive(false);
    }

    public void CallLock()
    {
        door_scr.Lock();
        lockb.SetActive(false);
        unlock.SetActive(true);
    }

    public void CallUnlock()
    {
        door_scr.Unlock();
        lockb.SetActive(true);
        unlock.SetActive(false);
    }

    public void Hack()
    {
        if(!HackManager.Instance.InProgress)
            HackManager.Instance.InitializeHacking(this, level);
        
    }

    public void DisplayFullMenuWithoutHack()
    {
        if (open != null)
            open.SetActive(true);
        if (close != null)
            close.SetActive(false);

        if (unlock != null)
            unlock.SetActive(true);

        if (lockb != null)
            lockb.SetActive(false);

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
