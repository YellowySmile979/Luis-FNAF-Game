using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CamData", menuName = "ScriptableCams/CamData")]
public class ScriptableCams : ScriptableObject
{
    public CamType camType;

    public Sprite bg1;
    public Sprite bg2;
}
