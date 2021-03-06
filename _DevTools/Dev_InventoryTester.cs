﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Dev_InventoryTester : MonoBehaviour
{
    public string itemId;

    void Start()
    {
        if (Const_Dev.GiveItems)
        {
            AddStickers();
            AddKeys();
        }
    }

    public void AddItemById()
    {
        Script_Game.Game.AddItemById(itemId);
    }

    public void AddStickers()
    {
        AddPsychicDuck();
        AddAnimalWithin();
        AddBoarNeedle();
        AddIceSpike();
        AddMelancholyPiano();
        AddLastElevator();
        AddLetThereBeLight();
        AddPuppeteer();
    }

    public void AddKeys()
    {
        AddSuperSmallKey();
    }

    public void WeekendCycle()
    {
        AddPsychicDuck();
        AddAnimalWithin();
        AddBoarNeedle();
        AddIceSpike();
        AddMelancholyPiano();
        AddLastElevator();
    }

    // ------------------------------------------------------------------------
    //  Stickers
    public void AddPsychicDuck()
    {
        Script_Game.Game.AddItemById(Const_Items.PsychicDuckId);
    }

    public void AddBoarNeedle()
    {
        Script_Game.Game.AddItemById(Const_Items.BoarNeedleId);
    }

    public void AddAnimalWithin()
    {
        Script_Game.Game.AddItemById(Const_Items.AnimalWithinId);
    }

    public void AddIceSpike()
    {
        Script_Game.Game.AddItemById(Const_Items.IceSpikeId);
    }

    public void AddMelancholyPiano()
    {
        Script_Game.Game.AddItemById(Const_Items.MelancholyPianoId);
    }

    public void AddLastElevator()
    {
        Script_Game.Game.AddItemById(Const_Items.LastElevatorId);
    }

    public void AddLetThereBeLight()
    {
        Script_Game.Game.AddItemById(Const_Items.LetThereBeLightId);
    }

    public void AddPuppeteer()
    {
        Script_Game.Game.AddItemById(Const_Items.PuppeteerId);
    }

    // ------------------------------------------------------------------------
    //  Usables
    public void AddMasterKey()
    {
        Script_Game.Game.AddItemById(Const_Items.MasterKeyId);
    }

    public void AddSuperSmallKey()
    {
        Script_Game.Game.AddItemById(Const_Items.SuperSmallKeyId);
    }

    // ------------------------------------------------------------------------
    //  Collectibles

    public void AddWinterStone()
    {
        Script_Game.Game.AddItemById(Const_Items.WinterStoneId);
    }

    public void AddSpringStone()
    {
        Script_Game.Game.AddItemById(Const_Items.SpringStoneId);
    }

    public void AddSummerStone()
    {
        Script_Game.Game.AddItemById(Const_Items.SummerStoneId);
    }

    public void AddAutumnStone()
    {
        Script_Game.Game.AddItemById(Const_Items.AutumnStoneId);
    }

    public void AddLastWellMap()
    {
        Script_Game.Game.AddItemById(Const_Items.LastWellMapId);
    }
    
    public void AddLastSpellRecipeBook()
    {
        Script_Game.Game.AddItemById(Const_Items.LastSpellRecipeBookId);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Dev_InventoryTester))]
public class Dev_InventoryTesterTester : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        Dev_InventoryTester inventoryTester = (Dev_InventoryTester)target;
        if (GUILayout.Button("AddItemById()"))
        {
            inventoryTester.AddItemById();
        }
        
        GUILayout.Space(8);
        
        if (GUILayout.Button("Add: Psychic Duck"))
        {
            inventoryTester.AddPsychicDuck();
        }

        if (GUILayout.Button("Add: Boar Needle"))
        {
            inventoryTester.AddBoarNeedle();
        }

        if (GUILayout.Button("Add: Animal Within"))
        {
            inventoryTester.AddAnimalWithin();
        }

        if (GUILayout.Button("Add: Ice Spike"))
        {
            inventoryTester.AddIceSpike();
        }

        if (GUILayout.Button("Add: Melancholy Piano"))
        {
            inventoryTester.AddMelancholyPiano();
        }

        if (GUILayout.Button("Add: Last Elevator"))
        {
            inventoryTester.AddLastElevator();
        }

        if (GUILayout.Button("Add: Let There Be Light"))
        {
            inventoryTester.AddLetThereBeLight();
        }

        if (GUILayout.Button("Add: Puppeteer"))
        {
            inventoryTester.AddPuppeteer();
        }

        GUILayout.Space(8);

        if (GUILayout.Button("Add: Master Key"))
        {
            inventoryTester.AddMasterKey();
        }

        if (GUILayout.Button("Add: Super Small Key"))
        {
            inventoryTester.AddSuperSmallKey();
        }

        GUILayout.Space(8);

        if (GUILayout.Button("Add: Winter Stone"))
        {
            inventoryTester.AddWinterStone();
        }

        if (GUILayout.Button("Add: Spring Stone"))
        {
            inventoryTester.AddSpringStone();
        }

        if (GUILayout.Button("Add: Summer Stone"))
        {
            inventoryTester.AddSummerStone();
        }

        if (GUILayout.Button("Add: Autumn Stone"))
        {
            inventoryTester.AddAutumnStone();
        }

        if (GUILayout.Button("Add: Last Well Map"))
        {
            inventoryTester.AddLastWellMap();
        }

        if (GUILayout.Button("Add: Last Spell Recipe Book"))
        {
            inventoryTester.AddLastSpellRecipeBook();
        }
    }
}
#endif