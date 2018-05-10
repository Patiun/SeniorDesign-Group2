﻿using UnityEngine;
using System.Collections;

public class DoorMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject door;
    private Door door_scr;

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
}