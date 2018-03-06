using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadTest : MonoBehaviour
{
    [Tooltip("The text to be saved to a file")]
    public string textToSave;

    public string fileName;

	// Use this for initialization
	void Start ()
    {
        SaveLoad.Save(textToSave, fileName);

        SaveLoad.SaveAppend("Moo Oink Hai Mark", fileName);
    }
}
