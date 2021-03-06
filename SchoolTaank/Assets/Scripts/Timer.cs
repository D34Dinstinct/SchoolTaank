﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float startTime;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        float t = Time.time - startTime;   //Gives amount of time since timer started

        string minutes = ((int)t / 60).ToString();  //Convert
        string seconds = (t % 60).ToString("f2");  //Only 2 decimals

        timerText.text = minutes + ":" + seconds;
	}
}
