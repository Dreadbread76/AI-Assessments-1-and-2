using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomisationGet : MonoBehaviour
{
    public Statistics player;
    public Renderer charMesh;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Statistics>();
        charMesh = GameObject.FindGameObjectWithTag("CharacterMesh").GetComponent<Renderer>();
        string[] tempName = new string[] { "Strength", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma" };
        for (int i = 0; i < tempName.Length; i++)
        {
            player.charStats[i].name = tempName[i];
        }
        Load();
    }
    private void Load()
    {
        if(!PlayerPrefs.HasKey("Character Name"))
        {
            SceneManager.LoadScene(1);
        }
        player.gameObject.name = PlayerPrefs.GetString("Character Name");

        SetTexture("Skin", PlayerPrefs.GetInt("SkinIndex"));
        SetTexture("Hair", PlayerPrefs.GetInt("HairIndex"));
        SetTexture("Mouth", PlayerPrefs.GetInt("MouthIndex"));
        SetTexture("Eyes", PlayerPrefs.GetInt("EyesIndex"));
        SetTexture("Clothes", PlayerPrefs.GetInt("ClothesIndex"));
        SetTexture("Armour", PlayerPrefs.GetInt("ArmourIndex"));

        
        
    }
    void SetTexture(string type, int index)
    {
        Texture2D texture = null;
        int matIndex = 0;
        switch (type)
        {
            case "Skin":
                texture = Resources.Load("Character/Skin_" + index) as Texture2D;
                matIndex = 1;
                break;

            case "Hair":
                texture = Resources.Load("Character/Hair_" + index) as Texture2D;
                matIndex = 2;
                break;
            case "Mouth":
                texture = Resources.Load("Character/Mouth_" + index) as Texture2D;
                matIndex = 3;
                break;
            case "Eyes":
                texture = Resources.Load("Character/Eyes_" + index) as Texture2D;
                matIndex = 4;
                break;
            case "Clothes":
                texture = Resources.Load("Character/Clothes_" + index) as Texture2D;
                matIndex = 5;
                break;
            case "Armour":
                texture = Resources.Load("Character/Armour_" + index) as Texture2D;
                matIndex = 6;
                break;
        }
        Material[] mats = charMesh.materials;
        mats[matIndex].mainTexture = texture;
        charMesh.materials = mats;
    }
}
