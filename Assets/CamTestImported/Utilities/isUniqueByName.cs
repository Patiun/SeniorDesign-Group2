using UnityEngine;
using System.Collections;

public class isUniqueByName : MonoBehaviour
{
	void Awake()
    {
		GameObject gO = GameObject.Find(gameObject.name);

		if (gameObject.GetInstanceID()!= gO.GetInstanceID())
        {
			Destroy(gameObject);
		}
	}
}