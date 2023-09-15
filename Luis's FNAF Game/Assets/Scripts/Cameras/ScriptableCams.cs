using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableCams", menuName = "camData/camData")]
public class ScriptableCams : ScriptableObject
{
    public CamType camType;

    public Sprite bg1;
    public Sprite bg2;
}
