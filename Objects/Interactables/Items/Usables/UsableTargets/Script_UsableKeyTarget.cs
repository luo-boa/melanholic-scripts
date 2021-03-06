﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_UsableKeyTarget : Script_UsableTarget
{
    [SerializeField] protected bool isLocked = true;
    [SerializeField] protected Script_UsableKey myKey;
    [SerializeField] protected Script_TileMapExitEntrance myExit;
    [SerializeField] private Script_TreasureChestLocked myTreasureChest;

    public Script_UsableKey MyKey
    {
        get => myKey;
    }
    
    public virtual bool Unlock(Script_UsableKey key)
    {
        Debug.Log($"{name}: TRYING TO UNLOCK ME with Key Id {key.id}!!!");
        
        if (key == myKey)
        {
            Script_Game.Game.CloseInventory();
            OnUnlock(key);
            return true;
        }

        return false;
    }

    protected virtual void OnUnlock(Script_UsableKey key)
    {
        Debug.Log($"YAY UNLOCKED!!!");
        // unlock animation
        isLocked = false;
        if (myExit != null)
        {
            myExit.IsDisabled = false;
            Script_ItemsEventsManager.Unlock(key, Id);
        }
        if (myTreasureChest != null)    myTreasureChest.UnlockWithKey();
    }
}
