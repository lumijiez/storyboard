using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{

    public DialogManager DialogManager;

    public Dialog currentEvent { get; private set; }

    public bool checkForChance()
    {
        float randomNumber = Random.Range(0.0f, 1.0f);
        return randomNumber < 0.2f;
    }

    public Dialog getRandomAdmissibleEvent()
    {

        List<Dialog> possibleEvents = new List<Dialog>();

        possibleEvents.Add(GetThunderEvent());
        possibleEvents.Add(GetTsunamiEvent());
        possibleEvents.Add(GetAnimalAttackEvent());

        int randomIndex = Random.Range(0, possibleEvents.Count);
        currentEvent = possibleEvents[randomIndex];

        return currentEvent;

    }
        

    public Dialog getNextEventOne()
    {
        currentEvent = currentEvent.NextDialogueOne;
        return currentEvent;
    }

    public Dialog getNextEventTwo()
    {
        currentEvent = currentEvent.NextDialogueTwo;
        return currentEvent;
    }


    private Dialog GetThunderEvent()
    {
        return new Dialog("thunder",
            new string[] {
                "Ricardo, did you hear that? Thunder... a storm is approaching!",
                "Quickly, secure our belongings! We can't afford to lose anything in this weather.",
                "Hold tight, lad! The winds are picking up, and the rain is coming down hard.",
                "Blast! Lightning struck nearby... I fear we may have lost some of our supplies.",
                "Check our inventory, Ricardo. We need to assess the damage and salvage what we can.",
                "Stay alert, my friend. The storm may have passed, but its effects linger.",
                "Let's hope for clearer skies ahead."
            },
            "Sigh.", "Sadness.", "Thunder", (m) =>
            {
                m.ChangeResource(-10);
                m.TurnEventOff();
            }, (m) =>
            {
                m.ChangeResource(-10);
                m.TurnEventOff();
            }, "thunderEvent", null, "thunder");
    }

    private Dialog GetTsunamiEvent()
    {
        return new Dialog("tsunami",
            new string[] {
                "Ricardo, do you feel that? The ground is trembling...",
                "By Neptune's beard! It's a tsunami! We must flee to higher ground!",
                "Hurry, lad! Grab what you can, but leave the rest behind!",
                "The wave is upon us! Brace yourself, Ricardo!",
                "The water's receding... but the damage is done.",
                "Check our supplies, Ricardo. The tsunami may have swept some away.",
                "Let's count ourselves lucky to be alive, lad. The sea is a merciless mistress."
            },
            "Sigh.", "Sadness.", "Tsunami", (m) =>
            {
                m.ChangeResource(-20);
                m.TurnEventOff();
            }, (m) =>
            {
                m.ChangeResource(-20);
                m.TurnEventOff();
            }, "tsunamiEvent", null, "tsunami");
    }

    private Dialog GetAnimalAttackEvent()
    {
        return new Dialog("animalAttack",
            new string[] {
                "Ricardo, do you hear that? Something's moving in the bushes...",
                "Be on your guard, lad! It could be a wild animal!",
                "There it is! A ferocious beast!",
                "Defend yourself, Ricardo! We can't let it get the upper hand!",
                "Phew! That was too close for comfort.",
                "But look, Ricardo, it seems the creature has damaged some of our supplies.",
                "We'll need to be more cautious from now on. The wilderness is unforgiving."
            },
            "Sigh.", "Sadness.", "Animal Attack", (m) =>
            {
                m.ChangeResource(-15);
                m.TurnEventOff();
            }, (m) =>
            {
                m.ChangeResource(-15);
                m.TurnEventOff();
            }, "animalAttackEvent", null, "tigerRoad");
    }


}
