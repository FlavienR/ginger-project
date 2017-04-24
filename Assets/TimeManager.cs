using Assets.Enum;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float _startTime;
    private float _currentTime;

    public bool DayTime()
    {
        return _currentTime < (int)Cycle.Night && _currentTime >= (int)Cycle.Day;
    }

    // Use this for initialization
    private void Start()
    {
        StartTime = (int)Cycle.Day;
    }

    private float StartTime
    {
        get
        {
            return _startTime;
        }
        set
        {
            _startTime = value <= 0 ? (int)Cycle.Day : value;
            _currentTime = _startTime;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        _currentTime += Time.deltaTime;
        transform.rotation = Quaternion.Euler(_currentTime, 0f, 0f);
        if (_currentTime >= 266f)
        {
            _currentTime = 0;
        }
    }
}
