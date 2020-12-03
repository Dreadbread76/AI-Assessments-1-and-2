using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : NPC
{
    protected QuestManager questManager;

    [SerializeField] protected Quest NPCsQuest;

    [SerializeField] QuestDialogue dialogue;

    [SerializeField] protected string[] dialogueText;
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        
        if(questManager == null)
        {
            Debug.LogError("There is no questManager only Zuul");
        }
        if(dialogue == null)
        {
            //Debug.LogError("Dont forget to include quest dialog");
        }


    }
    public override void Interact()
    {

        switch (NPCsQuest.goal.questState)
        {
            case QuestState.Available:
                questManager.AcceptQuest(NPCsQuest);
                dialogue.currentDialogue = dialogueText;
                dialogue.quest = NPCsQuest;
                dialogue.showDialogue = true;
                break;

            case QuestState.Active:
               if(NPCsQuest.goal.isCompleted())
               {
                    questManager.ClaimQuest();
                    Debug.Log("Accepted");

                }
                break;
            case QuestState.Claimed:

                Debug.Log("Claimed");

                //dialogue
                break;
        }
        if(NPCsQuest.goal.questState == QuestState.Available)
        {
            questManager.AcceptQuest(NPCsQuest);
            Debug.Log("Quest giver NPC");
        }
       
    }
}
