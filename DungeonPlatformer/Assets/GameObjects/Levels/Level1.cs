using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : LevelBase
{
    public override Level Level => Level.Level1;

    public override void Load(LevelDataBase levelBaseData)
    {

    }

    public override LevelDataBase Save()
    {
        LevelDataBase level1 = new Level1Data();

        return level1;
    }
}
