using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer SFXMixer;

    public Toggle muteToggle;
    public Toggle fpsToggle;
    public Toggle fullScreenToggle;

    public Slider musicSlider;
    public Slider SFXSlider;

    public Text muteText;
    public Text fpsYesNoText;
    public Text fullScreenYesNoText;

    public float musicSliderValue;
    public float SFXSliderValue;

    public bool isMuted = false;

    Resolution[] resolutions;

    public Dropdown resolutionDropdown;

    void Awake()
    {
        musicSliderValue = musicSlider.value;
        SFXSliderValue = SFXSlider.value;

        
    }

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        System.Array.Reverse(resolutions);

        int currentResolutionIndex = 0;
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

    void Update()
    {

    }

    public void SetMusic(float volume)
    {
        musicMixer.SetFloat("MusicVolume", volume);
        if (!isMuted)
        {
            musicSliderValue = volume;
        }

    }

    public void SetSFX(float volume)
    {
        SFXMixer.SetFloat("SFXVolume", volume);

        if (!isMuted)
        {
            SFXSliderValue = volume;
        }
    }

    public void Mute()
    {
        isMuted = true;

        musicMixer.SetFloat("MusicVolume", -60);
        SFXMixer.SetFloat("MusicVolume", -60);

        musicSlider.value = -40;
        SFXSlider.value = -40;

        muteText.text = "Yes";
    }

    public void UnMute()
    {
        isMuted = false;

        musicMixer.SetFloat("MusicVolume", musicSliderValue);
        SFXMixer.SetFloat("MusicVolume", SFXSliderValue);

        musicSlider.value = musicSliderValue;
        SFXSlider.value = SFXSliderValue;

        muteText.text = "No";
    }

    public void ToggleMute()
    {
        if (muteToggle.isOn)
        {
            Mute();
            muteText.text = "No";
        }
        else
        {
            UnMute();
            muteText.text = "Yes";
        }
    }

    public void ShowFPS()
    {
        if (fpsToggle.isOn)
        {
            GameManager.Instance.isFrameTextActive = true;
            fpsYesNoText.text = "Yes";
        }
        else
        {
            fpsYesNoText.text = "No";

            GameManager.Instance.isFrameTextActive = false;
        }
    }

    public void SetFullScreen()
    {
        if (fullScreenToggle.isOn)
        {
            Screen.fullScreen = true;
            fullScreenYesNoText.text = "Yes";
        }
        else
        {
            Screen.fullScreen = false;
            fullScreenYesNoText.text = "No";
        }

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}