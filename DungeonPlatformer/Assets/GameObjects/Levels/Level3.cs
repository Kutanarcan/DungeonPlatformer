using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : LevelBase
{
    public override Level Level => Level.Level3;

    public override void Load(LevelDataBase levelBaseData)
    {

    }

    public override LevelDataBase Save()
    {
        LevelDataBase level3 = new Level3Data();

        return level3;
    }
}
