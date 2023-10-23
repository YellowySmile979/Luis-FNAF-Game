using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuManager : MonoBehaviour, IDataPersistence
{
    [Header("Main Buttons")]
    public List<GameObject> listOfMainMenuStuff = new List<GameObject>();

    [Header("Loading Game")]
    public string loadScene = "Night 1";

    [Header("Settings")]
    public GameObject settings;
    bool openOrCloseSettings;

    public GameObject videoMenu;
    public CanvasScaler canvasScaler;
    public InputField resoXInput, resoYInput;
    public float resoLength = 1920, resoWidth = 1080;
    public int resoXCharLim = 4, resoYCharLim = 4;
    public string resoCharLimit = "0123456789";

    public GameObject audioMenu;
    public List<AudioClip> listOfSongsForEnQi = new List<AudioClip>();
    public Text pauseText, currentSongName;
    public Image songProgress;
    AudioClip audioClip, current;

    public GameObject extrasMenu;
    public List<Image> characters = new List<Image>();
    public List<string> names = new List<string>();
    public Text characterDescription, characterName;
    [Range(0, 4)]
    [SerializeField] int chosenCharacter;

    public string characterDescriptionText;

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
    public GameObject bdayObj;
    public VideoPlayer videoPlayer;

    public int characterLimit = 20;
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

        inputField.characterLimit = characterLimit;

        resoXInput.characterLimit = resoXCharLim;
        resoXInput.onValidateInput = (string text, int charIndex, char addedChar) =>
        {
            return ValidateChar(resoCharLimit, addedChar);
        };
        resoYInput.characterLimit = resoYCharLim;
        resoYInput.onValidateInput = (string text, int charIndex, char addedChar) =>
        {
            return ValidateChar(resoCharLimit, addedChar);
        };

        characterName.text = names[chosenCharacter];
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
            previousCommands.text = "Awaiting command...";
            inputField.text = "Enter command...";
            input = "Enter command...";
            commandPrompt.SetActive(false);
        }
    }

    public void LoadData(CharacterDescriptionData data)
    {
        this.characterDescriptionText = data.characterDescription;
        this.chosenCharacter = data.chosenCharacter;
        this.night = data.night;

        data.descriptions.TryGetValue(chosenCharacter, out characterDescriptionText);
        this.characterDescription.text = this.characterDescriptionText;

        //Debug.Log("Character Description Text: " + characterDescriptionText);
    }
    public void SaveData(ref CharacterDescriptionData data)
    {
        data.characterDescription = this.characterDescriptionText;
        data.chosenCharacter = this.chosenCharacter;
        data.night = this.night;
    }
    public void NextCharacter()
    {
        if(chosenCharacter < 4)
        {
            chosenCharacter++;
        }
        CharacterDescriptionAndName();
    }
    public void PrevCharacter()
    {
        if(chosenCharacter > 0)
        {
            chosenCharacter--;
        }
        CharacterDescriptionAndName();
    }
    public void CharacterDescriptionAndName()
    {
        switch (chosenCharacter)
        {
            case 0:
                characterName.text = names[chosenCharacter];

                DataPersistenceManager.Instance.SaveGame();
                //push the loaded data to all other scripts that we need it
                foreach (IDataPersistence dataPersistenceObj in DataPersistenceManager.Instance.dataPersistenceObjects)
                {
                    dataPersistenceObj.LoadData(DataPersistenceManager.Instance.characterDescriptionData);
                }
                break;
            case 1:
                characterName.text = names[chosenCharacter];

                DataPersistenceManager.Instance.SaveGame();
                //push the loaded data to all other scripts that we need it
                foreach (IDataPersistence dataPersistenceObj in DataPersistenceManager.Instance.dataPersistenceObjects)
                {
                    dataPersistenceObj.LoadData(DataPersistenceManager.Instance.characterDescriptionData);
                }
                break;
            case 2:
                characterName.text = names[chosenCharacter];

                DataPersistenceManager.Instance.SaveGame();
                //push the loaded data to all other scripts that we need it
                foreach (IDataPersistence dataPersistenceObj in DataPersistenceManager.Instance.dataPersistenceObjects)
                {
                    dataPersistenceObj.LoadData(DataPersistenceManager.Instance.characterDescriptionData);
                }
                break;
            case 3:
                characterName.text = names[chosenCharacter];

                DataPersistenceManager.Instance.SaveGame();
                //push the loaded data to all other scripts that we need it
                foreach (IDataPersistence dataPersistenceObj in DataPersistenceManager.Instance.dataPersistenceObjects)
                {
                    dataPersistenceObj.LoadData(DataPersistenceManager.Instance.characterDescriptionData);
                }
                break;
            case 4:
                characterName.text = names[chosenCharacter];

                DataPersistenceManager.Instance.SaveGame();
                //push the loaded data to all other scripts that we need it
                foreach (IDataPersistence dataPersistenceObj in DataPersistenceManager.Instance.dataPersistenceObjects)
                {
                    dataPersistenceObj.LoadData(DataPersistenceManager.Instance.characterDescriptionData);
                }
                break;
        }
        this.characterDescription.text = this.characterDescriptionText;
    }
    public void VideoMenu()
    {
        videoMenu.SetActive(true);
        audioMenu.SetActive(false);
        extrasMenu.SetActive(false);
    }
    public void AudioMenu()
    {
        videoMenu.SetActive(false);
        audioMenu.SetActive(true);
        extrasMenu.SetActive(false);
    }
    public void ExtrasMenu()
    {
        videoMenu.SetActive(false);
        audioMenu.SetActive(false);
        extrasMenu.SetActive(true);
    }
    char ValidateChar(string validCharacters, char addedChar)
    {
        if (validCharacters.IndexOf(addedChar) != -1)
        {
            //valid
            return addedChar;
        }
        else
        {
            //invalid
            return '\0';
        }
    }
    public void XResolution(string s)
    {
        s = resoXInput.text;

        resoLength = float.Parse(s);

        if(resoLength != 1920)
        {
            resoLength = 1920;
            resoXInput.text = "1920";
        }

        canvasScaler.referenceResolution = new Vector2(resoLength, canvasScaler.referenceResolution.y);
    }
    public void YResolution(string s)
    {
        s = resoYInput.text;

        resoWidth = float.Parse(s);
        
        if(resoWidth!= 1080)
        {
            resoWidth = 1080;
            resoYInput.text = "1080";
        }

        canvasScaler.referenceResolution = new Vector2(canvasScaler.referenceResolution.x, resoWidth);
    }
    IEnumerator PlayBDayVid()
    {
        AudioManager.Instance.audioSource.Stop();

        previousCommands.text = "Playing video in... 3";
        yield return new WaitForSecondsRealtime(1f);

        previousCommands.text = "Playing video in... 2";
        yield return new WaitForSecondsRealtime(1f);

        previousCommands.text = "Playing video in... 1";
        yield return new WaitForSecondsRealtime(1f);

        previousCommands.text = "Did you enjoy the video?";
        inputField.text = "Enter command...";
        input = null;

        bdayObj.SetActive(true);

        float length = videoPlayer.frameCount - 1;
        while (true)
        {            
            float currentLength = videoPlayer.frame;

            print("current length: " + currentLength);
            print("total: " + length);

            if (currentLength == length)
            {
                bdayObj.SetActive(false);
                break;
            }

            yield return new WaitForSeconds(2f);
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
                StartCoroutine(PlayBDayVid());
                break;
            case "your mom":
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
            case "putang ina":
                previousCommands.text = "ano ba? pinisil ko ung ina mo kanina";
                break;
            case "close":
                previousCommands.text = "Awaiting command...";
                inputField.text = "Enter command...";
                input = null;
                commandPrompt.SetActive(false);
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
        DataPersistenceManager.Instance.SaveGame();
        continueButton.interactable = true;

        PlayerPrefs.SetInt(canCustomNight, 0);

        SceneManager.LoadScene(loadScene);
    }
}
