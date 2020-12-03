using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialogue : Dialogue
{
    public QuestManager questManager;


   /* protected override void EndDialogue()
    {
        if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Accept"))
        {
            Debug.Log("Accept quest here");



            showDialogue = false;
            currentLineIndex = 0;

            playerMouseLook.enabled = true;
            playerScript.enabled = true;
        }
    }

    */
}
