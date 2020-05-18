using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelBase : MonoBehaviour
{
    public abstract Level Level { get; }

    public abstract LevelDataBase Save();
    

    public virtual void Load(LevelDataBase levelBaseData)
    {

    }
}
