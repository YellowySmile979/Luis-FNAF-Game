using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatronicManager : MonoBehaviour
{
    [Header("Checks")]
    public bool allAnimsCanAttack;
    public bool miaCanAttack, shaunCanAttack, jadeCanAttack, elijahCanAttack, enQiCanAttack;
    bool twelveAmPassed, oneAmPassed, twoAmPassed, threeAmPassed, fourAmPassed, fiveAmPassed, sixAmPassed;

    [Header("Animatronics")]
    public GameObject mia;
    public GameObject shaun, jade, elijah, enQi;

    public float miaAILevel, shaunAILevel, jadeAILevel, elijahAILevel, enQiAILevel;

    [Header("Prevention Measures")]
    public bool isLeftDoorClosed = false;
    public bool isRightDoorClosed = false;
    public GameObject leftDoor, rightDoor;

    public static AnimatronicManager Instance;

    void Awake()
    {
        Instance = this;
        //sets the animatronics if they havent already
        if (mia == null) mia = FindObjectOfType<MiaAnimatronic>(true).gameObject;
        if (shaun == null) shaun = FindObjectOfType<ShaunAnimatronic>(true).gameObject;
        if (jade == null) jade = FindObjectOfType<JadeAnimatronic>(true).gameObject;
        if (elijah == null) elijah = FindObjectOfType<ElijahAnimatronic>(true).gameObject;
        if (enQi == null) enQi = FindObjectOfType<EnQiAnimatronic>(true).gameObject;
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
        print("Close left door");
        leftDoor.SetActive(isLeftDoorClosed);
        if (isLeftDoorClosed)
        {
            GameManager.Instance.usage++;
        }
        else
        {
            GameManager.Instance.usage--;
        }
    }
    //handles the closing and opening of right door
    public void RightDoor()
    {
        isRightDoorClosed = !isRightDoorClosed;
        //play anim for closed door
        print("Close right door");
        rightDoor.SetActive(isRightDoorClosed);
        if (isRightDoorClosed)
        {
            GameManager.Instance.usage++;
        }
        else
        {
            GameManager.Instance.usage--;
        }
    }
    //handles the updating of each animatronic's ai levels
    public void UpdateAILevels(float theTime)
    {
        //adds 1 to the ai level of the aniamtronics every hour
        if (theTime >= 300 && !twelveAmPassed)
        {
            if (miaAILevel > 0) miaAILevel += 0;
            if (shaunAILevel > 0) shaunAILevel += 0;
            if (jadeAILevel > 0) jadeAILevel += 0;
            if (elijahAILevel > 0) elijahAILevel += 0;
            if (enQiAILevel > 0) enQiAILevel += 0;

            twelveAmPassed = true;
        }
        else if (theTime < 300 && theTime > 240 && !oneAmPassed)
        {
            if (miaAILevel > 0) miaAILevel += 0;
            if (shaunAILevel > 0) shaunAILevel += 0;
            if (jadeAILevel > 0) jadeAILevel += 0;
            if (elijahAILevel > 0) elijahAILevel += 0;
            if (enQiAILevel > 0) enQiAILevel += 0;

            oneAmPassed = true;
        }
        else if (theTime <= 240 && theTime > 180 && !twoAmPassed)
        {
            if (miaAILevel > 0) miaAILevel += 1;
            if (shaunAILevel > 0) shaunAILevel += 1;
            if (jadeAILevel > 0) jadeAILevel += 1;
            if (elijahAILevel > 0) elijahAILevel += 1;
            if (enQiAILevel > 0) enQiAILevel += 1;

            twoAmPassed = true;
        }
        else if (theTime <= 180 && theTime > 120 && !threeAmPassed)
        {
            if (miaAILevel > 0) miaAILevel += 1;
            if (shaunAILevel > 0) shaunAILevel += 1;
            if (jadeAILevel > 0) jadeAILevel += 1;
            if (elijahAILevel > 0) elijahAILevel += 1;
            if (enQiAILevel > 0) enQiAILevel += 1;

            threeAmPassed = true;
        }
        else if (theTime <= 120 && theTime > 60 && !fourAmPassed)
        {
            if (miaAILevel > 0) miaAILevel += 1;
            if (shaunAILevel > 0) shaunAILevel += 1;
            if (jadeAILevel > 0) jadeAILevel += 1;
            if (elijahAILevel > 0) elijahAILevel += 1;
            if (enQiAILevel > 0) enQiAILevel += 1;

            fourAmPassed = true;
        }
        else if (theTime <= 60 && theTime > 0 && !fiveAmPassed)
        {
            if (miaAILevel > 0) miaAILevel += 1;
            if (shaunAILevel > 0) shaunAILevel += 1;
            if (jadeAILevel > 0) jadeAILevel += 1;
            if (elijahAILevel > 0) elijahAILevel += 1;
            if (enQiAILevel > 0) enQiAILevel += 1;

            fiveAmPassed = true;
        }
        else if (theTime <= 0 && !sixAmPassed)
        {
            if (miaAILevel > 0) miaAILevel += 1;
            if (shaunAILevel > 0) shaunAILevel += 1;
            if (jadeAILevel > 0) jadeAILevel += 1;
            if (elijahAILevel > 0) elijahAILevel += 1;
            if (enQiAILevel > 0) enQiAILevel += 1;

            sixAmPassed = true;
        }

        //sets the ai level of each animatronic to the ai level received
        FindObjectOfType<MiaAnimatronic>().AILevel = miaAILevel;
        FindObjectOfType<ShaunAnimatronic>().AILevel = shaunAILevel;
        FindObjectOfType<JadeAnimatronic>().AILevel = jadeAILevel;
        FindObjectOfType<ElijahAnimatronic>().AILevel = elijahAILevel;
        FindObjectOfType<EnQiAnimatronic>().AILevel = enQiAILevel;

        //prevents the ai level from goign out of bounds
        if (miaAILevel >= 20) miaAILevel = 20;
        if (shaunAILevel >= 20) shaunAILevel = 20;
        if (jadeAILevel >= 20) jadeAILevel = 20;
        if (elijahAILevel >= 20) elijahAILevel = 20;
        if (enQiAILevel >= 20) enQiAILevel = 20;
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
