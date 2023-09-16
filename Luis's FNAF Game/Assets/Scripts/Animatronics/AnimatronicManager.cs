using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatronicManager : MonoBehaviour
{
    [Header("Checks")]
    public bool allAnimsCanAttack;

    [Header("Animatronics")]
    public GameObject mia;
    public GameObject shaun, jade, elijah, enQi;

    [Header("Prevention Measures")]
    public bool isLeftDoorClosed = false;
    public bool isRightDoorClosed = false;

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
    //handles the closing and opening of left door
    public void LeftDoor()
    {
        isLeftDoorClosed = !isLeftDoorClosed;
        //play anim for closed door
    }
    //handles the closing and opening of right door
    public void RightDoor()
    {
        isRightDoorClosed = !isRightDoorClosed;
        //play anim for closed door
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
