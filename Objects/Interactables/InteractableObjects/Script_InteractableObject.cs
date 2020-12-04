﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_InteractableObject : Script_Interactable
{
    public int Id;
    public string nameId;
    public bool isActive = true;
    [SerializeField] protected Transform rendererChild;
    protected Script_Game game;
    
    // Update is called once per frame
    protected virtual void Update() {}

    public virtual void HandleAction(string action)
    {
        print($"Handling action: {action}");
        if (action == Const_KeyCodes.Action1)
        {
            ActionDefault();
        }
    }
    
    public virtual void ActionDefault() {}
    
    public virtual void ActionB() {}
    
    public virtual void ActionC() {}
    
    public virtual void Setup(
        bool isForceSortingLayer,
        bool isAxisZ,
        int offset
    )
    {
        game = Script_Game.Game;
        if (isForceSortingLayer)    EnableSortingOrder(isAxisZ, offset); 
    }
    
    public virtual void SetupSwitch(
        bool isOn,
        Sprite onSprite,
        Sprite offSprite
    ) {}
    
    public virtual void SetupLights(
        Light[] lights,
        float onIntensity,
        float offIntensity,
        bool isOn,
        Sprite onSprite,
        Sprite offSprite
    ){}
    
    public virtual void SetupText(
        Script_DialogueManager dm,
        Script_Player p,
        Model_Dialogue d
    ){}

    public virtual void SwitchDialogueNodes(Script_DialogueNode[] nodes){}

    public virtual void EnableSortingOrder(bool isAxisZ, int offset)
    {
        rendererChild.GetComponent<Script_SortingOrder>().EnableWithOffset(offset, isAxisZ);
    }

    public Transform GetRendererChild()
    {
        return rendererChild;
    }

    public virtual void InitializeState() {}
}
