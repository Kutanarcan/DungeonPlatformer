using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Level
{
    None = 0,
    Level1 = 10,
    Level2 = 20,
    Level3 = 30
}

[System.Serializable]
public abstract class LevelDataBase
{
    public abstract Level Level { get; }
}
