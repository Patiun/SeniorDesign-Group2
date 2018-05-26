using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDropZone : MonoBehaviour {

	public GameObject objectiveObject;
	public float areaScaleX, areaScaleZ, areaScaleY;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			DropObject();
		}
	}
		
	public void DropObject() {
		float randX = Random.Range (-areaScaleX, areaScaleX);
		float randY = Random.Range (-areaScaleY, areaScaleY);
		float randZ = Random.Range (-areaScaleZ, areaScaleZ);

		Vector3 dropLocation = transform.position + new Vector3 (randX, randY, randZ);

		GameObject objective = Instantiate (objectiveObject);
		objective.transform.position = dropLocation;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube (transform.position, new Vector3 (2*areaScaleX, 2*areaScaleY, 2*areaScaleZ));
	}
}
