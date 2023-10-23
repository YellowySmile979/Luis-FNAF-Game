using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    //filepath: C:\Users\xcant\AppData\LocalLow\DefaultCompany\Luis's FNAF Game

    [Header("File Storage Config")]
    [SerializeField] string fileName;

    CharacterDescriptionData characterDescriptionData;
    List<IDataPersistence> dataPersistenceObjects;
    FileDataHandler dataHandler;

    public static DataPersistenceManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than 1 Data Persistence Manager in scene");
        }
        Instance = this;
    }
    void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    void OnApplicationQuit()
    {
        SaveGame();
    }

    public void NewGame()
    {
        this.characterDescriptionData = new CharacterDescriptionData();
    }

    public void LoadGame()
    {
        //load any saved data from a file using the data handler
        this.characterDescriptionData = dataHandler.Load();

        if (this.characterDescriptionData == null)
        {
            Debug.Log("No data was found. Initialising data to defaults");
            NewGame();
        }

        //push the loaded data to all other scripts that we need it
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(characterDescriptionData);
        }
    }

    public void SaveGame()
    {
        //pass the data to other scripts so they can update it
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref characterDescriptionData);
        }

        //save that data to a file using the data handler
        dataHandler.Save(characterDescriptionData);
    }

    List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
