using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game State")]
    public GameState GameState;

    [Header("Night Progress")]
    bool nightHasStarted = false;
    public float maxNightTime = 300f;
    [SerializeField] float nightTime;

    [Header("Power")]
    public float maxPower = 1000f;
    public float power;
    public float usage = 1f;

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
            if(nightNumber < 6) nightNumber++;
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
