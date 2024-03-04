using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject gameCanvas;
    public GameObject self;
    public string savedDialogue;
    public DialogManager dialogManager;

    public void Start()
    {
        gameCanvas.SetActive(false);
        self.SetActive(true);
    }

    public void startGame()
    {
        dialogManager.resetGame();
        gameCanvas.SetActive(true);
        self.SetActive(false);
        dialogManager.GetNextOne("initial");
    }

    public void loadGame()
    {
        gameCanvas.SetActive(true);
        self.SetActive(false);
        dialogManager.GetNextOne(savedDialogue);
    }
}
