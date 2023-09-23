using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamSystemManager : MonoBehaviour
{
    [Header("Moniter")]
    public GameObject moniter;
    public bool openOrClose = false;
    bool hasSentInitialCam;

    public Button ventButton, mainButton;
    public GameObject ventSys, mainSys;
    public bool ventCam = false;

    public GameObject leftSideStuff, rightSideStuff;

    public GameObject songPlayer;

    [Header("Cams")]
    public GameObject moniterBG;
    public List<ScriptableCams> camMainBgs = new List<ScriptableCams>();
    public List<ScriptableCams> camVentBgs = new List<ScriptableCams>();
    public float maxRandomNumber = 10;

    public List<Button> camMainButtons = new List<Button>();
    public List<Button> ventCamButtons = new List<Button>();

    public static CamSystemManager Instance;

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
        PartsAndServiceVent();
        MainStageCamMain();
        songPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //shows the song player
    public void ShowSongPlayer()
    {
        songPlayer.SetActive(true);
    }
    //skips the song forward by 1
    public void SkipForward()
    {
        EnQiAnimatronic enQiAnimatronic = FindObjectOfType<EnQiAnimatronic>();
        AudioClip clip = AudioManager.Instance.audioSource.clip;
        int index = enQiAnimatronic.listOfAllSongs.FindIndex(0, enQiAnimatronic.listOfAllSongs.Count, s => s == clip);
        
        index++;
        print("Forward Index: " + index);

        if (index < 0)
        {
            index = enQiAnimatronic.listOfAllSongs.Count;
        }
        else if(index > enQiAnimatronic.listOfAllSongs.Count)
        {
            index = 0;
        }
        enQiAnimatronic.audioClip = enQiAnimatronic.listOfAllSongs[index];
        enQiAnimatronic.EnQiMovement(true);
    }
    //skips the song backward by 1
    public void SkipBackward()
    {
        EnQiAnimatronic enQiAnimatronic = FindObjectOfType<EnQiAnimatronic>();
        AudioClip clip = AudioManager.Instance.audioSource.clip;
        int index = enQiAnimatronic.listOfAllSongs.FindIndex(0, enQiAnimatronic.listOfAllSongs.Count, s => s == clip);
        
        index--;
        print("Backward Index: " + index);

        if (index < 0)
        {
            index = enQiAnimatronic.listOfAllSongs.Count;
        }
        else if (index > enQiAnimatronic.listOfAllSongs.Count)
        {
            index = 0;
        }
        enQiAnimatronic.audioClip = enQiAnimatronic.listOfAllSongs[index];
        enQiAnimatronic.EnQiMovement(true);
    }
    CamType typeOfCamMain, typeOfCamVent;
    //handles which cam to turn on
    public void VentCamOrMainCam()
    {
        ventCam = !ventCam;
        if (!ventCam)
        {
            mainButton.interactable = false;
            ventButton.interactable = true;
            mainSys.SetActive(true);
            ventSys.SetActive(false);            
        }
        else
        {
            ventButton.interactable = false;
            mainButton.interactable = true;
            mainSys.SetActive(false);
            ventSys.SetActive(true);
        }
    }
    //handles the turning on or off of the moniter
    public void TurnOffOnMoniter()
    {
        openOrClose = !openOrClose;
        if (openOrClose)
        {
            moniter.SetActive(true);
            GameManager.Instance.usage++;
            leftSideStuff.SetActive(false);
            rightSideStuff.SetActive(false);
        }
        else
        {
            moniter.SetActive(false);
            GameManager.Instance.usage--;
            leftSideStuff.SetActive(true);
            rightSideStuff.SetActive(true);
        }
        //sets the initial cam that the player would be looking at
        if (!hasSentInitialCam)
        {
            ActivatedCam(CamType.MainStage);
            hasSentInitialCam = true;
        }
    }
    //checks to see which cam is activated and prevent that cam from being able to be activated again
    public void ActivatedCam(CamType camtype)
    {
        switch (camtype)
        {
            case CamType.MainStage:
                camMainButtons[0].interactable = false;
                for (int i = 0; i < camMainButtons.Count; i++)
                {
                    if(i == 0)
                    {
                        continue;
                    }
                    camMainButtons[i].interactable = true;
                }
                songPlayer.SetActive(false);
                break;
            case CamType.MainHall1:
                camMainButtons[1].interactable = false;
                for (int i = 0; i < camMainButtons.Count; i++)
                {
                    if (i == 1)
                    {
                        continue;
                    }
                    camMainButtons[i].interactable = true;
                }
                songPlayer.SetActive(false);
                break;
            case CamType.MainHall2:
                camMainButtons[2].interactable = false;
                for (int i = 0; i < camMainButtons.Count; i++)
                {
                    if (i == 2)
                    {
                        continue;
                    }
                    camMainButtons[i].interactable = true;
                }
                songPlayer.SetActive(false);
                break;
            case CamType.PartsAndService:
                camMainButtons[3].interactable = false;
                for (int i = 0; i < camMainButtons.Count; i++)
                {
                    if (i == 3)
                    {
                        continue;
                    }
                    
                    camMainButtons[i].interactable = true;
                }
                songPlayer.SetActive(false);
                break;
            case CamType.Kitchen:
                camMainButtons[4].interactable = false;
                for (int i = 0; i < camMainButtons.Count; i++)
                {
                    if (i == 4)
                    {
                        continue;
                    }
                    print("FIre");
                    camMainButtons[i].interactable = true;
                }
                songPlayer.SetActive(false);
                break;
            case CamType.EastHallway:
                camMainButtons[5].interactable = false;
                for (int i = 0; i < camMainButtons.Count; i++)
                {
                    if (i == 5)
                    {
                        continue;
                    }
                    camMainButtons[i].interactable = true;
                }
                songPlayer.SetActive(false);
                break;
            case CamType.WestHallway:
                camMainButtons[6].interactable = false;
                for (int i = 0; i < camMainButtons.Count; i++)
                {
                    if (i == 6)
                    {
                        continue;
                    }
                    camMainButtons[i].interactable = true;
                }
                songPlayer.SetActive(false);
                break;
            case CamType.Storage:
                camMainButtons[7].interactable = false;
                for (int i = 0; i < camMainButtons.Count; i++)
                {
                    if (i == 7)
                    {
                        continue;
                    }
                    camMainButtons[i].interactable = true;
                }
                //shows the song player
                ShowSongPlayer();
                break;
            case CamType.PartyRoom:
                camMainButtons[8].interactable = false;
                for (int i = 0; i < camMainButtons.Count; i++)
                {
                    if (i == 8)
                    {
                        continue;
                    }
                    camMainButtons[i].interactable = true;
                }
                songPlayer.SetActive(false);
                break;
            case CamType.Entrance:
                camMainButtons[9].interactable = false;
                for (int i = 0; i < camMainButtons.Count; i++)
                {
                    if (i == 9)
                    {
                        continue;
                    }
                    camMainButtons[i].interactable = true;
                }
                songPlayer.SetActive(false);
                break;
            case CamType.PartsAndServiceVent:
                ventCamButtons[0].interactable = false;
                UIManager.Instance.ChosenVentLock(5);
                for(int i = 0; i < ventCamButtons.Count; i++)
                {
                    if(i == 0)
                    {
                        continue;
                    }
                    ventCamButtons[i].interactable = true;
                }
                songPlayer.SetActive(false);
                break;
            case CamType.MainHall1Vent:
                ventCamButtons[1].interactable = false;
                UIManager.Instance.ChosenVentLock(0);
                for (int i = 0; i < ventCamButtons.Count; i++)
                {
                    if (i == 1)
                    {
                        continue;
                    }
                    ventCamButtons[i].interactable = true;
                }
                songPlayer.SetActive(false);
                break;
            case CamType.MainHall2Vent:
                ventCamButtons[2].interactable = false;
                UIManager.Instance.ChosenVentLock(1);
                for (int i = 0; i < ventCamButtons.Count; i++)
                {
                    if (i == 2)
                    {
                        continue;
                    }
                    ventCamButtons[i].interactable = true;
                }
                songPlayer.SetActive(false);
                break;
            case CamType.KitchenVent:
                ventCamButtons[3].interactable = false;
                UIManager.Instance.ChosenVentLock(2);
                for (int i = 0; i < ventCamButtons.Count; i++)
                {
                    if (i == 3)
                    {
                        continue;
                    }
                    ventCamButtons[i].interactable = true;
                }
                songPlayer.SetActive(false);
                break;
            case CamType.PartyRoomVent:
                ventCamButtons[4].interactable = false;
                UIManager.Instance.ChosenVentLock(5);
                for (int i = 0; i < ventCamButtons.Count; i++)
                {
                    if (i == 4)
                    {
                        continue;
                    }
                    ventCamButtons[i].interactable = true;
                }
                songPlayer.SetActive(false);
                break;
            case CamType.EastHallwayVent:
                ventCamButtons[5].interactable = false;
                UIManager.Instance.ChosenVentLock(3);
                for (int i = 0; i < ventCamButtons.Count; i++)
                {
                    if (i == 5)
                    {
                        continue;
                    }
                    ventCamButtons[i].interactable = true;
                }
                songPlayer.SetActive(false);
                break;
            case CamType.WestHallwayVent:
                ventCamButtons[6].interactable = false;
                UIManager.Instance.ChosenVentLock(4);
                for (int i = 0; i < ventCamButtons.Count; i++)
                {
                    if (i == 6)
                    {
                        continue;
                    }
                    ventCamButtons[i].interactable = true;
                }
                songPlayer.SetActive(false);
                break;
            case CamType.StorageVent:
                ventCamButtons[7].interactable = false;
                UIManager.Instance.ChosenVentLock(5);
                for (int i = 0; i < ventCamButtons.Count; i++)
                {
                    if (i == 7)
                    {
                        continue;
                    }
                    ventCamButtons[i].interactable = true;
                }
                songPlayer.SetActive(false);
                break;
        }
    }
    //this entire section below this comment is to handle the cam and the buttons
    public void MainStageCamMain()
    {
        float number;
        if(camMainBgs.Find(s => s.camType == CamType.MainStage))
        {
            //randomises which bg it is
            number = Random.Range(0, maxRandomNumber);
            if (camMainBgs[0].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camMainBgs[0].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camMainBgs[0].bg2;
                }
            }
        }
        ActivatedCam(CamType.MainStage);
    }
    public void MainHallCam1Main()
    {
        float number;
        if (camMainBgs.Find(s => s.camType == CamType.MainHall1))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camMainBgs[1].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camMainBgs[1].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camMainBgs[1].bg2;
                }
            }
        }
        ActivatedCam(CamType.MainHall1);
    }
    [HideInInspector] public Sprite mainHall2BG;
    public void MainHallCam2Main()
    {        
        if (camMainBgs.Find(s => s.camType == CamType.MainHall2))
        {
            moniterBG.GetComponent<Image>().sprite = mainHall2BG;
        }
        ActivatedCam(CamType.MainHall2);
    }
    public void PartsAndServiceCamMain()
    {
        float number;
        if (camMainBgs.Find(s => s.camType == CamType.PartsAndService))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camMainBgs[3].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camMainBgs[3].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camMainBgs[3].bg2;
                }
            }
        }
        ActivatedCam(CamType.PartsAndService);
    }
    public void KitchenCamMain()
    {
        float number;
        if (camMainBgs.Find(s => s.camType == CamType.Kitchen))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camMainBgs[4].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camMainBgs[4].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camMainBgs[4].bg2;
                }
            }
        }
        ActivatedCam(CamType.Kitchen);
    }
    public void EastHallwayCamMain()
    {
        float number;
        if (camMainBgs.Find(s => s.camType == CamType.EastHallway))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camMainBgs[5].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camMainBgs[5].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camMainBgs[5].bg2;
                }
            }
        }
        ActivatedCam(CamType.EastHallway);
    }
    [HideInInspector] public bool isRunningDownWestHallway;
    [HideInInspector] public Sprite westHallwayRunning;
    public void WestHallwayCamMain()
    {
        float number;
        if (!isRunningDownWestHallway)
        {
            if (camMainBgs.Find(s => s.camType == CamType.WestHallway))
            {
                number = Random.Range(0, maxRandomNumber);
                if (camMainBgs[6].bg2 != null)
                {
                    if (number < maxRandomNumber / 2)
                    {
                        moniterBG.GetComponent<Image>().sprite = camMainBgs[6].bg1;
                    }
                    else
                    {
                        moniterBG.GetComponent<Image>().sprite = camMainBgs[6].bg2;
                    }
                }
            }
        }
        else
        {
            if(FindObjectOfType<BaseAnimatronic>().counter == 5)
            {
                FindObjectOfType<BaseAnimatronic>().counter = 6;
            }

            moniterBG.GetComponent<Image>().sprite = westHallwayRunning;
        }
        ActivatedCam(CamType.WestHallway);
    }
    public void StorageCamMain()
    {
        float number;
        if (camMainBgs.Find(s => s.camType == CamType.Storage))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camMainBgs[7].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camMainBgs[7].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camMainBgs[7].bg2;
                }
            }            
        }
        ActivatedCam(CamType.Storage);
    }
    public void PartyRoomCamMain()
    {
        float number;
        if (camMainBgs.Find(s => s.camType == CamType.PartyRoom))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camMainBgs[8].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camMainBgs[8].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camMainBgs[8].bg2;
                }
            }            
        }
        ActivatedCam(CamType.PartyRoom);
    }
    public void EntranceCamMain()
    {
        float number;
        if (camMainBgs.Find(s => s.camType == CamType.Entrance))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camMainBgs[9].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camMainBgs[9].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camMainBgs[9].bg2;
                }
            }           
        }
        ActivatedCam(CamType.Entrance);
    }
    //vent section for buttons
    public void PartsAndServiceVent()
    {
        float number;
        if (camVentBgs.Find(s => s.camType == CamType.PartsAndServiceVent))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camVentBgs[0].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camVentBgs[0].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camVentBgs[0].bg2;
                }
            }
        }
        ActivatedCam(CamType.PartsAndServiceVent);
    }
    public void MainHall1Vent()
    {
        float number;
        if (camVentBgs.Find(s => s.camType == CamType.MainHall1Vent))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camVentBgs[1].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camVentBgs[1].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camVentBgs[1].bg2;
                }
            }
        }
        ActivatedCam(CamType.MainHall1Vent);
    }
    public void MainHall2Vent()
    {
        float number;
        if (camVentBgs.Find(s => s.camType == CamType.MainHall2Vent))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camVentBgs[2].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camVentBgs[2].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camVentBgs[2].bg2;
                }
            }
        }
        ActivatedCam(CamType.MainHall2Vent);
    }
    public void KitchenVent()
    {
        float number;
        if (camVentBgs.Find(s => s.camType == CamType.KitchenVent))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camVentBgs[3].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camVentBgs[3].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camVentBgs[3].bg2;
                }
            }
        }
        ActivatedCam(CamType.KitchenVent);
    }
    public void PartyRoomVent()
    {
        float number;
        if (camVentBgs.Find(s => s.camType == CamType.PartyRoomVent))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camVentBgs[4].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camVentBgs[4].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camVentBgs[4].bg2;
                }
            }
        }
        ActivatedCam(CamType.PartyRoomVent);
    }
    public void EastHallwayVent()
    {
        float number;
        if (camVentBgs.Find(s => s.camType == CamType.EastHallwayVent))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camVentBgs[5].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camVentBgs[5].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camVentBgs[5].bg2;
                }
            }
        }
        ActivatedCam(CamType.EastHallwayVent);
    }
    public void WestHallwayVent()
    {
        float number;
        if (camVentBgs.Find(s => s.camType == CamType.WestHallwayVent))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camVentBgs[6].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camVentBgs[6].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camVentBgs[6].bg2;
                }
            }
        }
        ActivatedCam(CamType.WestHallwayVent);
    }
    public void StorageVent()
    {
        float number;
        if (camVentBgs.Find(s => s.camType == CamType.StorageVent))
        {
            number = Random.Range(0, maxRandomNumber);
            if (camVentBgs[7].bg2 != null)
            {
                if (number < maxRandomNumber / 2)
                {
                    moniterBG.GetComponent<Image>().sprite = camVentBgs[7].bg1;
                }
                else
                {
                    moniterBG.GetComponent<Image>().sprite = camVentBgs[7].bg2;
                }
            }
        }
        ActivatedCam(CamType.StorageVent);
    }
}
