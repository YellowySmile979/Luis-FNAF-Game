using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    void LoadData(CharacterDescriptionData data);
    void SaveData(ref CharacterDescriptionData data);
}
