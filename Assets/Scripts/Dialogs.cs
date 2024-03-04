using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Dialogs : MonoBehaviour
{
    public Dialog CurrentDialogue { get; private set; }

    public Dialog initialDialog;

    public DialogManager DialogManager;

    public Dictionary<string, Dialog> dialogues = new Dictionary<string, Dialog>();

    string[] findMysteriousArtifactText = new string[] {
    "While exploring, we stumble upon a mysterious artifact buried in the sand.",
    "It glows faintly, emitting a strange energy that intrigues and frightens us.",
    "We must decide whether to investigate further or leave it be, wary of its unknown powers."
};

    string[] encounterHostileWildlifeText = new string[] {
    "As we travel through the wilderness, we encounter hostile wildlife that attacks us on sight.",
    "We must defend ourselves and find a way to escape the creatures, lest they overwhelm us."
};

    string[] discoverAncientRuinText = new string[] {
    "We come across a massive, ancient ruin that stretches far into the horizon.",
    "It is a testament to a civilization long gone, filled with history and untold secrets.",
    "We decide to explore the ruin, hoping to uncover its mysteries and perhaps find valuable treasures."
};

    string[] mysteriousFogText = new string[] {
    "A mysterious fog rolls in, obscuring our vision and disorienting us.",
    "The thick mist dampens our clothes and muffles our footsteps, creating an eerie atmosphere.",
    "We must navigate carefully, using our senses other than sight to detect any dangers that may lurk within the fog.",
    "The air is thick with suspense, and every sound seems magnified, keeping us on edge."
};

    string[] encounterMysteriousStrangerText = new string[] {
    "While resting, we are approached by a mysterious stranger.",
    "They are cloaked in shadow, and their features are obscured, making it difficult to discern their intentions.",
    "The stranger offers us valuable information that could aid us on our journey, but they ask for a favor in return.",
    "We are unsure if we can trust them, as their motives remain unclear.",
    "We must decide whether to accept their offer and risk the consequences, or to decline and potentially miss out on crucial information."
};

    string[] findHiddenCaveText = new string[] {
    "As we explore the area, we stumble upon a hidden cave, its entrance concealed by overgrown vegetation.",
    "The cave beckons to us, its darkness hinting at secrets waiting to be discovered.",
    "Curiosity gets the better of us, and we decide to explore the cave, unsure of what we might find inside.",
    "The cool air inside the cave is a stark contrast to the warmth outside, and the sound of dripping water echoes off the walls.",
    "We proceed cautiously, wary of any potential dangers that may be lurking in the shadows."
};

string[] strangeStatueText = new string[] {
    "While traveling, we come across a strange statue standing alone in a clearing.",
    "The statue is unlike anything we've ever seen, with intricate carvings and a mysterious aura.",
    "Approaching the statue, we feel a strange energy emanating from it, filling us with both awe and unease.",
    "We must decide whether to investigate the statue further or continue on our journey, unsure of its significance."
};

    string[] ancientScriptureText = new string[] {
    "During our travels, we discover a set of ancient scriptures hidden in a remote location.",
    "The scriptures contain cryptic messages and symbols, hinting at a lost civilization's history and knowledge.",
    "As we decipher the scriptures, we uncover clues that could lead us to hidden treasures or ancient artifacts.",
    "We are faced with a choice: to pursue the secrets hidden within the scriptures or to leave them behind and continue our journey."
};

    string[] spectralApparitionText = new string[] {
    "One night, we are visited by a spectral apparition, a ghostly figure that appears before us.",
    "The apparition seems to be trying to communicate with us, but its intentions are unclear.",
    "We are filled with a mixture of fear and curiosity, unsure of what the apparition wants from us.",
    "We must decide whether to interact with the apparition or to ignore its presence and hope it goes away."
};

string[] ancientObeliskText = new string[] {
    "While exploring, we come across an ancient obelisk towering above the landscape.",
    "The obelisk is covered in strange runes and symbols, hinting at its mystical purpose.",
    "Approaching the obelisk, we feel a surge of energy, as if it is reacting to our presence.",
    "We must decide whether to investigate the obelisk further or to continue our journey, wary of its unknown powers."
};

    string[] enchantedForestText = new string[] {
    "We enter an enchanted forest, where the trees seem to whisper ancient secrets.",
    "The forest is alive with magic, and we can feel its energy coursing through the air.",
    "As we journey deeper into the forest, we encounter mystical creatures and strange phenomena.",
    "We are filled with wonder and trepidation, unsure of what wonders or dangers lie ahead."
};

    string[] lostTreasureText = new string[] {
    "Rumors lead us to a fabled lost treasure hidden in a remote location.",
    "The treasure is said to be guarded by ancient traps and puzzles, challenging all who seek it.",
    "We are determined to uncover the treasure, risking life and limb for the chance at riches and glory.",
    "We must navigate the treacherous path to the treasure, using our wits and skills to overcome its obstacles."
};

string[] cosmicRevelationText = new string[] {
    "The celestial phenomenon reaches its peak, bathing the land in a brilliant light.",
    "As we watch in awe, the light forms a pathway in the sky, leading us to a new destination.",
    "We realize that the phenomenon was guiding us all along, showing us the way to our next adventure.",
    "Filled with determination, we follow the light, eager to uncover the mysteries that await us."
};

    string[] ancientConflictText = new string[] {
    "As we delve deeper into the temple, we uncover evidence of an ancient conflict that spans generations.",
    "The temple's walls tell the story of a war between two powerful civilizations, each vying for control of the land.",
    "We learn of the sacrifices made and the tragedies endured by those caught in the crossfire.",
    "The story serves as a warning, reminding us of the consequences of unchecked ambition and blind faith."
};

    string[] hiddenKnowledgeText = new string[] {
    "In the depths of the temple, we discover a chamber filled with ancient texts and scrolls.",
    "The texts contain hidden knowledge and wisdom, offering insights into the nature of the universe.",
    "As we study the texts, we gain new abilities and understanding, unlocking our true potential.",
    "Armed with this newfound knowledge, we are ready to face whatever challenges lie ahead."
};

string[] ancientCataclysmText = new string[] {
    "As we explore further, we uncover evidence of an ancient cataclysm that devastated the land.",
    "The temple's murals depict a great disaster that reshaped the landscape and wiped out civilizations.",
    "We learn of the survivors' struggle to rebuild and the lessons they learned from the cataclysm.",
    "The story serves as a reminder of the fragility of civilization and the importance of cooperation and understanding."
};

    string[] mysticalPortalText = new string[] {
    "At the heart of the temple, we discover a mystical portal that pulsates with otherworldly energy.",
    "The portal seems to lead to another realm, one filled with untold wonders and dangers.",
    "We are tempted to step through the portal and explore this new realm, but we are wary of what awaits us on the other side.",
    "We must decide whether to venture into the unknown or to stay and continue our journey in this realm."
};

    string[] ancientGuardianText = new string[] {
    "As we approach the treasure rumored to be guarded by traps, we encounter a mystical guardian.",
    "The guardian is a powerful being, its form shifting and changing with the surrounding magic.",
    "It seems to be protecting the treasure, testing our worthiness to claim it.",
    "We must defeat the guardian in a battle of wits and strength if we are to claim the treasure and continue our journey."
};

string[] ancientCurseText = new string[] {
    "Upon defeating the guardian, we trigger an ancient curse that befalls the land.",
    "The curse awakens long-dormant spirits and creatures, unleashing chaos and destruction.",
    "We must find a way to lift the curse and restore peace to the land, or risk being consumed by its malevolent power."
};

    string[] hiddenSanctuaryText = new string[] {
    "In our quest to lift the curse, we discover a hidden sanctuary hidden deep within the jungle.",
    "The sanctuary is a place of peace and tranquility, untouched by the chaos outside.",
    "Here, we find clues that lead us to the source of the curse, hidden in a place of great power.",
    "We must journey to this place and confront the source of the curse if we are to save the land."
};

    string[] ancestralSpiritText = new string[] {
    "As we journey to confront the source of the curse, we are visited by an ancestral spirit.",
    "The spirit is wise and powerful, offering us guidance and aid in our quest.",
    "With the spirit's help, we are able to navigate the treacherous path to the source of the curse.",
    "But the spirit warns us that the source is protected by powerful magic, and we must be prepared for a difficult battle."
};

string[] sourceOfCurseText = new string[] {
    "At the source of the curse, we discover a powerful artifact that is causing the chaos.",
    "The artifact is ancient and imbued with dark magic, amplifying the curse's effects.",
    "We must find a way to destroy the artifact and lift the curse, or risk the land being consumed by darkness forever."
};

    string[] finalConfrontationText = new string[] {
    "As we prepare to destroy the artifact, we are confronted by the one who created the curse.",
    "It is a powerful sorcerer who seeks to use the curse to gain ultimate power.",
    "We must defeat the sorcerer in a final battle to save the land and restore peace.",
    "The fate of the land rests in our hands, and we must not falter in our resolve."
};

    string[] restorationOfPeaceText = new string[] {
    "With the sorcerer defeated and the artifact destroyed, the curse is lifted from the land.",
    "The spirits and creatures return to their rest, and peace is restored once more.",
    "We are hailed as heroes, celebrated for our bravery and determination.",
    "But our journey is not over, for there are still many more adventures and challenges awaiting us."
};

    string[] leavingTheIslandText = new string[] {
    "Impressed by our skills and bravery, the Guardian fulfills his promise and helps us leave the island.",
    "As we sail away from the island, we look back one last time, grateful for the adventure and the lessons we've learned.",
    "Our journey may be over, but we know that more adventures await us in the future."
};

    public Dialogs()
    {
        InitializeDialogues();
    }

    private void InitializeDialogues()
    {
        Dialog initialDialogue = new Dialog("initial",
            new string[] {
    "Ricardo...",
    "Ricardo, wake up!",
    "Can you hear me amidst the crashing waves and the howling wind?",
    "It's time to rise, lad, time to shake off the grip of unconsciousness.",
    "Open your eyes to the chaos that surrounds us.",
    "For by some miracle, you've survived the fury of the sea.",
    "Come on lad, snap out of it!",
    "By the stars, you're alive!",
    "Listen to me now, we've been through a storm, a fierce one!",
    "Our ship... she didn't make it. We're stranded.",
    "The crew's scattered, supplies are scarce.",
    "But we're not done yet, Ricardo.",
    "We've faced worse odds before.",
    "Now tell me, lad, do you still have the spirit of the sea in you?",
    "Are you ready to fight for survival?"
},
            "Keep on!", "Give up", "Jacky",
            (m) =>
            {
                m.ChangeHealth(60);
                m.ChangeBullet(3);
                m.ChangeResource(20);
                m.ChangeMorale(15);
            },
            (m) => m.GameOver(),
            "black"
        );

        Dialog choseToLive = new Dialog("choseToLive",
            new string[] {
    "Thank the heavens, Ricardo, you've made the right choice.",
    "We'll make it through this, together.",
    "Now, let's gather what we can and prepare to face whatever lies ahead.",
    "The sea may have dealt us a heavy blow, but we're not beaten yet.",
    "Stay strong, lad. We'll find a way to survive.",
    "Here, there wasn't much on the ship, but I picked up some things for you.",
    "Now's the real question...",
    "Do you want to settle our asses next to the shore or deeper in the woods?",
    "The shore has a higher chance of surprising us with a tsunami...",
    "...but in the woods we can be attacked by animals!"
},
            "Shore!", "Uh, woods.", "Jacky",
            (m) =>
            {
                m.tsunamiChance = 0.05;
                m.isReadyForEvents = true;
                m.showHeartPanel();
            },
            (m) =>
            {
                m.animalAttackChance = 0.05;
                m.isReadyForEvents = true;
                m.showHeartPanel();
            },
            "image2"
        );

        Dialog choseToDie = new Dialog("choseToDie",
            new string[] {
    "Ricardo, there's no shame in accepting fate as it comes.",
    "The sea has spoken, and perhaps this is where our journey ends.",
    "We've braved the tempests, sailed through storms, but now...",
    "Now it seems the sea calls us home.",
    "Let us embrace the depths together, as men of the sea.",
    "May our souls find peace in the eternal embrace of the ocean."
},
            "Accept Fate", "Die in Rage", "Jacky",
            (m) => m.resetGame(), (m) => m.resetGame(),
            "gameOver", "nativeSprite"
        );

        Dialog choseToLiveSettleShore = new Dialog("choseToLiveShore",
    new string[] {
        "Shore!",
        "A wise choice, Ricardo. The shore offers its own challenges, but also opportunities.",
        "We'll need to fortify our position and keep watch for any signs of danger.",
        "With luck, we might find provisions washed ashore or a path leading inland.",
        "Let's make haste and establish our camp before nightfall.",
        "We'll build our shelter, gather driftwood for a fire, and assess our resources.",
        "Stay vigilant, lad. Our survival depends on it."
    },
    "Build Camp", "Explore Inland", "Jacky",
    null, null,
    "image_shore"
);

        Dialog choseToLiveSettleWoods = new Dialog("choseToLiveWoods",
            new string[] {
        "Uh, woods.",
        "Venturing into the woods, Ricardo? Bold choice, my friend.",
        "The forest offers shelter, but also hides many dangers.",
        "We'll need to tread carefully, watch for predators and poisonous plants.",
        "But perhaps, amidst the trees, we'll find food and fresh water.",
        "Let's gather our courage and venture forth into the unknown.",
        "Keep your wits about you, lad. We're in for a wild ride."
            },
            "Let's Go", "Change Mind", "Jacky",
            null, null,
            "image_woods"
        );


        Dialog choseToLiveSettleShore_BuildCamp = new Dialog("choseToLiveShore_BuildCamp",
    new string[] {
        "Let's build our camp here, by the shore.",
        "We'll need to gather driftwood and branches for our shelter.",
        "Keep an eye out for any washed-up supplies or debris we can use.",
        "Excellent work, lad! Our camp is taking shape.",
        "Now, let's reinforce it and gather some food before nightfall.",
        "With our camp secure, we can focus on finding a way off this island."
    },
    "Reinforce Camp", "Gather Food", "Jacky",
    null, null,
    "image_settle_shore"
);

        Dialog choseToLiveSettleShore_ExploreInland = new Dialog("choseToLiveShore_ExploreInland",
            new string[] {
        "Let's venture inland and see what lies beyond the shore.",
        "Keep your eyes peeled for any signs of civilization or resources.",
        "Look, Ricardo! Do you see that? Smoke rising in the distance.",
        "We might find help or supplies there. Let's investigate.",
        "Approach cautiously, lad. We don't know who or what awaits us.",
        "Well done, Ricardo! We've discovered a group of people.",
        "Together, we stand a better chance of survival on this island."
            },
            "Approach People", "Go to Shore", "Jacky",
            null, null,
            "image_woods_smoke"
        );

        Dialog encounterNativeDialogue = new Dialog("encounterNative",
    new string[] {
        "Ricardo, look! A native of this island.",
        "They seem startled but not hostile.",
        "What should we do, Ricardo? Shall we approach them?",
        "Wait, Jacky! This native might pose a threat to us.",
        "We can't take any chances. Should we eliminate them?",
        "Hold on, lad. Let's not rush into anything.",
        "We could try to communicate, offer peace instead of violence.",
        "It's a risk, Ricardo, but perhaps one worth taking.",
        "The decision is yours, Ricardo. What do you choose?"
    },
    "Eliminate Threat", "Run Home", "Jacky",
    null, null,
    "image_native_encounter"
);

        Dialog nativeBeggingForLifeDialogue = new Dialog("nativeBeggingForLife",
    new string[] {
        "Please, spare me! I mean you no harm.",
        "I am but a humble native of this land, trying to survive.",
        "I beg of you, have mercy! I have a family, loved ones who depend on me.",
        "I will do anything, anything to prove my peaceful intentions.",
        "Please, do not condemn me to death. Spare my life, and I will forever be in your debt."
    },
    "Spare Him", "Eliminate Threat", "Native",
    null, null,
    "image_native_begging", "nativeSprite"
);

        Dialog killedNativeDialog = new Dialog("killedNative",
    new string[] {
        "It's done. The native is no more.",
        "A regrettable choice, but necessary for our survival.",
        "Let's leave this place behind us, Ricardo. There's nothing more for us here.",
        "We'll head to the shore and build our camp there.",
        "It's a safer location, away from potential threats and closer to resources.",
        "With luck, we'll find a way off this island and leave these dark days behind us."
    },
    "Agree", "Disagree", "Jacky",
    null, null,
    "image_dead_native", "pirateSprite"
);


        Dialog sparedNativeDialogue = new Dialog("sparedNative",
    new string[] {
        "Foolish decision, Ricardo. This native will not hesitate to betray us.",
        "It's too late, Jacky. We've made our choice. Let's hope it's the right one.",
        "Ricardo, look out! The native has a weapon!",
        "No! Ricardo!",
        "I told you, Ricardo. We should have eliminated the threat when we had the chance.",
        "It's over, Jacky. Our journey ends here..."
    }, "Fuck!", "Shit!", "Jacky",
    (m) => m.GameOver(), (m) => m.GameOver(),
    "image_native_attack", "nativeSprite"
);

        Dialog findMysteriousArtifactDialog = new Dialog("findMysteriousArtifact",
    findMysteriousArtifactText,
    "Investigate Further", "Leave It Be", "Jacky",
    (m) => Debug.Log("Investigating further..."),
    (m) => Debug.Log("Leaving it be..."),
    "image_mysterious_artifact"
);

        Dialog encounterHostileWildlifeDialog = new Dialog("encounterHostileWildlife",
            encounterHostileWildlifeText,
            "Defend Ourselves", "Find Escape Route", "Jacky",
            (m) => Debug.Log("Defending ourselves..."),
            (m) => Debug.Log("Finding escape route..."),
            "image_hostile_wildlife"
        );

        Dialog discoverAncientRuinDialog = new Dialog("discoverAncientRuin",
            discoverAncientRuinText,
            "Explore Further", "Leave It Be", "Jacky",
            (m) => Debug.Log("Exploring further..."),
            (m) => Debug.Log("Leaving it be..."),
            "image_ancient_ruin"
        );

        Dialog mysteriousFogDialog = new Dialog("mysteriousFog",
            mysteriousFogText,
            "Navigate Carefully", "Wait It Out", "Jacky",
            (m) => Debug.Log("Navigating carefully..."),
            (m) => Debug.Log("Waiting it out..."),
            "image_mysterious_fog"
        );

        Dialog encounterMysteriousStrangerDialog = new Dialog("encounterMysteriousStranger",
            encounterMysteriousStrangerText,
            "Accept Offer", "Decline Offer", "Jacky",
            (m) => Debug.Log("Accepting offer..."),
            (m) => Debug.Log("Declining offer..."),
            "image_mysterious_stranger"
        );

        Dialog findHiddenCaveDialog = new Dialog("findHiddenCave",
            findHiddenCaveText,
            "Explore Deeper", "Return Later", "Jacky",
            (m) => Debug.Log("Exploring deeper..."),
            (m) => Debug.Log("Returning later..."),
            "image_hidden_cave"
        );

        Dialog strangeStatueDialog = new Dialog("strangeStatue",
            strangeStatueText,
            "Investigate Further", "Ignore It", "Jacky",
            (m) => Debug.Log("Investigating further..."),
            (m) => Debug.Log("Ignoring it..."),
            "image_strange_statue"
        );

        Dialog ancientScriptureDialog = new Dialog("ancientScripture",
            ancientScriptureText,
            "Decipher Scriptures", "Leave Them", "Jacky",
            (m) => Debug.Log("Deciphering scriptures..."),
            (m) => Debug.Log("Leaving them..."),
            "image_ancient_scripture"
        );

        Dialog spectralApparitionDialog = new Dialog("spectralApparition",
            spectralApparitionText,
            "Interact with Apparition", "Ignore It", "Jacky",
            (m) => Debug.Log("Interacting with apparition..."),
            (m) => Debug.Log("Ignoring it..."),
            "image_spectral_apparition"
        );

        Dialog ancientObeliskDialog = new Dialog("ancientObelisk",
            ancientObeliskText,
            "Investigate Further", "Move On", "Jacky",
            (m) => Debug.Log("Investigating further..."),
            (m) => Debug.Log("Moving on..."),
            "image_ancient_obelisk"
        );

        Dialog enchantedForestDialog = new Dialog("enchantedForest",
            enchantedForestText,
            "Explore Deeper", "Leave It Be", "Jacky",
            (m) => Debug.Log("Exploring deeper..."),
            (m) => Debug.Log("Leaving it be..."),
            "image_enchanted_forest"
        );

        Dialog lostTreasureDialog = new Dialog("lostTreasure",
            lostTreasureText,
            "Search for Treasure", "Move On", "Jacky",
            (m) => Debug.Log("Searching for treasure..."),
            (m) => Debug.Log("Moving on..."),
            "image_lost_treasure"
        );

        Dialog cosmicRevelationDialog = new Dialog("cosmicRevelation",
            cosmicRevelationText,
            "Embrace Revelation", "Question Its Origin", "Jacky",
            (m) => Debug.Log("Embracing revelation..."),
            (m) => Debug.Log("Questioning its origin..."),
            "image_cosmic_revelation"
        );

        Dialog ancientConflictDialog = new Dialog("ancientConflict",
            ancientConflictText,
            "Learn from History", "Repeat the Past", "Jacky",
            (m) => Debug.Log("Learning from history..."),
            (m) => Debug.Log("Repeating the past..."),
            "image_ancient_conflict"
        );

        Dialog hiddenKnowledgeDialog = new Dialog("hiddenKnowledge",
            hiddenKnowledgeText,
            "Seek Wisdom", "Remain Ignorant", "Jacky",
            (m) => Debug.Log("Seeking wisdom..."),
            (m) => Debug.Log("Remaining ignorant..."),
            "image_hidden_knowledge"
        );

        Dialog ancientCataclysmDialog = new Dialog("ancientCataclysm",
            ancientCataclysmText,
            "Prevent Catastrophe", "Embrace Destruction", "Jacky",
            (m) => Debug.Log("Preventing catastrophe..."),
            (m) => Debug.Log("Embracing destruction..."),
            "image_ancient_cataclysm"
        );

        Dialog mysticalPortalDialog = new Dialog("mysticalPortal",
            mysticalPortalText,
            "Step Into the Unknown", "Stay in the Familiar", "Jacky",
            (m) => Debug.Log("Stepping into the unknown..."),
            (m) => Debug.Log("Staying in the familiar..."),
            "image_mystical_portal"
        );

        Dialog ancientGuardianDialog = new Dialog("ancientGuardian",
            ancientGuardianText,
            "Face the Guardian", "Bypass It", "Jacky",
            (m) => Debug.Log("Facing the guardian..."),
            (m) => Debug.Log("Bypassing it..."),
            "image_ancient_guardian"
        );

        Dialog ancientCurseDialog = new Dialog("ancientCurse",
            ancientCurseText,
            "Break the Curse", "Accept Its Fate", "Jacky",
            (m) => Debug.Log("Breaking the curse..."),
            (m) => Debug.Log("Accepting its fate..."),
            "image_ancient_curse"
        );

        Dialog hiddenSanctuaryDialog = new Dialog("hiddenSanctuary",
            hiddenSanctuaryText,
            "Discover Sanctuary", "Ignore Its Existence", "Jacky",
            (m) => Debug.Log("Discovering sanctuary..."),
            (m) => Debug.Log("Ignoring its existence..."),
            "image_hidden_sanctuary"
        );

        Dialog ancestralSpiritDialog = new Dialog("ancestralSpirit",
            ancestralSpiritText,
            "Accept Guidance", "Reject Help", "Jacky",
            (m) => Debug.Log("Accepting guidance..."),
            (m) => Debug.Log("Rejecting help..."),
            "image_spectral_apparition"
        );

        Dialog sourceOfCurseDialog = new Dialog("sourceOfCurse",
            sourceOfCurseText,
            "Destroy Artifact", "Harness Its Power", "Jacky",
            (m) => Debug.Log("Destroying artifact..."),
            (m) => Debug.Log("Harnessing its power..."),
            "image_ancient_curse"
        );

        Dialog finalConfrontationDialog = new Dialog("finalConfrontation",
            finalConfrontationText,
            "Defeat the Sorcerer", "Spare Their Life", "Jacky",
            (m) => Debug.Log("Defeating the sorcerer..."),
            (m) => Debug.Log("Sparing their life..."),
            "image_ancient_conflict"
        );

        Dialog restorationOfPeaceDialog = new Dialog("restorationOfPeace",
            restorationOfPeaceText,
            "Celebrate Victory", "Prepare for New Challenges", "Jacky",
            (m) => m.GameOver(),
            (m) => m.GameOver(),
            "image_restoration_of_peace"
        );

        Dialog leavingTheIslandDialog = new Dialog("leavingTheIsland",
            leavingTheIslandText,
            "Leave the Island", "Stay on the Island", "Jacky",
            (m) => m.resetGame(),
            (m) => m.resetGame(),
            "image_leaving_the_island"
        );



        initialDialog = initialDialogue;

        initialDialogue.NextDialogueOne = choseToLive;
        initialDialogue.NextDialogueTwo = choseToDie;

        choseToLive.NextDialogueOne = choseToLiveSettleShore;
        choseToLive.NextDialogueTwo = choseToLiveSettleWoods;

        choseToLiveSettleShore.NextDialogueOne = choseToLiveSettleShore_BuildCamp;
        choseToLiveSettleShore.NextDialogueTwo = choseToLiveSettleShore_ExploreInland;

        choseToLiveSettleWoods.NextDialogueOne = choseToLiveSettleShore_ExploreInland;
        choseToLiveSettleWoods.NextDialogueTwo = choseToLiveSettleShore_BuildCamp;

        choseToLiveSettleShore_ExploreInland.NextDialogueOne = encounterNativeDialogue;
        choseToLiveSettleShore_ExploreInland.NextDialogueTwo = choseToLiveSettleShore_BuildCamp;

        encounterNativeDialogue.NextDialogueOne = nativeBeggingForLifeDialogue;
        encounterNativeDialogue.NextDialogueTwo = choseToLiveSettleShore_BuildCamp;

        nativeBeggingForLifeDialogue.NextDialogueOne = sparedNativeDialogue;
        nativeBeggingForLifeDialogue.NextDialogueTwo = killedNativeDialog;

        killedNativeDialog.NextDialogueOne = choseToLiveSettleShore_BuildCamp;
        killedNativeDialog.NextDialogueTwo = choseToLiveSettleShore_BuildCamp;

        sparedNativeDialogue.NextDialogueTwo = choseToDie;
        sparedNativeDialogue.NextDialogueOne = choseToDie;

        choseToLiveSettleShore_BuildCamp.NextDialogueOne = findMysteriousArtifactDialog;
        choseToLiveSettleShore_BuildCamp.NextDialogueTwo = findMysteriousArtifactDialog;


        // Connecting findMysteriousArtifactDialog to encounterHostileWildlifeDialog
        findMysteriousArtifactDialog.NextDialogueOne = encounterHostileWildlifeDialog;
        findMysteriousArtifactDialog.NextDialogueTwo = encounterHostileWildlifeDialog;

        // Connecting encounterHostileWildlifeDialog to discoverAncientRuinDialog
        encounterHostileWildlifeDialog.NextDialogueOne = discoverAncientRuinDialog;
        encounterHostileWildlifeDialog.NextDialogueTwo = discoverAncientRuinDialog;

        // Connecting discoverAncientRuinDialog to mysteriousFogDialog
        discoverAncientRuinDialog.NextDialogueOne = mysteriousFogDialog;
        discoverAncientRuinDialog.NextDialogueTwo = mysteriousFogDialog;

        // Connecting mysteriousFogDialog to encounterMysteriousStrangerDialog
        mysteriousFogDialog.NextDialogueOne = encounterMysteriousStrangerDialog;
        mysteriousFogDialog.NextDialogueTwo = encounterMysteriousStrangerDialog;

        // Connecting encounterMysteriousStrangerDialog to findHiddenCaveDialog
        encounterMysteriousStrangerDialog.NextDialogueOne = findHiddenCaveDialog;
        encounterMysteriousStrangerDialog.NextDialogueTwo = findHiddenCaveDialog;

        // Connecting findHiddenCaveDialog to strangeStatueDialog
        findHiddenCaveDialog.NextDialogueOne = strangeStatueDialog;
        findHiddenCaveDialog.NextDialogueTwo = strangeStatueDialog;

        // Connecting strangeStatueDialog to ancientScriptureDialog
        strangeStatueDialog.NextDialogueOne = ancientScriptureDialog;
        strangeStatueDialog.NextDialogueTwo = ancientScriptureDialog;

        // Connecting ancientScriptureDialog to spectralApparitionDialog
        ancientScriptureDialog.NextDialogueOne = spectralApparitionDialog;
        ancientScriptureDialog.NextDialogueTwo = spectralApparitionDialog;

        // Connecting spectralApparitionDialog to ancientObeliskDialog
        spectralApparitionDialog.NextDialogueOne = ancientObeliskDialog;
        spectralApparitionDialog.NextDialogueTwo = ancientObeliskDialog;

        // Connecting ancientObeliskDialog to enchantedForestDialog
        ancientObeliskDialog.NextDialogueOne = enchantedForestDialog;
        ancientObeliskDialog.NextDialogueTwo = enchantedForestDialog;

        // Connecting enchantedForestDialog to lostTreasureDialog
        enchantedForestDialog.NextDialogueOne = lostTreasureDialog;
        enchantedForestDialog.NextDialogueTwo = lostTreasureDialog;

        // Connecting lostTreasureDialog to cosmicRevelationDialog
        lostTreasureDialog.NextDialogueOne = cosmicRevelationDialog;
        lostTreasureDialog.NextDialogueTwo = cosmicRevelationDialog;

        // Connecting cosmicRevelationDialog to ancientConflictDialog
        cosmicRevelationDialog.NextDialogueOne = ancientConflictDialog;
        cosmicRevelationDialog.NextDialogueTwo = ancientConflictDialog;

        // Connecting ancientConflictDialog to hiddenKnowledgeDialog
        ancientConflictDialog.NextDialogueOne = hiddenKnowledgeDialog;
        ancientConflictDialog.NextDialogueTwo = hiddenKnowledgeDialog;

        // Connecting hiddenKnowledgeDialog to ancientCataclysmDialog
        hiddenKnowledgeDialog.NextDialogueOne = ancientCataclysmDialog;
        hiddenKnowledgeDialog.NextDialogueTwo = ancientCataclysmDialog;

        // Connecting ancientCataclysmDialog to mysticalPortalDialog
        ancientCataclysmDialog.NextDialogueOne = mysticalPortalDialog;
        ancientCataclysmDialog.NextDialogueTwo = mysticalPortalDialog;

        // Connecting mysticalPortalDialog to ancientGuardianDialog
        mysticalPortalDialog.NextDialogueOne = ancientGuardianDialog;
        mysticalPortalDialog.NextDialogueTwo = ancientGuardianDialog;

        // Connecting ancientGuardianDialog to ancientCurseDialog
        ancientGuardianDialog.NextDialogueOne = ancientCurseDialog;
        ancientGuardianDialog.NextDialogueTwo = ancientCurseDialog;

        // Connecting ancientCurseDialog to hiddenSanctuaryDialog
        ancientCurseDialog.NextDialogueOne = hiddenSanctuaryDialog;
        ancientCurseDialog.NextDialogueTwo = hiddenSanctuaryDialog;

        // Connecting hiddenSanctuaryDialog to ancestralSpiritDialog
        hiddenSanctuaryDialog.NextDialogueOne = ancestralSpiritDialog;
        hiddenSanctuaryDialog.NextDialogueTwo = ancestralSpiritDialog;

        // Connecting ancestralSpiritDialog to sourceOfCurseDialog
        ancestralSpiritDialog.NextDialogueOne = sourceOfCurseDialog;
        ancestralSpiritDialog.NextDialogueTwo = sourceOfCurseDialog;

        // Connecting sourceOfCurseDialog to finalConfrontationDialog
        sourceOfCurseDialog.NextDialogueOne = finalConfrontationDialog;
        sourceOfCurseDialog.NextDialogueTwo = finalConfrontationDialog;

        // Connecting finalConfrontationDialog to restorationOfPeaceDialog
        finalConfrontationDialog.NextDialogueOne = restorationOfPeaceDialog;
        finalConfrontationDialog.NextDialogueTwo = restorationOfPeaceDialog;

        // Connecting restorationOfPeaceDialog to newBeginningsDialog
        restorationOfPeaceDialog.NextDialogueOne = leavingTheIslandDialog;
        restorationOfPeaceDialog.NextDialogueTwo = leavingTheIslandDialog;
 


        CurrentDialogue = initialDialogue;

        dialogues.Add("initial", initialDialogue);
        dialogues.Add("choseToLive", choseToLive);
        dialogues.Add("choseToLiveShore", choseToLiveSettleShore);
        dialogues.Add("choseToLiveWoods", choseToLiveSettleWoods);
        dialogues.Add("choseToLiveShore_BuildCamp", choseToLiveSettleShore_BuildCamp);
        dialogues.Add("choseToLiveShore_ExploreInland", choseToLiveSettleShore_ExploreInland);
        dialogues.Add("encounterNative", encounterNativeDialogue);
        dialogues.Add("nativeBeggingForLife", nativeBeggingForLifeDialogue);
        dialogues.Add("killedNative", killedNativeDialog);
        dialogues.Add("sparedNative", sparedNativeDialogue);
        dialogues.Add("findMysteriousArtifact", findMysteriousArtifactDialog);
        dialogues.Add("encounterHostileWildlife", encounterHostileWildlifeDialog);
        dialogues.Add("discoverAncientRuin", discoverAncientRuinDialog);
        dialogues.Add("mysteriousFog", mysteriousFogDialog);
        dialogues.Add("encounterMysteriousStranger", encounterMysteriousStrangerDialog);
        dialogues.Add("findHiddenCave", findHiddenCaveDialog);
        dialogues.Add("strangeStatue", strangeStatueDialog);
        dialogues.Add("ancientScripture", ancientScriptureDialog);
        dialogues.Add("spectralApparition", spectralApparitionDialog);
        dialogues.Add("ancientObelisk", ancientObeliskDialog);
        dialogues.Add("enchantedForest", enchantedForestDialog);
        dialogues.Add("lostTreasure", lostTreasureDialog);
        dialogues.Add("cosmicRevelation", cosmicRevelationDialog);
        dialogues.Add("ancientConflict", ancientConflictDialog);
        dialogues.Add("hiddenKnowledge", hiddenKnowledgeDialog);
        dialogues.Add("ancientCataclysm", ancientCataclysmDialog);
        dialogues.Add("mysticalPortal", mysticalPortalDialog);
        dialogues.Add("ancientGuardian", ancientGuardianDialog);
        dialogues.Add("ancientCurse", ancientCurseDialog);
        dialogues.Add("hiddenSanctuary", hiddenSanctuaryDialog);
        dialogues.Add("ancestralSpirit", ancestralSpiritDialog);
        dialogues.Add("sourceOfCurse", sourceOfCurseDialog);
        dialogues.Add("finalConfrontation", finalConfrontationDialog);
        dialogues.Add("restorationOfPeace", restorationOfPeaceDialog);
        dialogues.Add("leavingTheIsland", leavingTheIslandDialog);
    }


    public Dialog GetNextOne(string dialogName = null)
    {
        if (dialogName != null)
        {
            Dialog dialog;
            if (dialogues.TryGetValue(dialogName, out dialog))
            {
                CurrentDialogue = dialog;
                return dialog;
            }
        } else
        {
            CurrentDialogue = CurrentDialogue.NextDialogueOne;
            return CurrentDialogue;
        }

        return CurrentDialogue;
    }

    public Dialog GetNextTwo()
    {
        CurrentDialogue = CurrentDialogue.NextDialogueTwo;
        return CurrentDialogue;
    }

    public Dialog GetFirst()
    {
        return initialDialog;
    }
}