using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : LevelBase
{
    public override Level Level => Level.Level2;

    public override void Load(LevelDataBase levelBaseData)
    {

    }

    public override LevelDataBase Save()
    {
        LevelDataBase level2 = new Level2Data();

        return level2;
    }
}
