using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OptionsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    #region Audio

    public AudioMixer mixer;
    public AudioClip[] audioClips;
    public AudioClip currentClips;
    public AudioSource audioSource;
    public void SetVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
    }
    public void ToggleMute(bool isMuted)
    {
        if (isMuted)
        {
            mixer.SetFloat("isMutedVolume", -80);
        }
        else
        {
            mixer.SetFloat("isMutedVolume", 0);
        }
    }
    public void PlayClip()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }
    #endregion
    #region SetQuality
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    #endregion
    #region SetFullscreen
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    #endregion

    #region SetResolution
    public Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    

    private void Start()
    {
        //Get monitor resolution
        resolutions = Screen.resolutions;
        //empty drop down
        resolutionDropdown.ClearOptions();

        //Create a list of string
        List<string> options = new List<string>();
        //Current Resolution Index
        int currentResolutionIndex = 0;
        //loop through and create option for the list
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);

    }
    #endregion
}
