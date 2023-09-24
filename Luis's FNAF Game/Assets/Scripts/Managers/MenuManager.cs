using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Main Buttons")]
    public List<GameObject> listOfMainMenuStuff = new List<GameObject>();

    [Header("Loading Game")]
    public string loadScene = "Night 1";

    [Header("Settings")]
    public GameObject settings;
    bool openOrCloseSettings;
    public List<AudioClip> listOfSongsForEnQi = new List<AudioClip>();
    public Text pauseText, currentSongName;
    public Image songProgress;
    AudioClip audioClip, current;

    public static MenuManager Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InGameAudioNormal();
    }

    // Update is called once per frame
    void Update()
    {
        if (current != null)
        {
            SongProgress(AudioManager.Instance.audioSource.time, current.length, current.name);
        }
    }
    //songs
    public void SongPlaylist(int index)
    {
        AudioManager.Instance.audioSource.Stop();

        audioClip = listOfSongsForEnQi[index];
        AudioManager.Instance.audioSource.clip = audioClip;

        current = audioClip;

        AudioManager.Instance.audioSource.Play();
    }
    public void SongProgress(float progressOfSong, float totalDuration, string nameOfSong)
    {
        songProgress.fillAmount = progressOfSong / totalDuration;
        currentSongName.text = nameOfSong;
    }
    bool isPaused = true;
    public void PauseSong()
    {
        isPaused = !isPaused;
        if (!isPaused)
        {
            AudioManager.Instance.audioSource.Pause();
            pauseText.text = "PAUSED";
        }
        else
        {
            AudioManager.Instance.audioSource.UnPause();
            pauseText.text = " ";
        }
    }
    //skips the song forward by 1
    public void SkipForward()
    {
        //sets the current playing clip in the audiosource to the clip var
        AudioClip clip = AudioManager.Instance.audioSource.clip;

        pauseText.text = " ";
        isPaused = true;

        //gets the index of that clip and sets it to the index int
        int index = listOfSongsForEnQi.FindIndex(0, listOfSongsForEnQi.Count, s => s == clip);

        index++;
        
        //checks to see if index goes out of bounds
        if (index < 0)
        {
            index = listOfSongsForEnQi.Count - 1;
        }
        else if (index > listOfSongsForEnQi.Count - 1)
        {
            index = 0;
        }
        print("Forward Index: " + index);
        //plays clip
        audioClip = listOfSongsForEnQi[index];
        SongPlaylist(index);
    }
    //skips the song backward by 1
    public void SkipBackward()
    {
        //sets the current playing clip in the audiosource to the clip var
        AudioClip clip = AudioManager.Instance.audioSource.clip;

        pauseText.text = " ";
        isPaused = true;

        //gets the index of that clip and sets it to the index int
        int index = listOfSongsForEnQi.FindIndex(0, listOfSongsForEnQi.Count, s => s == clip);

        index--;

        //checks to see if index goes out of bounds
        if (index < 0)
        {
            index = listOfSongsForEnQi.Count - 1;
        }
        else if (index > listOfSongsForEnQi.Count - 1)
        {
            index = 0;
        }
        print("Backward Index: " + index);
        //plays clip
        audioClip = listOfSongsForEnQi[index];
        SongPlaylist(index);
    }
    //handles in game audio section
    public void InGameAudioLow()
    {
        float presetVol = PlayerPrefs.GetFloat(AudioManager.inGameKey, 1f);
        AudioManager.Instance.mixer.SetFloat(AudioManager.mixerInGame, Mathf.Log10(presetVol) * 20);
    }
    public void InGameAudioNormal()
    {
        float presetVol = 1f;
        AudioManager.Instance.mixer.SetFloat(AudioManager.mixerInGame, Mathf.Log10(presetVol) * 20);
    }
    //open/closes the settings
    public void OpenCloseSettings()
    {
        openOrCloseSettings = true;
        if (openOrCloseSettings)
        {
            settings.SetActive(true);
            SongPlaylist(0);
            for(int i = 0; i < listOfMainMenuStuff.Count; i++)
            {
                listOfMainMenuStuff[i].SetActive(false);
            }
        }
    }
    public void BackOutOfSettings()
    {
        openOrCloseSettings = false;
        if (!openOrCloseSettings)
        {
            settings.SetActive(false);
            AudioManager.Instance.audioSource.Stop();
            for (int i = 0; i < listOfMainMenuStuff.Count; i++)
            {
                listOfMainMenuStuff[i].SetActive(true);
            }
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(loadScene);
    }
}
