using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData
{
    public int savedLevel;
    public float savedHealth;
    public float[] savedPlayerPos;
    public float[] savedPlayerRot;

    public int[] stats = new int[6];
    public float[] currentStatus = new float[3];
    public float[] maxStatus = new float[3];
    public string savedCheckpoint;
    public string savedName;
    public float savedExp;
    public float savedNeededExp;
    public float savedMaxExp;

    public PlayerData (Stats.BaseStats player)
    {
        savedLevel = player.level;
        savedHealth = player.characterStatus[0].currentValue;
        savedName = player.name;
        savedExp = player.currentExp;
        savedNeededExp = player.neededExp;
        savedMaxExp = player.maxExp;
        savedCheckpoint = player.currentCheckpoint.name;


        savedPlayerPos = new float[3];
        savedPlayerPos[0] = player.transform.position.x;
        savedPlayerPos[1] = player.transform.position.y;
        savedPlayerPos[2] = player.transform.position.z;

        savedPlayerRot = new float[4];
        savedPlayerRot[0] = player.transform.rotation.x;
        savedPlayerRot[1] = player.transform.rotation.y;
        savedPlayerRot[2] = player.transform.rotation.z;
        savedPlayerRot[3] = player.transform.rotation.w;

        for (int i = 0; i < currentStatus.Length; i++)
        {
            currentStatus[i] = player.characterStatus[i].currentValue;
            maxStatus[i] = player.characterStatus[i].maxValue;
        }
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] = player.characterstats[i].value + player.characterstats[i].value;
        }
    }

    
}
