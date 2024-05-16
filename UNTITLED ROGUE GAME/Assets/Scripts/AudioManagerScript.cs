using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManagerScript : MonoBehaviour
{
    [NonSerialized] public static AudioManagerScript instance;
    [Header("------------Audio Source --------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("------------Audio Clips -------------")]
    public AudioClip menuTheme;
    public AudioClip gameTheme;
    public AudioClip gameOverTheme;
    public AudioClip attack;
    public AudioClip jump;
    public AudioClip collectCoin;
    public AudioClip killEnemy;

    public AudioMixer musicMixer;
    public AudioMixer SFXMixer;

    public Slider sliderOcultoDeLaHoja;

    private void OnEnable()
    {
        Debug.Log("OnEnable AudioManager");

        //sliderOcultoDeLaHoja.value = -20f;

        //musicMixer.SetFloat("MusicVolume", sliderOcultoDeLaHoja.value);

    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else Destroy(gameObject);
        musicSource.volume = 0.35f;
    }

    //public void SetMixerOnStart(float volume)
    //{
    //    musicMixer.SetFloat("MusicVolume", volume);
    //}

    void Start()
    {
        musicSource.clip = menuTheme;
        musicSource.Play();
    }

    public void StartGame()
    {
        musicSource.Stop();
        musicSource.clip = gameTheme;
        musicSource.Play();
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
    public void StartMenuTheme()
    {
        if (sfxSource.isPlaying)
        {
            sfxSource.Stop();
        }
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
        musicSource.clip = menuTheme;
        musicSource.Play();
    }

    public void StartGameOverTheme()
    {
        if (sfxSource.isPlaying)
        {
            sfxSource.Stop();
        }
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
        musicSource.clip = gameOverTheme;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip audio)
    {
        sfxSource.PlayOneShot(audio);
    }
}