using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDropZone : MonoBehaviour {

	public GameObject objectiveObject;
	public float width = 0.1f, length = 0.1f, height = 0.1f;
		
	public void DropObject() {
		float randX = Random.Range (-width, width);
		float randY = Random.Range (-height, height);
		float randZ = Random.Range (-length, length);

		Vector3 dropLocation = transform.position + Quaternion.AngleAxis(transform.rotation.eulerAngles.y,transform.up) * (new Vector3 (randX, randY, randZ));

		GameObject objective = Instantiate (objectiveObject);
		objective.transform.position = dropLocation;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube (transform.position, Quaternion.AngleAxis(transform.rotation.eulerAngles.y,transform.up) * (new Vector3 (2*width, 2*height, 2*length)));
	}
}
