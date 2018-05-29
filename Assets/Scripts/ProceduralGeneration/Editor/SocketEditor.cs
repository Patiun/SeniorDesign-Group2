using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Socket))]
public class SocketEditor : Editor {

	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();

		Socket socket = (Socket)target;

		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Generate")) {
			socket.GenerateRoom (Random.Range(0,socket.roomOptions.Length));
		}
		if (GUILayout.Button ("Reset")) {
			socket.Reset ();
		}
		GUILayout.EndHorizontal ();
	}
}
