using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectDropZone))]
public class DropZoneEditor : Editor {

	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();

		ObjectDropZone zone = (ObjectDropZone)target;

		zone.areaScaleX = GUILayout.HorizontalSlider (zone.areaScaleX, 0.1f, 10f);
		zone.areaScaleY = GUILayout.HorizontalSlider (zone.areaScaleY, 0.1f, 10f);
		zone.areaScaleZ = GUILayout.HorizontalSlider (zone.areaScaleZ, 0.1f, 10f);
	}
}
