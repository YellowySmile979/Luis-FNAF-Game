using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Sound")]
    public AudioSource audioSource;
    public AudioMixer mixer;

    public const string mixerInGame = "InGameVolume";

    public const string musicKey = "musicVolume";
    public const string sfxKey = "sfxVolume";
    public const string inGameKey = "inGameVolume";

    public static AudioManager Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        PlayerPrefs.SetFloat(inGameKey, 0.31622f);
        LoadVolume();
    }

    // Start is called before the first frame update
    void Start()
    {
        float presetVol = PlayerPrefs.GetFloat(inGameKey, 1f);
        mixer.SetFloat(mixerInGame, Mathf.Log10(presetVol) * 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //sudio manager should be added to every scene
    void LoadVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat(musicKey, 1f);
        mixer.SetFloat(SettingsManager.mixerMusic, Mathf.Log10(musicVolume) * 20);

        float sfxVolume = PlayerPrefs.GetFloat(sfxKey, 1f);
        mixer.SetFloat(SettingsManager.mixerSfx, Mathf.Log10(sfxVolume) * 20);
    }
}
