using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Differs from Player in that PlayerCopy should only handle movement.
/// </summary>
public class Script_PlayerCopy : Script_Player
{
    protected override void Update()
    {
        // ------------------------------------------------------------------
        // Visuals
        HandleGhostGraphics();
        // ------------------------------------------------------------------

        if (game.state == Const_States_Game.Interact)
        {
            if (IsNotMovingState())     StopMovingAnimations();
            else                        playerMovementHandler.HandleMoveInput();
        }
        else
        {
            StopMovingAnimations();
        }
    }    
}
