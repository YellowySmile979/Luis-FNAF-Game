using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamSystemManager : MonoBehaviour
{
    [Header("Moniter")]
    public GameObject moniter;
    public bool openOrClose = false;

    [Header("Cams")]
    public GameObject moniterBG;
    public List<ScriptableCams> camBGs = new List<ScriptableCams>();
    public float maxRandomNumber = 10;

    public List<Button> camButtons = new List<Button>();

    public static CamSystemManager Instance;

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
    //handles the turning on or off of the moniter
    public void TurnOffOnMoniter()
    {
        openOrClose = !openOrClose;
        if (openOrClose)
        {
            moniter.SetActive(true);
        }
        else
        {
            moniter.SetActive(false);
        }
    }
    //checks to see which cam is activated and prevent that cam from being able to be activated again
    public void ActivatedCam(CamType camtype)
    {
        switch (camtype)
        {
            case CamType.MainStage:
                camButtons[0].interactable = false;
                for (int i = 0; i < camButtons.Count; i++)
                {
                    if(i == 0)
                    {
                        continue;
                    }
                    camButtons[i].interactable = true;
                }
                break;
            case CamType.MainHall1:
                camButtons[1].interactable = false;
                for (int i = 0; i < camButtons.Count; i++)
                {
                    if (i == 1)
                    {
                        continue;
                    }
                    camButtons[i].interactable = true;
                }
                break;
            case CamType.MainHall2:
                camButtons[2].interactable = false;
                for (int i = 0; i < camButtons.Count; i++)
                {
                    if (i == 2)
                    {
                        continue;
                    }
                    camButtons[i].interactable = true;
                }
                break;
            case CamType.PartyRoom:
                camButtons[8].interactable = false;
                for (int i = 0; i < camButtons.Count; i++)
                {
                    if (i == 8)
                    {
                        continue;
                    }
                    camButtons[i].interactable = true;
                }
                break;
            case CamType.PartsAndService:
                camButtons[3].interactable = false;
                for (int i = 0; i < camButtons.Count; i++)
                {
                    if (i == 3)
                    {
                        continue;
                    }
                    
                    camButtons[i].interactable = true;
                }
                break;
            case CamType.Kitchen:
                camButtons[4].interactable = false;
                for (int i = 0; i < camButtons.Count; i++)
                {
                    if (i == 4)
                    {
                        continue;
                    }
                    print("FIre");
                    camButtons[i].interactable = true;
                }
                break;
            case CamType.EastHallway:
                camButtons[5].interactable = false;
                for (int i = 0; i < camButtons.Count; i++)
                {
                    if (i == 5)
                    {
                        continue;
                    }
                    camButtons[i].interactable = true;
                }
                break;
            case CamType.WestHallway:
                camButtons[6].interactable = false;
                for (int i = 0; i < camButtons.Count; i++)
                {
                    if (i == 6)
                    {
                        continue;
                    }
                    camButtons[i].interactable = true;
                }
                break;
            case CamType.Storage:
                camButtons[7].interactable = false;
                for (int i = 0; i < camButtons.Count; i++)
                {
                    if (i == 7)
                    {
                        continue;
                    }
                    camButtons[i].interactable = true;
                }
                break;
            case CamType.Entrance:
                camButtons[9].interactable = false;
                for (int i = 0; i < camButtons.Count; i++)
                {
                    if (i == 9)
                    {
                        continue;
                    }
                    camButtons[i].interactable = true;
                }
                break;
        }
    }
    //this entire section below this comment is to handle the cam and the buttons
    public void MainStageCam()
    {
        float number;
        if(camBGs.Find(s => s.camType == CamType.MainStage))
        {
            //randomises which bg it is
            number = Random.Range(0, maxRandomNumber);
            if (camBGs[0].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[0].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[0].bg2;
                }
            }
        }
        ActivatedCam(CamType.MainStage);
    }
    public void MainHallCam1()
    {
        float number;
        if (camBGs.Find(s => s.camType == CamType.MainHall1))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camBGs[1].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[1].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[1].bg2;
                }
            }
        }
        ActivatedCam(CamType.MainHall1);
    }
    public void MainHallCam2()
    {
        float number;
        if (camBGs.Find(s => s.camType == CamType.MainHall2))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camBGs[2].bg2 != null)
            {
                if ((number < maxRandomNumber / 2) && camBGs[2].bg2 != null)
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[2].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[2].bg2;
                }
            }
        }
        ActivatedCam(CamType.MainHall2);
    }
    public void PartsAndServiceCam()
    {
        float number;
        if (camBGs.Find(s => s.camType == CamType.PartsAndService))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camBGs[3].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[3].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[3].bg2;
                }
            }
        }
        ActivatedCam(CamType.PartsAndService);
    }
    public void KitchenCam()
    {
        float number;
        if (camBGs.Find(s => s.camType == CamType.Kitchen))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camBGs[4].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[4].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[4].bg2;
                }
            }
        }
        ActivatedCam(CamType.Kitchen);
    }
    public void EastHallwayCam()
    {
        float number;
        if (camBGs.Find(s => s.camType == CamType.EastHallway))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camBGs[5].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[5].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[5].bg2;
                }
            }
        }
        ActivatedCam(CamType.EastHallway);
    }
    public void WestHallwayCam()
    {
        float number;
        if (camBGs.Find(s => s.camType == CamType.WestHallway))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camBGs[6].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[6].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[6].bg2;
                }
            }           
        }
        ActivatedCam(CamType.WestHallway);
    }
    public void StorageCam()
    {
        float number;
        if (camBGs.Find(s => s.camType == CamType.Storage))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camBGs[7].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[7].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[7].bg2;
                }
            }            
        }
        ActivatedCam(CamType.Storage);
    }
    public void PartyRoomCam()
    {
        float number;
        if (camBGs.Find(s => s.camType == CamType.PartyRoom))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camBGs[8].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[8].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[8].bg2;
                }
            }            
        }
        ActivatedCam(CamType.PartyRoom);
    }
    public void EntranceCam()
    {
        float number;
        if (camBGs.Find(s => s.camType == CamType.Entrance))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camBGs[9].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[9].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camBGs[9].bg2;
                }
            }           
        }
        ActivatedCam(CamType.Entrance);
    }
}
