using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAnimatronic : MonoBehaviour
{
    [Header("Animatronic Data")]
    public ScriptableAnimatronic animatronicData;
    public AnimatronicType animatronicType;

    [Header("AI")]
    public float AILevel;
    public static float setTimeToMove = 5f;
    protected static float timeToMove;

    [Header("Places to Move")]
    public GameObject whereToStart;
    public GameObject whereIAmNow;
    public List<GameObject> listOfAllPlacesToMove = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        timeToMove = setTimeToMove;
        //sets the type of animatronic
        animatronicType = animatronicData.animatronicType;
        //sets the initial starting positions
        whereIAmNow = whereToStart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void AnimatronicBehaviour()
    {

    }
}
