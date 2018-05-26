using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NavObstacleWindow : EditorWindow {

	private bool addNavMesh = true;
	private bool addMeshCollider = true;

	[MenuItem("Window/Operation Exodus/Setup Nav Obstacle")]
	public static void ShowWindow() {
		EditorWindow.GetWindow (typeof(NavObstacleWindow));
	}

	private void init() {
		addNavMesh = true;
		addMeshCollider = true;
	}

	void OnGUI() {
		EditorGUILayout.Space ();
		EditorGUILayout.LabelField ("Navigation Setup Options", EditorStyles.boldLabel);
		addNavMesh = EditorGUILayout.Toggle ("Add a NavMeshSourceTag",addNavMesh);
		addMeshCollider = EditorGUILayout.Toggle ("Add a Mesh Collider",addMeshCollider);
		EditorGUILayout.Space ();
		if (GUILayout.Button ("Update Selected",GUILayout.Height(40))) {
			GameObject[] selected = Selection.gameObjects;
			for (int i = 0; i < selected.Length; i++) {
				if (addNavMesh && selected [i].GetComponent<NavMeshSourceTag> () == null) {
					selected [i].AddComponent<NavMeshSourceTag> ();
				}
				if (addMeshCollider && selected [i].GetComponent<MeshCollider> () == null) {
					selected [i].AddComponent<MeshCollider> ();
				}
			}
		}
	}
}
