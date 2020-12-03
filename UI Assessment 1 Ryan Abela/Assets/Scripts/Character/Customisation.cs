using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//you will need to change scenes
public class Customisation : Statistics
{
    #region Variables
    [Header("Texture List")]
    //Texture2D for customisation elements
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();

    [Header("Index")]
    //Index numbers for customisation elements
    public int skinIndex;
    public int clothesIndex, eyesIndex, hairIndex, mouthIndex, armourIndex;

    [Header("Renderer")]
    //Renderer for Char Mesh
    public Renderer charRend;
    [Header("Max Index")]
    //Max amount of customisation elements
    public int skinMax;
    public int clothesMax, eyesMax, hairMax, mouthMax, armourMax;
    [Header("Character Name")]
    //self explanitory
    public string charName;
    public string characterName;
   

    [Header("Character Class")]
    public CharacterClass charClass = CharacterClass.Barbarian;
    public string[] selectedClass = new string[8];
    public int selectedIndex = 0;

    [Header("Dropdown Menu")]
    public bool showDropdown;
    public Vector2 scrollPos;
    public string classButton = "";
    public int statPoints = 10;

    [Header("Canvas Stats")]
    public Button[] addStats;
    public Button[] minusStats;
    public Dropdown classDropdown;
    public Text pointsLeft;
    public Text[] statText;
    string[] tempName = new string[] { "Strength", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma" };
    #endregion
    public struct PointUI
    {
        public Statistics.StatBlock stat;
        public Text nameDisplay;
        public GameObject plusButton;
        public GameObject minusButton;

    }
    public PointUI[] pointSystem;

    private void Awake()
    {

    }
    #region Start
    private void Start()
    {
        selectedClass = new string[] { "Barbarian", "Bard", "Druid", "Monk", "Paladin", "Ranger", "Sorcerer", "Warlock" };
        ChooseClass(selectedIndex);

        /* for (int i = 0; i < charStats.Length; i++)
         {
             charStats[i].nameDisplay.text = charStats[i].name + ": " +
                 (charStats[i].value + charStats[i].tempValue);

             pointSystem[i].minusButton.SetActive(false);
         }*/
        #region Skin
        for (int i = 0; i < skinMax; i++)
        {
            //GRAB TEXTURES FROM RESOURCES.LOAD 
            Texture2D temp = Resources.Load("Character/Skin_" + i) as Texture2D;
            skin.Add(temp);
        }

        #endregion
        #region Hair
        for (int i = 0; i < hairMax; i++)
        {
            //GRAB TEXTURES FROM RESOURCES.LOAD 
            Texture2D temp = Resources.Load("Character/Hair_" + i) as Texture2D;
            hair.Add(temp);
        }

        #endregion
        #region Mouth
        for (int i = 0; i < mouthMax; i++)
        {
            //GRAB TEXTURES FROM RESOURCES.LOAD 
            Texture2D temp = Resources.Load("Character/Mouth_" + i) as Texture2D;
            mouth.Add(temp);
        }

        #endregion
        #region Eyes
        for (int i = 0; i < eyesMax; i++)
        {
            //GRAB TEXTURES FROM RESOURCES.LOAD 
            Texture2D temp = Resources.Load("Character/Eyes_" + i) as Texture2D;
            eyes.Add(temp);
        }

        #endregion
        #region Clothes
        for (int i = 0; i < clothesMax; i++)
        {
            //GRAB TEXTURES FROM RESOURCES.LOAD 
            Texture2D temp = Resources.Load("Character/Clothes_" + i) as Texture2D;
            clothes.Add(temp);
        }

        #endregion
        #region Armour
        for (int i = 0; i < armourMax; i++)
        {
            //GRAB TEXTURES FROM RESOURCES.LOAD 
            Texture2D temp = Resources.Load("Character/Armour_" + i) as Texture2D;
            armour.Add(temp);
        }

        #endregion
        charRend = GameObject.FindGameObjectWithTag("CharacterMesh").GetComponent<SkinnedMeshRenderer>();
        #region Set textures on start
        SetTexture("Skin", 0);
        SetTexture("Hair", 0);
        SetTexture("Mouth", 0);
        SetTexture("Eyes", 0);
        SetTexture("Clothes", 0);
        SetTexture("Armour", 0);

        #endregion
        #region Class
        if (classDropdown != null)
        {
            classDropdown.ClearOptions();
            List<string> options = new List<string>();

            int currentClassIndex = 0;
            //loop through and create option for the list
            for (int i = 0; i < selectedClass.Length; i++)
            {

                classButton = selectedClass[i];
                string option = classButton;
                options.Add(option);


            }
            classDropdown.RefreshShownValue();
            classDropdown.AddOptions(options);
            classDropdown.value = currentClassIndex;
        }
        
        

        #endregion


    }
    #endregion
    public void Update()
    {

        #region Stats
        if (pointsLeft != null)
        {
            pointsLeft.text = "Points: " + statPoints;
            for (int i = 0; i < tempName.Length; i++)
            {

                statText[i].text = tempName[i] + ": " + charStats[i].value;
            }
        }
        #endregion
    }
    #region Set texture
    void SetTexture(string type, int dir)
    {
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];
        #region Materials and Values Switch
        switch (type)
        {
            case "Skin":
                index = skinIndex;
                max = skinMax;
                textures = skin.ToArray();
                matIndex = 1;
            break;
            case "Hair":
                index = hairIndex;
                max = hairMax;
                textures = hair.ToArray();
                matIndex = 2;
                break;
            case "Mouth":
                index = mouthIndex;
                max = mouthMax;
                textures = mouth.ToArray();
                matIndex = 3;
                break;
            case "Eyes":
                index = eyesIndex;
                max = eyesMax;
                textures = eyes.ToArray();
                matIndex = 4;
                break;
            case "Clothes":
                index = clothesIndex;
                max = clothesMax;
                textures = clothes.ToArray();
                matIndex = 5;
                break;
            case "Armour":
                index = armourIndex;
                max = armourMax;
                textures = armour.ToArray();
                matIndex = 6;
                break;
        }
        
        
        #endregion
        
        Material[] mat = charRend.materials;
        mat[matIndex].mainTexture = textures[index];
        charRend.materials = mat;

        #region Assign Direction
        index += dir;
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }
        #endregion
        #region Set Material Switch 
        switch (type)
        {
            case "Skin":
                skinIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Clothes":
                clothesIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;
        }

        #endregion
       
    }
    
#endregion
   
    public void SaveCharacter()
    {
        PlayerPrefs.SetInt("SkinIndex", skinIndex);
        PlayerPrefs.SetInt("HairIndex", hairIndex);
        PlayerPrefs.SetInt("MouthIndex", mouthIndex);
        PlayerPrefs.SetInt("EyesIndex", eyesIndex);
        PlayerPrefs.SetInt("ClothesIndex", clothesIndex);
        PlayerPrefs.SetInt("ArmourIndex", armourIndex);

        PlayerPrefs.SetString("CharacterName", charName);
        for (int i = 0; i < charStats.Length; i++)
        {
            PlayerPrefs.SetInt(charStats[i].name, (charStats[i].value + charStats[i].tempValue));
        }
        PlayerPrefs.SetString("CharacterClass", selectedClass[selectedIndex]);

        
       
    }
    public void ResetOptions()
    {
        SetTexture("Skin", 0);
        skinIndex = 0;
        SetTexture("Hair", 0);
        hairIndex = 0;
        SetTexture("Mouth", 0);
        mouthIndex = 0;
        SetTexture("Eyes", 0);
        eyesIndex = 0;
        SetTexture("Clothes", 0);
        clothesIndex = 0;
        SetTexture("Armour", 0);
        armourIndex = 0;
    }
    public void RandomiseOptions()
    {
        SetTexture("Skin", Random.Range(0, skinMax));
        SetTexture("Hair", Random.Range(0, hairMax));
        SetTexture("Mouth", Random.Range(0, mouthMax));
        SetTexture("Eyes", Random.Range(0, eyesMax));
        SetTexture("Clothes", Random.Range(0, clothesMax));
        SetTexture("Armour", Random.Range(0, armourMax));
    }
    
    
    public enum CharacterClass
    {
        Barbarian,
        Bard,
        Druid,
        Monk,
        Paladin,
        Ranger,
        Sorcerer,
        Warlock
    }
    public void ChooseClass(int classIndex)
    {
        switch (classIndex)
        {
            case 0:
                charStats[0].value = 60;
                charStats[1].value = 10;
                charStats[2].value = 10;
                charStats[3].value = 10;
                charStats[4].value = 10;
                charStats[5].value = 10;
                charClass = CharacterClass.Barbarian;
                break;
            case 1:
                charStats[0].value = 5;
                charStats[1].value = 10;
                charStats[2].value = 10;
                charStats[3].value = 10;
                charStats[4].value = 10;
                charStats[5].value = 10;
                charClass = CharacterClass.Bard;
                break;
            case 2:
                charStats[0].value = 15;
                charStats[1].value = 10;
                charStats[2].value = 10;
                charStats[3].value = 10;
                charStats[4].value = 10;
                charStats[5].value = 10;
                charClass = CharacterClass.Druid;
                break;
            case 3:
                charStats[0].value = 10;
                charStats[1].value = 10;
                charStats[2].value = 10;
                charStats[3].value = 10;
                charStats[4].value = 10;
                charStats[5].value = 10;
                charClass = CharacterClass.Monk;
                break;
            case 4:
                charStats[0].value = 40;
                charStats[1].value = 10;
                charStats[2].value = 10;
                charStats[3].value = 10;
                charStats[4].value = 10;
                charStats[5].value = 10;
                charClass = CharacterClass.Paladin;
                break;
            case 5:
                charStats[0].value = 30;
                charStats[1].value = 10;
                charStats[2].value = 10;
                charStats[3].value = 10;
                charStats[4].value = 10;
                charStats[5].value = 10;
                charClass = CharacterClass.Ranger;
                break;
            case 6:
                charStats[0].value = 20;
                charStats[1].value = 10;
                charStats[2].value = 10;
                charStats[3].value = 10;
                charStats[4].value = 10;
                charStats[5].value = 10;
                charClass = CharacterClass.Sorcerer;
                break;
            case 7:
                charStats[0].value = 25;
                charStats[1].value = 10;
                charStats[2].value = 10;
                charStats[3].value = 10;
                charStats[4].value = 10;
                charStats[5].value = 10;
                charClass = CharacterClass.Warlock;
                break;

        }
        

    }
    public void AddPoint(int val)
    {
        if (statPoints > 0)
        {
            statPoints--;
            charStats[val].value++;
        }
        else
        {
            for (int button = 0; button < charStats.Length; button++)
            {
                charStats[button].plusButton.SetActive(false);
            }
        }
            
        if (charStats[val].minusButton.activeSelf == false)
        {
            charStats[val].minusButton.SetActive(true);
        }

    }
    public void RemovePoint(int val)
    {
        
        if (statPoints < 10 && charStats[val].value > 0)
        {
            statPoints++;
            charStats[val].value--;
        }
        if (charStats[val].value <= 0)
        {
            charStats[val].minusButton.SetActive(false);

        }
        if (charStats[val].plusButton.activeSelf == false)
        {
            for (int button = 0; button < charStats.Length; button++)
            {
                charStats[button].plusButton.SetActive(true);
            }
        }
        
        

    }
    public void SetTexturePos(string type)
    {
        SetTexture(type, 1);
    }
    public void SetTextureNeg(string type)
    {
        SetTexture(type, 1);
    }
    public void SetName(string charName)
    {
        characterName = charName;
    }

}