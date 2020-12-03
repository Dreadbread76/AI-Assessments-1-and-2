using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionLinearDialogue : MonoBehaviour
{
    #region Variables
    [Header("References")]
    //boolean to toggle if we can see a characters dialogue box
    public bool showDlg;
    //index for our current line of dialogue and an index for a set question marker of the dialogue 
    public int index, optionIndex;
    public Vector2 scr;
    //object reference to the player
    public MouseLook playerMouseLook;
    //mouselook script reference for the maincamera
    [Header("NPC Name and Dialogue")]
    //name of this specific NPC
    public new string name;
    //array for text for our dialogue
    public string[] dialogueText;
    #endregion
    private void Start()
    {
        playerMouseLook = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>();
    }
    private void OnGUI()
    {
        if(showDlg)
        {
            //set up our ratio messurements for 16:9
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;

            //the dialogue box takes up the whole bottom 3rd of the screen and displays the NPC's name and current dialogue line
            GUI.Box(new Rect(0,6*scr.y,Screen.width,3*scr.y), name + " : " + dialogueText[index]);

            //if not at the end of the dialogue or not at the options index
            if (!(index >= dialogueText.Length - 1 || index == optionIndex))
            {
                //Next button allows us to skip forward to the next line of dialogue
                if (GUI.Button(new Rect(15 * scr.x, 8.5f*scr.y,scr.x,0.5f*scr.y),"Next"))
                {
                    //move forward in our dialouge array
                    index++;
                }
            }
            //else if we are at options
            else if (index == optionIndex)
            {
                //Accept button allows us to skip forward to the next line of dialogue
                if (GUI.Button(new Rect(14 * scr.x, 8.5f * scr.y, scr.x*2, 0.5f * scr.y), "Accept"))
                {
                    //move forward in our dialouge array
                    index++;
                }
                //Decline button skips us to the end of the characters dialogue 
                if (GUI.Button(new Rect(12 * scr.x, 8.5f * scr.y, scr.x*2, 0.5f * scr.y), "Decline"))
                {
                    //skip to end of dlg;
                    index = dialogueText.Length - 1;
                }
            }
            //else we are at the end
            else
            {
                if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Bye"))
                {
                    //close the dialogue box
                    showDlg = false;
                    //set index back to 0 
                    index = 0;
                    //allow cameras mouselook to be turned back on
                    //get the component mouselook on the character and turn that back on
                    Camera.main.GetComponent<MouseLook>().enabled = true;
                    //get the component movement on the character and turn that back on
                    playerMouseLook.enabled = true;

                    //lock the mouse cursor
                    Cursor.lockState = CursorLockMode.Locked;
                    //set the cursor to being invisible       
                    Cursor.visible = false;
                }
            }
        }
    }
}
