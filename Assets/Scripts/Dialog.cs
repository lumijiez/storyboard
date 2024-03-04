using System;

public class Dialog
{
    public string DialogName { get; set; }

    public string[] DialogueText { get; set; }

    public string DialogueImage { get; set; }

    public string DialogueName { get; set; }

    public Dialog NextDialogueOne { get; set; }

    public Dialog NextDialogueTwo { get; set; }

    public string FirstButtonText { get; set; }

    public string SecondButtonText { get; set; }

    public Action<DialogManager> ActionOne { get; set; }

    public Action<DialogManager> ActionTwo { get; set; }

    public string TalkingImage { get; set; }

    public string AudioSprite { get; set; }

    public bool IsAudioRepeating { get; set; }


    public Dialog(
        string dialogName,
        string[] dialogueText, 
        string firstButtonText = null,
        string secondButtonText = null, 
        string dialogueName = null, 
        Action<DialogManager> actionOne = null, 
        Action<DialogManager> actionTwo = null, 
        string dialogueImage = null, 
        string talkingImage = null, 
        string audioSprite = null, 
        bool isAudioRepeating = false)
    {
        DialogName = dialogName;
        DialogueText = dialogueText;
        FirstButtonText = firstButtonText;
        SecondButtonText = secondButtonText;
        ActionOne = actionOne;
        ActionTwo = actionTwo;
        DialogueName = dialogueName;
        DialogueImage = dialogueImage;
        TalkingImage = talkingImage;
        AudioSprite = audioSprite;
        IsAudioRepeating = isAudioRepeating;
    }
}