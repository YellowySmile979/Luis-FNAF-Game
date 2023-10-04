using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Night Progress")]
    public Text time;

    [Header("Battery")]
    public Text batteryText;

    [Header("Usage")]
    public Image bar1;
    public Image bar2, bar3, bar4;

    [Header("Vent Locks")]
    public Image cam2LockUi; 
    public Image cam3LockUi, cam4LockUi, cam6LockUi, cam7LockUi;
    public Button cam2LockButton, cam3LockButton, cam4LockButton, cam6LockButton, cam7LockButton;
    public Color green, red;

    [Header("Songs")]
    public Image songProgress;
    public Text songPlayingName, pauseText;

    [Header("Cam Name")]
    public Text camName;

    public static UIManager Instance;

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
        cam2LockUi.color = red;
        cam3LockUi.color = red;
        cam4LockUi.color = red;
        cam6LockUi.color = red;
        cam7LockUi.color = red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    float setTime;
    //handles the display for the night time
    public void NightTimerProgress(float theTime)
    {
        if(theTime >= 300)
        {
            setTime = 12;
        }
        else if(theTime < 300 && theTime > 240)
        {
            setTime = 1;
        }
        else if(theTime <= 240 && theTime > 180)
        {
            setTime = 2;
        }
        else if(theTime <= 180 && theTime > 120)
        {
            setTime = 3;
        }
        else if(theTime <= 120 && theTime > 60)
        {
            setTime = 4;
        }
        else if(theTime <= 60 && theTime > 0)
        {
            setTime = 5;
        }
        else if(theTime <= 0)
        {
            setTime = 6;
        }
        time.text = setTime.ToString() + "am";
    }
    float batteryPercentage;
    //handles the battery percentage
    public void BatteryPercentage(float battPercent)
    {       
        batteryPercentage = battPercent / 10;
        batteryText.text = Mathf.Round(batteryPercentage) + "%";
    }
    //handles the usage bar and displaying the usage of power
    public void UsageBar(float usageNumber)
    {
        switch (usageNumber)
        {
            case 1:
                bar1.enabled = true;
                bar2.enabled = false;
                bar3.enabled = false;
                bar4.enabled = false;
                break;
            case 2:
                bar1.enabled = true;
                bar2.enabled = true;
                bar3.enabled = false;
                bar4.enabled = false;
                break;
            case 3:
                bar1.enabled = true;
                bar2.enabled = true;
                bar3.enabled = true;
                bar4.enabled = false;
                break;
            case 4:
                bar1.enabled = true;
                bar2.enabled = true;
                bar3.enabled = true;
                bar4.enabled = true;
                break;
        }
    }
    //handles which button is in effect
    //cam2Lock: 0, cam3Lock: 1, cam4Lock: 2, cam6Lock: 3, cam7Lock: 4, cam without a lock: 5
    public void ChosenVentLock(float chosenVentLockNo)
    {
        if (chosenVentLockNo == 0)
        {
            cam2LockButton.gameObject.SetActive(true);
            cam3LockButton.gameObject.SetActive(false);
            cam4LockButton.gameObject.SetActive(false);
            cam6LockButton.gameObject.SetActive(false);
            cam7LockButton.gameObject.SetActive(false);
        }
        else if (chosenVentLockNo == 1)
        {
            cam2LockButton.gameObject.SetActive(false);
            cam3LockButton.gameObject.SetActive(true);
            cam4LockButton.gameObject.SetActive(false);
            cam6LockButton.gameObject.SetActive(false);
            cam7LockButton.gameObject.SetActive(false);
        }
        else if (chosenVentLockNo == 2)
        {
            cam2LockButton.gameObject.SetActive(false);
            cam3LockButton.gameObject.SetActive(false);
            cam4LockButton.gameObject.SetActive(true);
            cam6LockButton.gameObject.SetActive(false);
            cam7LockButton.gameObject.SetActive(false);
        }
        else if (chosenVentLockNo == 3)
        {
            cam2LockButton.gameObject.SetActive(false);
            cam3LockButton.gameObject.SetActive(false);
            cam4LockButton.gameObject.SetActive(false);
            cam6LockButton.gameObject.SetActive(true);
            cam7LockButton.gameObject.SetActive(false);
        }
        else if (chosenVentLockNo == 4)
        {
            cam2LockButton.gameObject.SetActive(false);
            cam3LockButton.gameObject.SetActive(false);
            cam4LockButton.gameObject.SetActive(false);
            cam6LockButton.gameObject.SetActive(false);
            cam7LockButton.gameObject.SetActive(true);
        }
        else if (chosenVentLockNo == 5)
        {
            cam2LockButton.gameObject.SetActive(false);
            cam3LockButton.gameObject.SetActive(false);
            cam4LockButton.gameObject.SetActive(false);
            cam6LockButton.gameObject.SetActive(false);
            cam7LockButton.gameObject.SetActive(false);
        }
    }
    //handles the song player
    public void SongPlayer(float progressOfSong, float totalDuration, string nameOfSong)
    {
        songProgress.fillAmount = progressOfSong / totalDuration;
        songPlayingName.text = nameOfSong;
    }
    public void ChangeCamName(CamType type)
    {
        string name = null;
        switch (type) 
        {
            case CamType.MainStage:
                name = "Main Stage";
                break;
            case CamType.MainHall1:
                name = "Main Hall 1";
                break;
            case CamType.MainHall2:
                name = "Main Hall 2";
                break;
            case CamType.PartyRoom:
                name = "Party Room";
                break;
            case CamType.PartsAndService:
                name = "Parts & Service";
                break;
            case CamType.Kitchen:
                name = "Kitchen";
                break;
            case CamType.EastHallway:
                name = "East Hallway";
                break;
            case CamType.WestHallway:
                name = "West Hallway";
                break;
            case CamType.Storage:
                name = "Storage";
                break;
            case CamType.Entrance:
                name = "Entrance";
                break;
            case CamType.MainHall1Vent:
                name = "Main Hall 1 Vent";
                break;
            case CamType.MainHall2Vent:
                name = "Main Hall 2 Vent";
                break;
            case CamType.PartyRoomVent:
                name = "Party Room Vent";
                break;
            case CamType.PartsAndServiceVent:
                name = "Parts & Service Vent";
                break;
            case CamType.KitchenVent:
                name = "Kitchen Vent";
                break;
            case CamType.EastHallwayVent:
                name = "East Hallway Vent";
                break;
            case CamType.WestHallwayVent:
                name = "West Hallway Vent";
                break;
            case CamType.StorageVent:
                name = "Storage Vent";
                break;
        }
        camName.text = name + " Cam";
    }
}
