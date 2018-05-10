namespace VRTK {
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class ForceVentSnap : MonoBehaviour {

		public GameObject vent;

		// Use this for initialization
		void Start () {
			GetComponent<VRTK_SnapDropZone> ().ForceSnap (vent);
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}
