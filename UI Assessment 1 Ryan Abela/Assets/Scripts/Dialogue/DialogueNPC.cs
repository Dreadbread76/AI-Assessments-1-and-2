using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : NPC
{
    [SerializeField]
    public Dialogue dialogue;
    public override void Interact()
    {
        Debug.Log("Dialogue NPC");
        dialogue.showDialogue = true;

        dialogue.name = name;
        //dialogue.dialogueText[] = dialogueText[];
    }
}
