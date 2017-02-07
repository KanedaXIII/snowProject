using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {

    //Tiempo inicial del cronómetro
    [HideInInspector]
    public float timeMax;

    private float currentTime;

    private bool stopRunning = false;

    public event System.Action  OnTime = delegate { };
    
	// Use this for initialization
	void Start () {
        currentTime = timeMax;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime -= Time.deltaTime;
        if (currentTime<=0.0f && !stopRunning)
        {
            OnTime();
            stopRunning = true;
        }
	}

   
}
