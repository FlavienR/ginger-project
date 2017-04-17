using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float startTime;

    public float currentTime;

    enum Cycle
    {
        Day = 7,
        Night = 177
    }

    // Use this for initialization
    void Start () {
        StartTime = (int)Cycle.Day;

    }
	
    float StartTime
    {
        get
        {
            return startTime;
        }
        set
        {
            startTime = value <= 0 ? (int)Cycle.Day : value;
            currentTime = startTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        transform.Rotate(new Vector3(currentTime * 0.001f, 0f));
    }
}
