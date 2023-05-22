using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer; // reference to audio mixer

    public Dropdown ResolutionDropdown; // reference to resolution dropdwon box oject

    Resolution[] resolutions; // array of resolutions

    void Start() //upon scene start
    {
        resolutions = Screen.resolutions; // resolutions array is all the native screen resolutions that are compatible

        ResolutionDropdown.ClearOptions(); // Start off cleared so native res's can be feeded through

        List<string> options = new List<string>(); // set reference to new string

        int currentResolutionIndex = 0; // first resolution

        for (int i = 0; i < resolutions.Length; i++) // for each resolution index
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; // string set to  resolution width x height
            options.Add(option); // add to options for dropdown

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height) // If current resolution of index is current screen resolution
            {
                currentResolutionIndex = i; // current resolution index is set to index, (establishes order of reesolutions)
            }
        }

        ResolutionDropdown.AddOptions(options); // Add options in order of native screen resolutions
        ResolutionDropdown.value = currentResolutionIndex; // establishes order
        ResolutionDropdown.RefreshShownValue(); // refreshes what options are available/compatible
    }

    public void SetResolution (int resolutionIndex) // set resolution function
    {
        Resolution resolution = resolutions[resolutionIndex]; // resolution of array is current resolution index passed
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); // update screen reesolution
    }

    public void SetVolume (float volume) // set volume function
    {
        audioMixer.SetFloat("volume", volume); // volume value is passed to audio mixer
    }

    public void SetQuality (int qualityIndex) // Set quality of UI options function
    {
        QualitySettings.SetQualityLevel(qualityIndex); // Quality level is set by index value selected/passed through
    }

    public void SetFullscreen (bool isFullscreen) // if player checks fullscreen checkbox
    {
        Screen.fullScreen = isFullscreen; // Enable/disable fullscreen according to bool
    }

}
