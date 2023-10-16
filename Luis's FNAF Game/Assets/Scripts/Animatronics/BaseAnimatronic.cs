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
    public float setTimeToMove = 5f;
    [SerializeField] protected float timeToMove;
    protected bool isTriggerSong;

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
        OtherStart();
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
            MovementOpportunitiesForElijah();
        }
        else if (animatronicType == AnimatronicType.EnQi)
        {
            SongCheckForEnQi();
        }
    }

    public virtual void AnimatronicBehaviour()
    {

    }
    protected virtual void OtherStart()
    {

    }
    int aa = 0;
    //handles checks for EnQi
    void SongCheckForEnQi()
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
                    if(this.animatronicType == AnimatronicType.EnQi)
                    {
                        print("EnQi: " + randomNumber);
                        //increases a counter so that should the the chekcs fail too often, it will trigger
                        aa++;
                        if (aa > 10)
                        {
                            AnimatronicBehaviour();
                            aa = 0;
                            print("aa: " + aa);
                        }
                    }
                    if(randomNumber <= AILevel)
                    {
                        float randomNo = Random.Range(1, 100);
                        if(randomNo <= 50)
                        {
                            AnimatronicBehaviour();
                            aa = 0;
                        }
                        else
                        {
                            //do nothing
                            print("Song does not change");
                            aa++;
                        }
                    }
                    timeToMove = setTimeToMove;
                }
            }
        }
    }
    public float counter = 0;
    //handles checks for Elijah's MOVEMENT
    void MovementOpportunitiesForElijah()
    {
        if (AnimatronicManager.Instance.allAnimsCanAttack)
        {
            if (AILevel > 0)
            {
                if (timeToMove > 0)
                {
                    timeToMove -= Time.deltaTime;
                }
                else
                {
                    float randomNumber = Random.Range(1, 20);
                    if(this.animatronicType == AnimatronicType.Elijah)
                    {
                        print("Elijah: " + randomNumber);
                    }
                    if (randomNumber <= AILevel && !CamSystemManager.Instance.openOrClose)
                    {
                        print("counter has increased");
                        if(counter <= 5) counter++;
                        AnimatronicBehaviour();
                    }
                    timeToMove = setTimeToMove;
                }
            }
        }
    }
    int bb = 0;
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
                        //ensures that jade will move eventually
                        bb++;
                        if(bb >= 5)
                        {
                            bb = 0;
                            AnimatronicBehaviour();
                            print("bb: " + bb);
                        }
                    }
                    if (randomNumber <= AILevel)
                    {
                        AnimatronicBehaviour();
                        bb = 0;
                    }
                    timeToMove = setTimeToMove;
                }
            }
        }
    }
    int cc = 0;
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
                            //ensures that mia eventually moves
                            cc++;
                            if(cc >= 10)
                            {
                                cc = 0;
                                AnimatronicBehaviour();
                                print("cc mia: " + cc);
                            }
                        }
                        else if(this.animatronicType == AnimatronicType.Shaun)
                        {
                            print("Shaun: " + randomNumber);
                            //ensures shaun eventually moves
                            cc++;
                            if (cc >= 10)
                            {
                                cc = 0;
                                AnimatronicBehaviour();
                                print("cc shaun: " + cc);
                            }
                        }
                        if (randomNumber <= AILevel)
                        {
                            AnimatronicBehaviour();
                            cc = 0;
                        }
                        timeToMove = setTimeToMove;
                    }
                }
            }
        }
    }
}
