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
    [SerializeField] protected float timeToMove;

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
        switch (animatronicType)
        {
            case AnimatronicType.Mia:
                AnimatronicManager.Instance.mia.transform.position = whereToStart.transform.position;
                    break;
            case AnimatronicType.Shaun:
                AnimatronicManager.Instance.shaun.transform.position = whereToStart.transform.position;
                break;
            case AnimatronicType.Jade:
                AnimatronicManager.Instance.jade.transform.position = whereToStart.transform.position;
                break;
            case AnimatronicType.Elijah:
                AnimatronicManager.Instance.elijah.transform.position = whereToStart.transform.position;
                break;
            case AnimatronicType.EnQi:
                AnimatronicManager.Instance.enQi.transform.position = whereToStart.transform.position;
                break;
        }
        print("Start");
    }

    // Update is called once per frame
    void Update()
    {
        //handes the checks for the appropriate animatronic
        if(animatronicType == AnimatronicType.Mia || animatronicType == AnimatronicType.Shaun)
        {
            //print("Mia + Shaun");
            DoorChecksForMiaAndShaun();
        }
        else if(animatronicType == AnimatronicType.Jade)
        {
            //print("Jade");
            VentLockChecksForJade();
        }
        else if(animatronicType == AnimatronicType.Elijah)
        {

        }
        else if (animatronicType == AnimatronicType.EnQi)
        {

        }
    }

    public virtual void AnimatronicBehaviour()
    {

    }
    //handles checks for jade's movements and whatever
    void VentLockChecksForJade()
    {
        if (AnimatronicManager.Instance.allAnimsCanAttack)
        {
            if(AILevel > 0)
            {
                if(timeToMove > 0)
                {
                    timeToMove -= Time.deltaTime;
                }
                else
                {
                    float randomNumber = Random.Range(1, 20);
                    if (this.animatronicType == AnimatronicType.Jade)
                    {
                        print("Jade: " + randomNumber);
                    }
                    if (randomNumber <= AILevel)
                    {
                        AnimatronicBehaviour();
                    }
                    timeToMove = setTimeToMove;
                }
            }
        }
    }
    void DoorChecksForMiaAndShaun()
    {
        //handles checks for the movement and whatever
        if (AnimatronicManager.Instance.allAnimsCanAttack)
        {
            if (AILevel > 0)
            {
                if (!CamSystemManager.Instance.openOrClose)
                {
                    if (timeToMove > 0)
                    {
                        timeToMove -= Time.deltaTime;
                    }
                    else
                    {
                        float randomNumber = Random.Range(1, 20);
                        if(this.animatronicType == AnimatronicType.Mia)
                        {
                            print("Mia: " + randomNumber);
                        }
                        else if(this.animatronicType == AnimatronicType.Shaun)
                        {
                            print("Shaun: " + randomNumber);
                        }
                        if (randomNumber <= AILevel)
                        {
                            AnimatronicBehaviour();
                        }
                        timeToMove = setTimeToMove;
                    }
                }
            }
        }
    }
}
