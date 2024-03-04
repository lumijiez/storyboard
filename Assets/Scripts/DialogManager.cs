using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{ 
    public TextMeshProUGUI textComponent;

    public TextMeshProUGUI buttonOne;

    public TextMeshProUGUI buttonTwo;

    public TextMeshProUGUI healthPoints;

    public TextMeshProUGUI bulletCount;

    public TextMeshProUGUI moraleCount;

    public TextMeshProUGUI resourceCount;

    public TextMeshProUGUI dialogName;

    public Image mainBackground;

    public Image talkingPirateImage;

    public Dialogs dialogs;

    public Dialog dialogue;

    public Dialog savedDialog;

    public Events eventManager;

    public GameObject panel;

    public GameObject piratePanel;

    public GameObject talkingPirate;

    public GameObject heartObject;

    public GameObject selfCanvas;

    public GameObject menuCanvas;

    public MenuButtons menuSaver;

    public AudioSource audioSource;

    public AudioSource eventAudio;

    public Coroutine textCoroutine;

    public bool isEvent = false;

    public bool isGameOver = false;

    public bool isReadyForEvents = false;

    public float textSpeed;

    public int index;

    public Dictionary<string, int> items = new Dictionary<string, int>();

    public int health;

    public int bullets;

    public int morale;

    public int resources;

    public double tsunamiChance = 0.01;

    public double animalAttackChance = 0.01;

    public string currentDialogueName;

    public void ChangeHealth(int dmg)
    {
        health += dmg;
        healthPoints.text = health.ToString();
    }

    public void GameOver()
    {
       // panel.SetActive(false);
       // piratePanel.SetActive(false);
       // talkingPirate.SetActive(false);
       // heartObject.SetActive(false);
       // isGameOver = true;
    }

    public void ChangeBullet(int blt)
    {
        bullets += blt;
        bulletCount.text = bullets.ToString();
    }

    public void ChangeResource(int res)
    {
        resources += res;
        resourceCount.text = resources.ToString();
    }

    public void ChangeMorale(int mor)
    {
        morale += mor;
        moraleCount.text = morale.ToString();
    }

    void Start()
    {

        hideHeartPanel();
        health = 1;
        morale = 0;
        bullets = 0;
        resources = 0;
        resourceCount.text = resources.ToString();
        moraleCount.text = morale.ToString();
        bulletCount.text = bullets.ToString();
        healthPoints.text = health.ToString();
        dialogue = dialogs.GetFirst();
        textComponent.text = string.Empty;
        buttonOne.text = dialogue.FirstButtonText;
        buttonTwo.text = dialogue.SecondButtonText;
        currentDialogueName = dialogue.DialogName;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
            if (textComponent.text == dialogue.DialogueText[index])
            {
                NextLine();
            } 
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogue.DialogueText[index];
            }
        }
    }

    public void showHeartPanel()
    {
        heartObject.SetActive(true);
    }

    public void hideHeartPanel()
    {
        heartObject.SetActive(false);
    }

    public void TurnEventOff()
    {
        StopCoroutine(textCoroutine);
        isEvent = false;
        dialogue = savedDialog;
        StartDialogue();
    }

    public void resetGame()
    {
        isEvent = false;
        isGameOver = false;
        isReadyForEvents = false;
        selfCanvas.SetActive(false);
        menuCanvas.SetActive(true);
        dialogue = dialogs.GetFirst();
    }

    public void GetNextOne(string dialog = null)
    {
        if (dialog != null)
        {
            if (textCoroutine != null) StopCoroutine(textCoroutine);
            dialogue = dialogs.GetNextOne(dialog);
            textComponent.text = string.Empty;
            buttonOne.text = dialogue.FirstButtonText;
            buttonTwo.text = dialogue.SecondButtonText;
        } 
        else
        {
            if (isEvent)
            {
                StopCoroutine(textCoroutine);
                dialogue = eventManager.getNextEventOne();
            }
            else if (isEvent == false && isReadyForEvents && eventManager.checkForChance())
            {
                StopCoroutine(textCoroutine);
                isEvent = true;
                savedDialog = dialogue;
                dialogue = eventManager.getRandomAdmissibleEvent();
            }
            else if (isEvent == false)
            {
                dialogue = savedDialog;
                dialogue = dialogs.GetNextOne();
                StopCoroutine(textCoroutine);
            }
        }
        StartDialogue();
    }

    public void GetNextTwo()
    {
        if (isEvent)
        {
            dialogue = eventManager.getNextEventTwo();
            StopCoroutine(textCoroutine);
        } 
        else if (eventManager.checkForChance() && isEvent == false)
        {
            StopCoroutine(textCoroutine);
            isEvent = true;
            savedDialog = dialogue;
            dialogue = eventManager.getRandomAdmissibleEvent();
        }
        else if (isEvent == false)
        {
            dialogue = savedDialog;
            dialogue = dialogs.GetNextTwo();
            StopCoroutine(textCoroutine);
        }
        StartDialogue();
    }

    public void SaveDialogue()
    {
        selfCanvas.SetActive(false);
        menuCanvas.SetActive(true);
        menuSaver.savedDialogue = currentDialogueName;
    }

    public void StartDialogue()
    {
        eventAudio.Pause();
        index = 0;
        talkingPirate.SetActive(true);
        piratePanel.SetActive(false);
        if (dialogue.DialogueImage != null)
        {
            mainBackground.sprite = Resources.Load<Sprite>("Sprites/" + dialogue.DialogueImage);
        }

        if (dialogue.TalkingImage != null)
        {
            talkingPirateImage.sprite = Resources.Load<Sprite>("Sprites/" + dialogue.TalkingImage);
        }
        else
        {
            talkingPirateImage.sprite = Resources.Load<Sprite>("Sprites/pirateSprite");
        }

        if (dialogue.AudioSprite != null)
        {
            eventAudio.clip = Resources.Load<AudioClip>("Audio/" + dialogue.AudioSprite);
            eventAudio.loop = dialogue.IsAudioRepeating;
            eventAudio.Play();
        }
        textComponent.text = string.Empty;
        buttonOne.text = dialogue.FirstButtonText;
        buttonTwo.text = dialogue.SecondButtonText;
        dialogName.text = dialogue.DialogueName;
        currentDialogueName = dialogue.DialogueName;
        textCoroutine = StartCoroutine(TypeLine());
    }

    public void StartTextRoutine()
    {
        textCoroutine = StartCoroutine(TypeLine());
    }

    public void StopTextRoutine()
    {
        StopCoroutine(textCoroutine);
    }

    IEnumerator TypeLine()
    {
        audioSource.Play();
        audioSource.loop = true;
        foreach (char c in dialogue.DialogueText[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        
        if (index == dialogue.DialogueText.Length - 1 && !isGameOver)
        {
            talkingPirate.SetActive(false);
            piratePanel.SetActive(true);
        }
        audioSource.Pause();
    }

    void NextLine()
    {
        if (index < dialogue.DialogueText.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            textCoroutine = StartCoroutine (TypeLine());
        } else if (!isGameOver)
        {
            talkingPirate.SetActive(false);
            piratePanel.SetActive(true);
        }
    }
}
