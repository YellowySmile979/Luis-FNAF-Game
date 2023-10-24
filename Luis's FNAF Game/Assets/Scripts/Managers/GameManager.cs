using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IDataPersistence
{
    [Header("Game State")]
    public GameState GameState;

    [Header("Night Progress")]
    bool nightHasStarted = false;
    public float maxNightTime = 300f;
    [SerializeField] float nightTime;
    float nightNumber;

    [Header("Power")]
    public float maxPower = 1000f;
    public float power;
    public float usage = 1f;

    [Header("Start")]
    public GameObject fadeIn;

    public static GameManager Instance;

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
    bool skullEmoji = false;
    // Update is called once per frame
    void Update()
    {
        if(nightHasStarted && !skullEmoji)
        {
            Night();
            AnimatronicManager.Instance.UpdateAILevels(nightTime);
            Power();
        }

        if (GameState == GameState.Start)
        {
            GameState = GameState.NotDeadYet;
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

            float nightNumber = PlayerPrefs.GetFloat("Night");
            if (nightNumber == 1) nightNumber = 1;
            if(nightNumber < 6) nightNumber++;            
            this.nightNumber = nightNumber;
            print("Next Night: " + this.nightNumber);
            DataPersistenceManager.Instance.SaveGame();
            PlayerPrefs.SetFloat("Night", nightNumber);

            //play win sequence
            SceneManager.LoadScene("MainMenu");
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

            if(SceneManager.GetActiveScene().name == "Night 6")
            {
                PlayerPrefs.SetInt("Can Custom Night", 1);
            }
            //happens if jump scare
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
        yield return new WaitForSeconds(1f);
        fadeIn.GetComponent<Image>().color = new Color(fadeIn.GetComponent<Image>().color.r, fadeIn.GetComponent<Image>().color.g, fadeIn.GetComponent<Image>().color.b, fadeIn.GetComponent<Image>().color.a);
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
