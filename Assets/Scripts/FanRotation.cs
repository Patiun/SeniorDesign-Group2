using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour {

    public float fanSpeed;
    public bool on;
    public int timeInactive;
    public PlayerHealth playerHealth;

    private Quaternion originalRotation;
    private int count;

	// Use this for initialization
	void Start () {
        originalRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (on == true)
        {
            count = 0;
            transform.Rotate(Vector3.forward * (fanSpeed * Time.deltaTime));
        }
        if(on == false){
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, fanSpeed * Time.deltaTime);
            if (count >= timeInactive){
                on = true;
            }
            else{
                count++;
            }
        }
	}

	public void OnTriggerEnter(Collider collider)
	{
        if(collider.gameObject.tag == "Player" && on){
            playerHealth.InstaKill();
        }
	}
}
