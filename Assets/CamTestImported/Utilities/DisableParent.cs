using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableParent : MonoBehaviour {
	public void disable() {
		this.gameObject.transform.parent.gameObject.SetActive(false);
	}
}
