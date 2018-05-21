using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour {

    public float fanSpeed;
    public bool on;
    public int timeInactive;
    public PlayerHealth playerHealth;
	public AudioSource fan,fan_on,fan_off;

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
			if (!fan.isPlaying && !fan_on.isPlaying) {
				fan.Play ();
			}
            count = 0;
            transform.Rotate(Vector3.forward * (fanSpeed * Time.deltaTime));
        }
        if(on == false){
			if (fan.isPlaying) {
				fan.Stop ();
				if (!fan_off.isPlaying) {
					fan_off.Play ();
				}
			}
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, fanSpeed * Time.deltaTime);
            if (count >= timeInactive){
                on = true;
				fan_on.Play ();
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
