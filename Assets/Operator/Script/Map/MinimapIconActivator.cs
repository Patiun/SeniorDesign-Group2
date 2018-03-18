using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Could this be renamed to MinimapInteractableActivator? ObjectMapping is unclear
public class MinimapIconActivator : MonoBehaviour {

    [SerializeField]
    private GameObject image;

    void Awake()
    {
        MapController.RegisterMapObject(gameObject, image);
    }

    private void OnDestroy()
    {
        MapController.RemoveMapObject(gameObject);
    }
}
