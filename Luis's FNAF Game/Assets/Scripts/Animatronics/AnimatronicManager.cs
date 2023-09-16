using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatronicManager : MonoBehaviour
{
    [Header("Checks")]
    public bool allAnimsCanAttack;
    

    public static AnimatronicManager Instance;

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
}
public enum AnimatronicType
{
    Mia,
    Shaun,
    Jade,
    Elijah,
    EnQi
}
