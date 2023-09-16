using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game State")]
    public GameState GameState;

    [Header("Night Progress")]
    bool nightHasStarted = false;
    public float maxNightTime = 300f;
    [SerializeField] float nightTime;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(nightHasStarted)
        {
            nightTime -= Time.deltaTime;
            UIManager.Instance.NightTimerProgress(nightTime);
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
        }
        else if(GameState == GameState.Dying)
        {
            AnimatronicManager.Instance.allAnimsCanAttack = false;
        }
        else if(GameState == GameState.Lose)
        {
            AnimatronicManager.Instance.allAnimsCanAttack = false;
        }
    }
}
public enum GameState
{
    Start,
    Win,
    Lose,
    Dying,
    NotDeadYet
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
    Entrance
}
