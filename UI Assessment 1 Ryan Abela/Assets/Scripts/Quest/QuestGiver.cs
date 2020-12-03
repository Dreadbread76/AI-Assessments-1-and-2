using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public Stats.BaseStats player;
    public LinearInventory inventory;
    public GameObject questWindow;

    public Text titleText, descriptionText, experienceText, goldText, condition1Text, condition2Text, condition3Text, statusText;

    /*
    public void Update()
    {
        if (quest.goal.IsReached() == true && (quest.questState != QuestState.Complete || quest.questState != QuestState.Claimed))
        {
            quest.Complete();
        }
    }
    */
    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        experienceText.text = quest.expReward.ToString();
        goldText.text = quest.goldReward.ToString();
    }
    public void AcceptQuest()
    {
        quest.goal.questState = QuestState.Active;
        questWindow.SetActive(false);
        player.quest = quest;
    }
    public void ClaimQuest()
    {
        player.currentExp += quest.expReward;
        LinearInventory.money += quest.goldReward;
        quest.goal.questState = QuestState.Claimed;
    }
}
