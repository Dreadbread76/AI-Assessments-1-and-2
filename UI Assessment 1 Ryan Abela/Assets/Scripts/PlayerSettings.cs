using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;



public class PlayerSettings : MonoBehaviour
{
    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private AudioSource myAudio;
    public Toggle fullscreenToggle;
    public void Awake()
    {
        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
            toggle.isOn = true;
            myAudio.enabled = true;
            PlayerPrefs.Save();
        }
        else
        {
            if (PlayerPrefs.GetInt("music") == 0)
            {
                myAudio.enabled = false;
                toggle.isOn = false;
            }
            else
            {
                myAudio.enabled = true;
                toggle.isOn = true; 
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SavePlayerPrefs()
    {
        if (Screen.fullScreen)
        {
            PlayerPrefs.SetInt("fullscreen", 1);

        }
        else
        {
            PlayerPrefs.SetInt("fullscreen", 0);
        }
        PlayerPrefs.Save();
    }
    public void LoadPlayerPrefs()
    {
        if (PlayerPrefs.GetInt("fullscreen") == 0)
        {
            fullscreenToggle.isOn = false;
        }
        else
        {
            fullscreenToggle.isOn = true;
        }
    }
}
