using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Sound")]
    public AudioSource audioSource;
    public AudioMixer mixer;

    public const string musicKey = "musicVolume";
    public const string sfxKey = "sfxVolume";

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
        LoadVolume();
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
