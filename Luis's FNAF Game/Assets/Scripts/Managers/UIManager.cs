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

    public static UIManager Instance;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
}
