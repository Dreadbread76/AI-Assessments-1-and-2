using UnityEngine;

public class PlayerSaveAndLoad : MonoBehaviour
{
    public static Stats.BaseStats player;

    #region Awake
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats.BaseStats>();
        if(!PlayerPrefs.HasKey("Loaded"))
        {
            PlayerPrefs.DeleteAll();
            //FirstLoad Function...sets up Player Data
            FirstLoad();
            //Save Data Creates first save file in binary
            Save();
            //We now have our first save file
            PlayerPrefs.SetInt("Loaded",0);
        }
        else
        {
            Load();
        }
    }

    #endregion
    #region First Load
    void FirstLoad()
    {
        player.name = "Joe Mama";
        player.level = 1;
        player.currentCheckpoint = GameObject.Find("First Check Point").GetComponent<Transform>();

        player.maxExp = 60;

        for (int i = 0; i < 3; i++)
        {
            player.characterStatus[i].maxValue = 100;
            player.characterStatus[i].currentValue = 100;
        }
        for (int i = 0; i < 6; i++)
        {
            player.characterstats[i].value = 10;
        }
    }

    #endregion
    #region Save
    public static void Save()
    {
        //Do when Binary is done
        PlayerBinary.SavePlayer(player);
    }
    #endregion
    #region Load
    public static void Load()
    {
        //Do this when Binary is done
        PlayerData data = PlayerBinary.LoadPlayer();
        player.name = data.savedName;
        player.level = data.savedLevel;
        player.currentCheckpoint = GameObject.Find(data.savedCheckpoint).GetComponent<Transform>();
        player.currentExp = data.savedExp;
        player.neededExp = data.savedNeededExp;
        player.maxExp = data.savedMaxExp;

        for (int i = 0; i < player.characterstats.Length; i++)
        {
            player.characterstats[i].value = data.stats[i];
        }
        for (int i = 0; i < player.characterstats.Length; i++)
        {
            player.characterStatus[i].maxValue = data.maxStatus[i];
            player.characterStatus[i].currentValue = data.currentStatus[i];
        }

        player.transform.position = new Vector3(data.savedPlayerPos[0], data.savedPlayerPos[1], data.savedPlayerPos[2]);
        player.transform.rotation = new Quaternion(data.savedPlayerRot[0], data.savedPlayerRot[1], data.savedPlayerRot[2],data.savedPlayerRot[3]);        
    }
    #endregion
}
