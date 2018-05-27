using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectDropZone))]
public class DropZoneEditor : Editor {

	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();

		ObjectDropZone zone = (ObjectDropZone)target;

		zone.width = GUILayout.HorizontalSlider (zone.width, 0.1f, 10f);
		zone.height = GUILayout.HorizontalSlider (zone.height, 0.1f, 10f);
		zone.length = GUILayout.HorizontalSlider (zone.length, 0.1f, 10f);
	}
}
