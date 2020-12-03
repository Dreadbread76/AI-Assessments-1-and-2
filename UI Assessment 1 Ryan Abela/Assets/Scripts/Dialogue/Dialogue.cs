using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//this script can be found in the Component section under the option NPC/Dialogue
[AddComponentMenu("Game Systems/RPG/NPC/Dialogue Linear")]

public class Dialogue : MonoBehaviour
{
    #region Variables
    [Header("References")]
    //boolean to toggle if we can see a characters dialogue box
    public bool showDialogue;
    //index for our current line of dialogue and an index for a set question marker of the dialogue 
    public int currentLineIndex;
    public PLAYER playerScript;
    public Vector2 scr;
    //object reference to the player
    public MouseLook playerMouseLook;
    //mouselook script reference for the maincamera
    public Quest quest;
    [Header("NPC Name and Dialogue")]
    //name of this specific NPC
    public new string name;
    public enum NPCType
    {
        Quest,
        Shop,
        Villager,
    }
    public NPCType npcType;
    //array for text for our dialogue
    public string[] currentDialogue;
    public string[] posDialogue, neuDialogue, negDialogue;
    public Text speechText;
    public Text nameText;
    public Text continueText;
    public GameObject dialogueBox;

   
    #endregion
    #region Start
   private void Start()
   {
        playerMouseLook = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>();
        
   }
    #endregion

  
}
