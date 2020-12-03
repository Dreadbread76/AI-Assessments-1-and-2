using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public Text buttonText;
    public Text charNPCName;

    public string[] currentDialogue;
    public int dialogueIndex;
    public MouseLook playerMouseLook;

    public void OpenDialogue()
    {
        dialoguePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }
   

   
    public void DialogueScroll()
    {
        


        if (!(dialogueIndex >= currentDialogue.Length - 1))
        {
            dialogueIndex++;
            if(dialogueIndex >= currentDialogue.Length - 1)
            {
                buttonText.text = "Bye.";
            }
        }
        else
        {
            Time.timeScale = 0;
            dialogueIndex = 0;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            dialoguePanel.SetActive(false);
            
        }
        dialogueText.text = charNPCName + ": " + currentDialogue[dialogueIndex];
    }


}
