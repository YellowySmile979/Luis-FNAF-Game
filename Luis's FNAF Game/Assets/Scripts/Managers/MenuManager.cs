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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //open/closes the settings
    public void OpenCloseSettings()
    {
        openOrCloseSettings = true;
        if (openOrCloseSettings)
        {
            settings.SetActive(true);
            for(int i = 0; i < listOfMainMenuStuff.Count; i++)
            {
                listOfMainMenuStuff[i].SetActive(false);
            }
        }
    }
    public void BackOutOfSettings()
    {
        openOrCloseSettings = false;
        if (!openOrCloseSettings)
        {
            settings.SetActive(false);
            for (int i = 0; i < listOfMainMenuStuff.Count; i++)
            {
                listOfMainMenuStuff[i].SetActive(true);
            }
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(loadScene);
    }
}
