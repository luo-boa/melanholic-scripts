﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PaintingEntranceManager : MonoBehaviour
{
    public Script_DialogueChoice[] choices;
    public CanvasGroup paintingEntranceChoiceCanvas;
    
    public void StartPaintingEntrancePromptMode()
    {
        // to get rid of flash at beginning
        foreach(Script_DialogueChoice choice in choices)
        {
            choice.cursor.enabled = false;
        }

        paintingEntranceChoiceCanvas.gameObject.SetActive(true);
    }

    public void InputChoice(int Id)
    {
        /// Use NextNodeAction() on "yes" node to handle PaintingEntrance
        EndPrompt();

        if (Id == 0)
        {
            // print($"is it painting node? {Script_DialogueManager.DialogueManager.currentNode is Script_DialogueNode_PaintingEntrance}");
            Script_DialogueNode currentNode = Script_DialogueManager.DialogueManager.currentNode;
            Script_DialogueNode_PaintingEntrance paintingNode = (Script_DialogueNode_PaintingEntrance)currentNode;
            
            paintingNode.paintingEntrance.HandleExit();
            
            Script_DialogueManager.DialogueManager.HandleEndDialogue();
        }
        else
        {
            Script_DialogueManager.DialogueManager.NextDialogueNode(Id);
        }
    }

    private void EndPrompt()
    {
        paintingEntranceChoiceCanvas.gameObject.SetActive(false);
    }

    public void Setup()
    {
        paintingEntranceChoiceCanvas.gameObject.SetActive(false);
    }
}
