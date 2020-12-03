using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GatherQuestGoal : QuestGoal
{

    #region Gather Variables

    private LinearInventory inventory;

    public string itemName;
    public int requiredAmount;
    public int currentAmount;

    #endregion
    private void Start()
    {
        inventory = (LinearInventory)GameObject.FindObjectOfType<LinearInventory>();
        if (inventory == null)
        {
     
            Debug.LogError("There is no player with an inventory");
        }

    }
   
    public override bool isCompleted()
    {
      /*  if(CheckPlayerInventory() == false)
        {
            return false;
        }
        */
        Item item = inventory.FindItem(itemName);

        if(item == null)
        {
            return false;
        }

        if (item.Amount >= requiredAmount)
        {
            return true;
        }
        return false;
    }
}
