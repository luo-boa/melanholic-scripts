using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_LastElevatorEffect : Script_StickerEffect
{
    [SerializeField] protected Script_ExitMetadataObject exit;
    [SerializeField] private Script_Elevator.Types type;
    [SerializeField] private Script_ElevatorBehavior elevatorExitBehavior;
    [SerializeField] private Script_ElevatorBehavior elevatorSaveAndStartWeekendBehavior;
    
    void Awake()
    {
        exit = Script_Game.Game.LastElevatorExit;
    }
    
    public override void Effect()
    {
        Script_Game game = Script_Game.Game;

        game.ChangeStateCutScene();
        
        // Check Game if this is used in Mynes Grand Mirror where we need to switch to the Weekend Cycle.
        if (game.IsLastElevatorSaveAndStartWeekendCycle())
        {
            game.ElevatorCloseDoorsCutScene(exit, elevatorSaveAndStartWeekendBehavior, type);
        }
        else
        {
            game.ElevatorCloseDoorsCutScene(exit, elevatorExitBehavior, type);
        }
    }
}
