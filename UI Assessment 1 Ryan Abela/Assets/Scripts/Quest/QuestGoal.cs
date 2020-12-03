using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //public string enemyType;
   
    public enum GoalType
    {
        //Kill,
        Gather
    }
   public enum QuestState
    {
        Available,
        Active,
        Claimed,
    }
    
   /* public bool IsReached()
    {
        return (currentAmount >= requiredAmount);

    }
    public void EnemyKilled(string type)
    {
        if(goalType == GoalType.Kill && type == enemyType)
        {
            isReached = true;
            questState = QuestState.Complete;
            Debug.Log("Quest Complete");
        }
        
    }*/
   

[System.Serializable]
public abstract class QuestGoal : MonoBehaviour
{
    
    public QuestState questState;

    public GoalType goalType;

    public string itemName;
    public int requiredAmount;
    public int currentAmount;

    public int itemID;

    public Item itemCollected;

    ItemHandler invHandler;

    public abstract bool isCompleted();

    public void ItemCollected(int id)
    {
        if (goalType == GoalType.Gather && id == itemID)
        {
           // isReached = true;
            
            currentAmount++;
            if(currentAmount >= requiredAmount)
            {
                 
                Debug.Log("QUSET COMPLETED");
            }
        }

    }
    
}

