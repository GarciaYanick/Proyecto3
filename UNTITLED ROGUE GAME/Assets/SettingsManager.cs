using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    //public AudioMixer musicMixer;
    //public AudioMixer SFXMixer;

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

    Resolution[] resolutions;

    public Dropdown resolutionDropdown;

    private void OnEnable()
    {
        Debug.Log("muteToggleValue del GameManager es: " + GameManager.Instance.mutedToggleValue);

        muteToggle.isOn = GameManager.Instance.mutedToggleValue;

        if(GameManager.Instance.mutedText != null)
        {
            Debug.Log("texto mute no es null");
            muteText = GameManager.Instance.mutedText;
        }

        Debug.Log("Variable llamada musicSliderValue es: " + musicSliderValue);
        Debug.Log("Music slider value del slider es: " + musicSlider.value);

        musicSliderValue = musicSlider.value;

        SFXSliderValue = SFXSlider.value;

        Debug.Log("Variable del GameManager llamada musicSliderValue es: " + GameManager.Instance.musicSliderValue);

        musicSlider.value = GameManager.Instance.musicSliderValue;
        SFXSlider.value = GameManager.Instance.SFXSliderValue;
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
        AudioManagerScript.instance.musicMixer.SetFloat("MusicVolume", volume);
        GameManager.Instance.musicSliderValue = volume;

        Debug.Log("ismutedbool del gameManager: " + GameManager.Instance.isMutedBool);

        if (!GameManager.Instance.isMutedBool)
        {
            musicSliderValue = volume;
            Debug.Log("music slider value: " + musicSliderValue);
        }

    }

    public void SetSFX(float volume)
    {
        AudioManagerScript.instance.SFXMixer.SetFloat("SFXVolume", volume);
        GameManager.Instance.SFXSliderValue = volume;

        if (!GameManager.Instance.isMutedBool)
        {
            SFXSliderValue = volume;
        }
    }

    public void Mute()
    {
        GameManager.Instance.isMutedBool = true;

        musicSlider.value = -35;
        SFXSlider.value = -35;

        AudioManagerScript.instance.musicMixer.SetFloat("MusicVolume", -80f);
        AudioManagerScript.instance.SFXMixer.SetFloat("SFXVolume", -80f);

        muteText.text = "Yes";
    }

    public void UnMute()
    {
        GameManager.Instance.isMutedBool = false;

        AudioManagerScript.instance.musicMixer.SetFloat("MusicVolume", musicSliderValue);
        AudioManagerScript.instance.SFXMixer.SetFloat("MusicVolume", SFXSliderValue);

        musicSlider.value = musicSliderValue;
        SFXSlider.value = SFXSliderValue;

        muteText.text = "No";
    }

    public void ToggleMute()
    {
        if (muteToggle.isOn)
        {
            Mute();
        }
        else
        {
            UnMute();
        }

        GameManager.Instance.mutedToggleValue = muteToggle.isOn;
        Debug.Log(GameManager.Instance.mutedToggleValue);
        //GameManager.Instance.mutedText.text = muteText.text;

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