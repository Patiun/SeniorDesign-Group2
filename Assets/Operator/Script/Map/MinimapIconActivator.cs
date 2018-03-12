using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Could this be renamed to MinimapInteractableActivator? ObjectMapping is unclear
public class MinimapIconActivator : MonoBehaviour {

    [SerializeField]
    private GameObject img;

	void Start () {
        MapController.RegisterMapObject(gameObject, img);
	}

    private void OnDestroy()
    {
        MapController.RemoveMapObject(gameObject);
    }
}
