using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Could this be renamed to MinimapInteractableActivator? ObjectMapping is unclear
public class ObjectMapping : MonoBehaviour {

    [SerializeField]
    private Image image;

	void Start () {
        MapController.RegisterMapObject(this.gameObject, image);
	}

    private void OnDestroy()
    {
        MapController.RemoveMapObject(this.gameObject);
    }
}
