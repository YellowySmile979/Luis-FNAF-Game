using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using AudioSettingsKey;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider musicSlider, sfxSlider, voicelinesSlider;

    public const string mixerMusic = "MusicVolume";
    public const string mixerSfx = "SFXVolume";
    public const string mixerVoicelines = "VoicelinesVolume";

    void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        voicelinesSlider.onValueChanged.AddListener(SetVoicelinesVolume);
    }
    void OnDisable()
    {
        PlayerPrefs.SetFloat(Keys.musicKey, musicSlider.value);
        PlayerPrefs.SetFloat(Keys.sfxKey, sfxSlider.value);
        PlayerPrefs.SetFloat(Keys.voiceLinesKey, voicelinesSlider.value);
    }

    // Start is called before the first frame update
    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(Keys.musicKey, 1f);
        sfxSlider.value = PlayerPrefs.GetFloat(Keys.sfxKey, 1f);
        voicelinesSlider.value = PlayerPrefs.GetFloat(Keys.voiceLinesKey, 1f);
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
    void SetVoicelinesVolume(float volume)
    {
        mixer.SetFloat(mixerVoicelines, Mathf.Log10(volume) * 20);
    }
}
