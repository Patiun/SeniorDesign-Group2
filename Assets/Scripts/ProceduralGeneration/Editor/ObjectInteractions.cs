using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObjectInteractions : EditorWindow {

	private bool setInteractable = true;

	[MenuItem ("Window/Operation Exodus/Setup Object Interactions")]

	public static void ShowWindow() {
		EditorWindow.GetWindow (typeof(ObjectInteractions));
	}

	void OnGUI() {
		//Change tag
		setInteractable = EditorGUILayout.Toggle("Set Tag",setInteractable);
		EditorGUILayout.Space();
		if (GUILayout.Button("Update Selected",GUILayout.Height(40))){
			GameObject[] selected = Selection.gameObjects;
			for (int i = 0; i < selected.Length; i++) {
				GameObject go = selected [i];
				if (setInteractable) {
					go.tag = "Interactible";
				} else {
					if (go.tag != "Interactible" && go.GetComponent<ObjectStrangeLocation> () != null) {
						go.GetComponent<ObjectStrangeLocation> ().enabled = false;
					}
				}
				//Add ObjectStrangeLocation
				ObjectStrangeLocation objStrLoc = go.GetComponent<ObjectStrangeLocation> (); 
				if (objStrLoc == null) {
					go.AddComponent<ObjectStrangeLocation> ();
				} else if (!objStrLoc.enabled && go.tag == "Interactible") {
					objStrLoc.enabled = true;
				}
				//Add Destructable Object
				DestructableObject destObj = go.GetComponent<DestructableObject> (); 
				if (destObj == null) {
					go.AddComponent<DestructableObject> ();
				}
				//Add SoundEffect
				SoundEffect soundEffect = go.GetComponent<SoundEffect> (); 
				if (soundEffect == null) {
					go.AddComponent<SoundEffect> ();
				}
				MeshCollider mesh = go.GetComponent<MeshCollider> ();
				if (mesh == null) {
					MeshCollider newMesh = go.AddComponent<MeshCollider> ();
					newMesh.convex = true;
				} else {
					mesh.convex = true;
				}
				Rigidbody rb = go.GetComponent<Rigidbody> ();
				if (rb == null) {
					go.AddComponent<Rigidbody> ();
				}
			}
		}
	}
}
