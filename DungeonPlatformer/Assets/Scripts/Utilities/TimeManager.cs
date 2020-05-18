using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeManager
{
    static float _timeScale = 1.0f;

    public static float timeScale
    {
        get
        {
            return _timeScale;
        }

        set
        {
            _timeScale = value;
        }
    }

    public static float deltaTime
    {
        get
        {
            return Time.deltaTime * _timeScale;
        }
    }

    public static float fixedDeltaTime
    {
        get
        {
            return Time.fixedDeltaTime * _timeScale;
        }
    }
}
