using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// Displays an input canvas on interaction.
/// 
/// CCTV Choice must have Script_InteractableObjectInputChoice which 
/// </summary>
public class Script_InteractableObjectInput : Script_InteractableObject
{
    [SerializeField] private Script_InputManager inputManager;
    [SerializeField] private InputMode inputMode;
    [SerializeField] private TMP_InputField inputField;
    
    [SerializeField] private UnityEvent successAction;
    [SerializeField] private UnityEvent failureAction;
    
    public override void ActionDefault()
    {
        if (CheckDisabled())  return;

        if (Script_Game.Game.GetPlayer().State != Const_States_Player.Dialogue)
        {
            game.GetPlayer().SetIsTalking();

            // Set input canvas active
            inputManager.Initialize(inputMode, inputField, inputManager.CCTVInputCanvasGroup);
            inputManager.gameObject.SetActive(true);
        }
    }

    // Called from Level Behavior
    public void OnSubmitSuccess()
    {
        Debug.Log($"{name} Reaction to Success");
        
        EndInput();

        bool isUnityAction = successAction.CheckUnityEventAction();
        if (isUnityAction)      successAction.Invoke();
    }

    // Called from Level Behavior
    public void OnSubmitFailure()
    {
        Debug.Log($"{name} Reaction to Failure");
        
        EndInput();

        bool isUnityAction = failureAction.CheckUnityEventAction();
        if (isUnityAction)      failureAction.Invoke();
    }

    private void EndInput()
    {
        // Wait for the End of the Frame to end input so won't overlap with an interaction input.
        StartCoroutine(NextFrameEndInput());
        
        IEnumerator NextFrameEndInput()
        {
            yield return null;
            inputManager.End();
            Script_Game.Game.GetPlayer().SetIsInteract();
        }
    }
}
