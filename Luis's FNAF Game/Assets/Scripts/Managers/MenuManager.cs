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

    [Header("Continue")]
    public float night = 0f;
    public const string nightKey = "Night";
    
    public Button continueButton;

    [Header("Custom Night")]
    public bool open = false;
    public GameObject customNight;

    public Transform buttonParent;
    public Button customNightButton;

    public const string canCustomNight = "Can Custom Night";

    [Header("Command Prompt")]
    public GameObject commandPrompt;
    public InputField inputField;
    public Text previousCommands;

    public string input;

    public const string bdayVidPasscode = "PNmQyXOtx3n$.{i";

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

        if(night <= 0)
        {
            continueButton.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (current != null)
        {
            SongProgress(AudioManager.Instance.audioSource.time, current.length, current.name);
        }
        if(PlayerPrefs.GetInt(canCustomNight) == 1)
        {
            customNightButton.gameObject.SetActive(true);

            customNightButton.transform.SetParent(buttonParent.transform);
            customNightButton.transform.SetSiblingIndex(2);
        }
        if (Input.GetKey(KeyCode.C))
        {
            if (Input.GetKey(KeyCode.H))
            {
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    commandPrompt.SetActive(true);
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape) && commandPrompt.activeSelf == true)
        {
            commandPrompt.SetActive(false);
        }
    }
    public void ReadStringInput(string s)
    {
        s = inputField.text;

        input = s;

        switch (input)
        {
            default:
                previousCommands.text = "The command '" + input + "' does not exist! Please try again.";
                break;
            case bdayVidPasscode:
                //TO DO: create function that handles the bday video
                break;
            case "Your mom":
                previousCommands.text = "Luis. No. Stop. You are old enough to not do this.";
                break;
            case "sex":
                previousCommands.text = "Seriously? sex? Of all things to type. sex?";
                break;
            case "balls":
                previousCommands.text = "No.";
                break;
            case "tits":
                previousCommands.text = "Ay yo! Ay YO!";
                break;
            case "Putang Ina":
                previousCommands.text = "";
                break;
        }
    }
    public void OpenCustomNight()
    {
        open = !open;
        if(open)
        {
            customNight.SetActive(true);
            for(int i = 0; i < listOfMainMenuStuff.Count; i++)
            {
                listOfMainMenuStuff[i].SetActive(false);
            }
        }
    }
    public void CloseCustomNight()
    {
        open = !open;
        if (!open)
        {
            customNight.SetActive(false);
            for (int i = 0; i < listOfMainMenuStuff.Count; i++)
            {
                listOfMainMenuStuff[i].SetActive(true);
            }
        }
    }
    public void ContinueGame()
    {
        night = PlayerPrefs.GetFloat(nightKey);
        switch (night) 
        {
            default:
                SceneManager.LoadScene("Night 1");
                break;
            case 1:
                SceneManager.LoadScene("Night 1");
                break;
            case 2:
                SceneManager.LoadScene("Night 2");
                break;
            case 3:
                SceneManager.LoadScene("Night 3");
                break;
            case 4:
                SceneManager.LoadScene("Night 4");
                break;
            case 5:
                SceneManager.LoadScene("Night 5");
                break;
            case 6:
                SceneManager.LoadScene("Night 6");
                break;
        }
    }
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
        current = null;
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
    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetFloat(nightKey, 1);
        night = PlayerPrefs.GetFloat(nightKey);
        continueButton.interactable = true;

        PlayerPrefs.SetInt(canCustomNight, 0);

        SceneManager.LoadScene(loadScene);
    }
}
