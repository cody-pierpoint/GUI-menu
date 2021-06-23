using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsHandler : MonoBehaviour
{
    public Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public AudioMixer masterAudio;

    public void ChangeVolume(float volume)
    {
        //changes volume
        masterAudio.SetFloat("volume",volume); 


    }

    public void ToggleMute(bool isMuted)
    {
        //toggles mute
        if(isMuted)
        {
            masterAudio.SetFloat("isMutedVolume", -80);

        }
        else
        {
            masterAudio.SetFloat("isMutedVolume", 0);
        }
    }


    private void Start()
    {
        //resolution = screen resolution
        resolutions = Screen.resolutions;
        //clears dropdown options
        resolutionDropdown.ClearOptions();
        //creates a new list of options
        List<string> options = new List<string>();
        //sets the current resolution  index to 0
        int currentResolutionIndex = 0;
        //for each resolution
        for (int i = 0; i < resolutions.Length; i++)
        {
            //store resolution width and height in option
            string option = resolutions[i].width + "x" + resolutions[i].height;
            //add option to the list of options
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                
                currentResolutionIndex = i;

            }

        }

       // add options to the dropdown
        resolutionDropdown.AddOptions(options);
        //added the value for each resolution in dropdown
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();



    }

    public void SetResolution(int resolutionIndex)
    {
        //set resolution to be resolution width and height based on fullscreen
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);

    }

    public void Quality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

    }





}
