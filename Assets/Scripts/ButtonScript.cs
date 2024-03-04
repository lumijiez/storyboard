using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour
{ 
    public DialogManager dialogManager;

    public void choiceOne()
    {
        if (dialogManager.dialogue.ActionOne.IsUnityNull() && dialogManager.isEvent)
        {
            dialogManager.TurnEventOff();
        } else
        {
            dialogManager.dialogue.ActionOne?.Invoke(dialogManager);
            dialogManager.GetNextOne();
        }
    }

    public void choiceTwo()
    {
        if (dialogManager.dialogue.ActionTwo.IsUnityNull() && dialogManager.isEvent)
        {
            dialogManager.TurnEventOff();
        } else
        {
            dialogManager.dialogue.ActionTwo?.Invoke(dialogManager);
            dialogManager.GetNextTwo();
        }
    }
}
