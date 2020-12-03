using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//this script can be found in the Component section under the option Intro RPG/Player/Interact
[AddComponentMenu("Intro PRG/RPG/Player/Interact")]
public class Interact : MonoBehaviour
{
    #region Variables
    public Stats.BaseStats player;
    public CanvasDialogue dlgMaster;
    public LinearInventory linearInventory;

    public GameObject dialoguePanel;
    public Text dialogueText;
    public Text buttonText;
    public Text nameText;
    public Button acceptButton;
    public Text acceptButtonText;
    public string charNPCName;
    Dialogue newNPC;
    Shop newShop;

    public string[] currentDialogue;
    public string[] posDialogue, neuDialogue, negDialogue;
    public Text posButtonText, neuButtonText, negDialogueText;
    public Button posButton, neuButton, negButton;


    public int dialogueIndex;
    public int approvedIndex;
   

    public MouseLook playerMouseLook;
    
    #endregion
    #region Start
 
    #endregion
    #region Update  

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("KeyPressed");
            Ray interact;
            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hitInfo;
            if (Physics.Raycast(interact, out hitInfo, 10))
            {
                #region NPC tag
                //and that hits info is tagged NPC
                //Debug that we hit a NPC             
                
                if (hitInfo.collider.CompareTag("NPC"))
                {
                    
                    Debug.Log("Talk to the NPC");
                    newNPC = hitInfo.transform.GetComponent<Dialogue>();
                    newShop = hitInfo.transform.GetComponent<Shop>();
                    OpenDialogue();
                    
                    
                }
                #endregion
                #region Item
                if (hitInfo.collider.CompareTag("Item"))
                {
                    Debug.Log("Pick Up Item");
                    ItemHandler handler = hitInfo.transform.GetComponent<ItemHandler>();
                    if(handler != null)
                    {
                        player.quest.goal.ItemCollected(handler.itemId);
                        handler.OnCollection();
                    }
                }
                #endregion
                #region Chest
                if (hitInfo.collider.CompareTag("Chest"))
                {
                    Chest chest = hitInfo.transform.GetComponent<Chest>();
                    if(chest != null)
                    {
                        chest.showChestInv = true;
                        LinearInventory.showInv = true;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        Time.timeScale = 0;
                        LinearInventory.currentChest = chest;
                    }
                }
                #endregion
                //and that hits info is tagged Item
                //Debug that we hit an Item               
                
            }
        }
    }


    public void OpenDialogue()
    {
        dialoguePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        charNPCName = newNPC.name;
        nameText.text = charNPCName;
        dialogueText.text = newNPC.currentDialogue[dialogueIndex];
        

    }



    public void DialogueScroll()
    {

        

        if (!(dialogueIndex >= newNPC.currentDialogue.Length - 1 ))
        {
            dialogueIndex++;

            if (dialogueIndex >= newNPC.currentDialogue.Length - 1)
            {
                if(newNPC.npcType == Dialogue.NPCType.Villager)
                {
                    if(!(posDialogue.Length <=0 && neuDialogue.Length <= 0 && negDialogue.Length <= 0))
                    {
                        posButton.gameObject.SetActive(true);
                        neuButton.gameObject.SetActive(true);
                        negButton.gameObject.SetActive(true);
                    }

                    buttonText.text = "Leave";
                }
                else if (newNPC.npcType == Dialogue.NPCType.Quest)
                {
                   
                    acceptButton.gameObject.SetActive(true);
                    acceptButtonText.text = "OK";
                    buttonText.text = "Ignore";
                }
                else if (newNPC.npcType == Dialogue.NPCType.Shop)
                {
                   
                    acceptButton.gameObject.SetActive(true);
                    acceptButtonText.text = "Shop";
                    buttonText.text = "Leave";
                }

            }
        }
        else
        {
            buttonText.text = "Next";
            Time.timeScale = 1;
            dialogueIndex = 0;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            acceptButton.gameObject.SetActive(false);
            dialoguePanel.SetActive(false);

        }
        dialogueText.text = newNPC.currentDialogue[dialogueIndex];
    }

    public void Approval(int approval)
    {
        if (approval >= 2)
        {
            dialogueIndex = 0;
            dialogueText.text = newNPC.posDialogue[dialogueIndex];
        }
        if (approval == 1)
        {
            dialogueIndex = 0;
            dialogueText.text = newNPC.neuDialogue[dialogueIndex];
        }
        if (approval <= 0)
        {
            dialogueIndex = 0;
            dialogueText.text = newNPC.negDialogue[dialogueIndex];
        }
    }
   
    
    #endregion
}






