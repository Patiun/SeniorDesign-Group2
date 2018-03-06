using UnityEngine;
using System.Collections;

public class DisableAfterAwake : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
		gameObject.SetActive(false);
	}
}