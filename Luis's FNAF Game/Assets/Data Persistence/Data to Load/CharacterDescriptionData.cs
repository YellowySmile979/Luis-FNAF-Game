using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterDescriptionData
{
    public string characterDescription;
    public string characterName;
    public int chosenCharacter;

    public Dictionary<int, string> descriptions;
    public Dictionary<int, string> names;

    //the values defined in this constructor will be the default values
    //the game starts with when there is no data to load
    public CharacterDescriptionData()
    {
        this.characterDescription = "Default text";
        this.characterName = "Name";
        this.chosenCharacter = 0;

        descriptions = new Dictionary<int, string>();
        names = new Dictionary<int, string>();
    }
}
