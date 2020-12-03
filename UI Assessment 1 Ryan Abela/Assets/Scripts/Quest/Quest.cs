using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    #region Variables

    public Stats.BaseStats player;

    public QuestState questState;
    public string title;
    public string description;
    public string condition1, condition2, condition3;

    
    public int expReward;
    public int goldReward;

    public int reqLevel;

    public QuestGoal goal;

    public Quest quest;


    #endregion
 
  
   
}

