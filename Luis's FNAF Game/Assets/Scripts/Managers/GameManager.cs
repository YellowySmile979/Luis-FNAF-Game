using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour, IDataPersistence
{
    [Header("Game State")]
    public GameState GameState;

    [Header("Night Progress")]
    bool nightHasStarted = false;
    public float maxNightTime = 300f;
    [SerializeField] float nightTime;
    [SerializeField] float nightNumber;

    [Header("Power")]
    public float maxPower = 1000f;
    public float power;
    public float usage = 1f;

    [Header("Start/End")]
    public GameObject fadeIn;

    [Header("L Moment")]
    public GameObject lMomentVid;
    public VideoPlayer videoPlayer;

    public static GameManager Instance;

    //essentially handles the dev commands of this game
    void SpecialCommands()
    {
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.SetFloat("Night", 0);
        }*/
        if (Input.GetKey(KeyCode.C))
        {
            if (Input.GetKey(KeyCode.G))
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    GameState = GameState.Win;
                }
                else if (Input.GetKeyDown(KeyCode.L))
                {
                    GameState = GameState.Lose;
                }
                else if (Input.GetKeyDown(KeyCode.P))
                {
                    power = 0;
                }
                else if (Input.GetKeyDown(KeyCode.J))
                {
                    GameState = GameState.Dying;
                }
            }
        }
    }
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameState = GameState.Start;
        nightTime = maxNightTime;
        power = maxPower;
    }
    bool skullEmoji = false, fired = false;
    // Update is called once per frame
    void Update()
    {
        SpecialCommands();

        if(nightHasStarted && !skullEmoji)
        {
            Night();
            AnimatronicManager.Instance.UpdateAILevels(nightTime);
            Power();
        }

        if (GameState == GameState.Start)
        {
            StartCoroutine(FadeIn());
        }
        else if(GameState == GameState.NotDeadYet)
        {
            nightHasStarted = true;
            AnimatronicManager.Instance.allAnimsCanAttack = true;
        }
        else if(GameState == GameState.Win)
        {
            AnimatronicManager.Instance.allAnimsCanAttack = false;
            AudioManager.Instance.audioSource.Stop();

            if (!fired)
            {
                float nightNumber = PlayerPrefs.GetFloat("Night");
                if (nightNumber == 1) nightNumber = 1;
                if (nightNumber < 6) nightNumber++;
                this.nightNumber = nightNumber;
                print("Next Night: " + this.nightNumber);
                DataPersistenceManager.Instance.SaveGame();
                PlayerPrefs.SetFloat("Night", nightNumber);

                fired = true;
            }

            if (SceneManager.GetActiveScene().name == "Night 6")
            {
                PlayerPrefs.SetInt("Can Custom Night", 1);
            }
            //play win sequence
            StartCoroutine(FadeOut());
        }
        else if(GameState == GameState.Dying)
        {
            AnimatronicManager.Instance.allAnimsCanAttack = false;
            AudioManager.Instance.audioSource.Stop();
            skullEmoji = true;
            //play dying sequence depending on which animatronic jumpscares Luis
        }
        else if(GameState == GameState.Lose)
        {
            AnimatronicManager.Instance.allAnimsCanAttack = false;
            AudioManager.Instance.audioSource.Stop();
            skullEmoji = true;

            //happens if jump scare
            if(!fired)
            {
                if (AnimatronicManager.Instance.elijahAILevel == 20
                    && AnimatronicManager.Instance.miaAILevel == 20
                    && AnimatronicManager.Instance.jadeAILevel == 20
                    && AnimatronicManager.Instance.shaunAILevel == 20
                    && AnimatronicManager.Instance.enQiAILevel == 20
                    && SceneManager.GetActiveScene().name == "Custom Night")
                {
                    //plays funny video before actually ending the game
                    StartCoroutine(FadeOutLMoment());
                }
                else
                {
                    StartCoroutine(FadeOut());
                }

                fired = true;
            }
        }
        else if(GameState == GameState.PowerOutage)
        {
            AnimatronicManager.Instance.allAnimsCanAttack = false;
            AudioManager.Instance.audioSource.Stop();
            //play the lights out part
        }
    }

    //handles the night of the game
    void Night()
    {
        nightTime -= Time.deltaTime;
        UIManager.Instance.NightTimerProgress(nightTime);
        if(nightTime <= 0)
        {
            GameState = GameState.Win;
        }
    }
    //handles the power of the game
    void Power()
    {
        if(power > 0)
        {
            power -= Time.deltaTime * usage;
            UIManager.Instance.BatteryPercentage(power);
            UIManager.Instance.UsageBar(usage);
        }
        else
        {
            GameState = GameState.PowerOutage;
        }
    }
    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(0.1f);
        float fadeInAlpha = fadeIn.GetComponent<Image>().color.a;
        if(fadeInAlpha > 0)
        {
            fadeInAlpha -= Time.deltaTime * 0.6f;
            fadeIn.GetComponent<Image>().color = new Color(fadeIn.GetComponent<Image>().color.r, fadeIn.GetComponent<Image>().color.g, fadeIn.GetComponent<Image>().color.b, fadeInAlpha);
        }
        else
        {
            GameState = GameState.NotDeadYet;
        }
    }
    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(0.1f);
        float fadeInAlpha = fadeIn.GetComponent<Image>().color.a;
        if(fadeInAlpha <= 0)
        {
            fadeInAlpha += Time.deltaTime * 0.3f;
            fadeIn.GetComponent<Image>().color = new Color(fadeIn.GetComponent<Image>().color.r,
                                                           fadeIn.GetComponent<Image>().color.g,
                                                           fadeIn.GetComponent<Image>().color.b,
                                                           fadeInAlpha);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    IEnumerator FadeOutLMoment()
    {
        yield return new WaitForSeconds(0.1f);
        float fadeInAlpha = fadeIn.GetComponent<Image>().color.a;
        if(fadeInAlpha <= 0)
        {
            fadeInAlpha += Time.deltaTime * 0.3f;
            fadeIn.GetComponent<Image>().color = new Color(fadeIn.GetComponent<Image>().color.r,
                                                           fadeIn.GetComponent<Image>().color.g,
                                                           fadeIn.GetComponent<Image>().color.b,
                                                           fadeInAlpha);
        }
        else
        {
            lMomentVid.SetActive(true);

            float length = videoPlayer.frameCount - 1;
            while (true)
            {
                float currentLength = videoPlayer.frame;

                print("current length: " + currentLength);
                print("total: " + length);

                if (currentLength == length)
                {
                    lMomentVid.SetActive(false);
                    break;
                }

                yield return new WaitForSeconds(2f);
            }
        }
    }

    public void LoadData(CharacterDescriptionData data)
    {
        //not needed
    }
    public void SaveData(ref CharacterDescriptionData data)
    {
        data.night = this.nightNumber;
    }
}
public enum GameState
{
    Start,
    Win,
    Lose,
    Dying,
    NotDeadYet,
    PowerOutage
}
public enum CamType
{
    MainStage,
    MainHall1,
    MainHall2,
    PartyRoom,
    PartsAndService,
    Kitchen,
    EastHallway,
    WestHallway,
    Storage,
    Entrance,

    MainHall1Vent,
    MainHall2Vent,
    PartyRoomVent,
    PartsAndServiceVent,
    KitchenVent,
    EastHallwayVent,
    WestHallwayVent,
    StorageVent
}
