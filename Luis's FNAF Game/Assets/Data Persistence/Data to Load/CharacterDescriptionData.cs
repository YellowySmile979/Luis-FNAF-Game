using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterDescriptionData
{
    public string characterDescription;
    public int chosenCharacter;
    public float night;

    public SerialisableDictionary<int, string> descriptions;

    //the values defined in this constructor will be the default values
    //the game starts with when there is no data to load
    public CharacterDescriptionData()
    {
        this.characterDescription = "Default text";
        this.chosenCharacter = 0;
        this.night = 0;

        descriptions = new SerialisableDictionary<int, string>();
    }
}
