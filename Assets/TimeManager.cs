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

    public Boolean DayTime()
    {
        return currentTime < (int)Cycle.Night && currentTime >= (int)Cycle.Day;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        transform.rotation = Quaternion.Euler(currentTime, 0f, 0f);
        if (currentTime >= 266f)
            currentTime = 0;
    }
}
