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

    public Slider musicSlider;
    public Slider SFXSlider;

    public Text muteText;
    public Text fpsYesNoText;


    public Text fpsText;

    public float musicSliderValue;
    public float SFXSliderValue;

    public bool isMuted = false;

    private int lastFrameIndex;
    private float[] frameDeltaTimeArray;

    void Awake()
    {
        musicSliderValue = musicSlider.value;
        SFXSliderValue = SFXSlider.value;

        frameDeltaTimeArray = new float[100];
    }

    void Update()
    {
        frameDeltaTimeArray[lastFrameIndex] = Time.deltaTime;
        lastFrameIndex = (lastFrameIndex + 1) % frameDeltaTimeArray.Length;

        fpsText.text = Mathf.RoundToInt(CalculateFPS()).ToString();
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
            fpsYesNoText.text = "No";
        }
        else
        {
            UnMute();
            fpsYesNoText.text = "Yes";
        }
    }

    public float CalculateFPS()
    {
        float total = 0f;

        foreach(float deltaTime in frameDeltaTimeArray)
        {
            total += deltaTime;
        }

        return frameDeltaTimeArray.Length / total;
    }

    public void ShowFPS()
    {
        if (fpsToggle.isOn)
        {
            fpsText.gameObject.SetActive(true);
            fpsYesNoText.text = "Yes";
        }
        else
        {
            fpsYesNoText.text = "No";
            fpsText.gameObject.SetActive(false);
        }
    }

}
