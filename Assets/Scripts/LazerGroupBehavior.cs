using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGroupBehavior : MonoBehaviour {

    public GameObject lazerGroup;
    public int timeBetween;
    public bool groupOn;
    private LazerBehavior[] lazers;
    private int count = 0;
    int index = 0;
    // Use this for initialization
    void Start(){
        lazers = lazerGroup.GetComponentsInChildren<LazerBehavior>();
        randomize();
    }
	
	// Update is called once per frame
	void Update () {

        if (index < lazers.Length)
        {
            if (count > timeBetween)
            {
                count = 0;
                lazers[index].on = groupOn;
                index++;
            }
            else
            {
                count++;
            }
        } else {
            randomize();
            index = 0;
        }
	}

    void randomize(){
        System.Random rand = new System.Random();
        for (int i = 0; i < lazers.Length - 1; i++)
        {
            int j = rand.Next(i, lazers.Length);
            LazerBehavior temp = lazers[i];
            lazers[i] = lazers[j];
            lazers[j] = temp;
        }
        //Debug.Log(lazers.Length);
    }


}
