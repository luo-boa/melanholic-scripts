﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_SaveLoadLevelBehavior_0 : Script_SaveLoadLevelBehavior
{
    [SerializeField] private Script_LevelBehavior_0 LB0;

    public override void Save(Model_RunData data)
    {
        Model_LevelBehavior_0 lvlModel = new Model_LevelBehavior_0(
            LB0.didStartThought,
            LB0.demonSpawns,
            LB0.isDone
        );
        
        data.levelsData.LB0 = lvlModel;
    }

    public override void Load(Model_RunData data)
    {
        if (data.levelsData == null)
        {
            Debug.Log("There is no levels state data to load.");
            return;
        }

        if (data.levelsData.LB0 == null)
        {
            Debug.Log("There is no LB0 state data to load.");
            return;
        }

        Model_LevelBehavior_0 lvlModel  = data.levelsData.LB0;
        LB0.didStartThought             = lvlModel.didStartThought;
        LB0.demonSpawns                 = lvlModel.demonSpawns;
        LB0.isDone                      = lvlModel.isDone;

        Debug.Log($"-------- LOADED {name} --------");
        Script_Utils.DebugToConsole(lvlModel);
    }
}
