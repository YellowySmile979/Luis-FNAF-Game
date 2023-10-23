using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    string dataDirPath = "";
    string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public CharacterDescriptionData Load()
    {
        //use Path.Combine to account for diff OS's having diff path separators
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        CharacterDescriptionData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                //load the serialised data from the file
                string dataToLoad = "";
                using(FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //deserialise the data from JSOn back into the C# object
                loadedData = JsonUtility.FromJson<CharacterDescriptionData>(dataToLoad);
            }
            catch(Exception e)
            {
                Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(CharacterDescriptionData data)
    {
        //use Path.Combine to account for diff OS's having diff path separators
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            //create the directory the file will be written to if it doesn't exist already
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //serialize the C# game data into JSOn
            string dataToStore = JsonUtility.ToJson(data, true);

            //write the serialized data to the file
            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch(Exception e)
        {
            Debug.LogError("Error occured while trying to save data to file: " + fullPath + "\n" + e);
        }
    }
}
