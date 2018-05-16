using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public float open_speed = 1.0f;
	public float final_height_difference = 2.36f;

	public bool isOpen;
	public bool isClosed;
	public bool isLocked = true;
	public bool isOpening;
	public bool isClosing;
	public ParticleSystem[] closingPoofParticles;

	private Rigidbody rb;
	private Vector3 starting_pos;

	// Use this for initialization
	void Start () {
		isOpen = false;
		isClosed = true;
		isOpening = false;
		starting_pos = transform.position;
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isOpening) {
			if (transform.position.y >= starting_pos.y + final_height_difference) {
				isOpening = false;
				isOpen = true;
				rb.velocity = Vector3.zero;
			}
		}
		if (isClosing) {
			if (transform.position.y <= starting_pos.y) {
				isClosing = false;
				isClosed = true;
				foreach (ParticleSystem p in closingPoofParticles) {
					p.Emit (100);
				}
			}
		}
	}

	public void Open() {
		if (!isOpen) {
			if (isClosed || isClosing) {
				if (!isLocked) {
					isOpening = true;
					isClosed = false;
					isClosing = false;
					rb.useGravity = false;
					rb.velocity = new Vector3(0,open_speed,0);
				}
			}
		}
	}

	public void Close() {
		if (!isClosed) {
			if (isOpen || isOpening) {
				isClosing = true;
				isOpen = false;
				isOpening = false;
				rb.velocity = Vector3.zero;
				rb.useGravity = true;
			}
		}
	}

	public void Lock() {
		isLocked = true;
	}

	public void Unlock() {
		isLocked = false;
	}
}
