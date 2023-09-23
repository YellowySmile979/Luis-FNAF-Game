using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider musicSlider, sfxSlider;

    public const string mixerMusic = "MusicVolume";
    public const string mixerSfx = "SFXVolume";

    void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }
    void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.musicKey, musicSlider.value);
        PlayerPrefs.SetFloat(AudioManager.sfxKey, sfxSlider.value);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetMusicVolume(float volume)
    {
        mixer.SetFloat(mixerMusic, Mathf.Log10(volume) * 20);
    }
    void SetSFXVolume(float volume)
    {
        mixer.SetFloat(mixerSfx, Mathf.Log10(volume) * 20);
    }
}
