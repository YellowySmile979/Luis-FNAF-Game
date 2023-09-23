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
    public GameObject cam2Lock, cam3Lock, cam4Lock, cam6Lock, cam7Lock;
    public AudioSource audioSource;

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
        cam2Lock.SetActive(false);
        cam3Lock.SetActive(false);
        cam4Lock.SetActive(false);
        cam6Lock.SetActive(false);
        cam7Lock.SetActive(false);

        audioSource = GetComponent<AudioSource>();
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
    //this is the vent lock section for the vent lock buttons
    bool cam2LockOn;
    public void Cam2Lock()
    {
        cam2LockOn = !cam2LockOn;
        if (cam2LockOn)
        {
            cam2Lock.SetActive(true);
            cam3Lock.SetActive(false);
            cam4Lock.SetActive(false);
            cam6Lock.SetActive(false);
            cam7Lock.SetActive(false);

            UIManager.Instance.cam2LockUi.color = UIManager.Instance.green;
            UIManager.Instance.cam3LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam4LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam6LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam7LockUi.color = UIManager.Instance.red;

            cam3LockOn = false;
            cam4LockOn = false;
            cam6LockOn = false;
            cam7LockOn = false;
        }
        else
        {
            cam2Lock.SetActive(false);
            cam3Lock.SetActive(false);
            cam4Lock.SetActive(false);
            cam6Lock.SetActive(false);
            cam7Lock.SetActive(false);

            UIManager.Instance.cam2LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam3LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam4LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam6LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam7LockUi.color = UIManager.Instance.red;
        }
    }
    bool cam3LockOn;
    public void Cam3Lock()
    {
        cam3LockOn = !cam3LockOn;
        if (cam3LockOn)
        {
            cam2Lock.SetActive(false);
            cam3Lock.SetActive(true);
            cam4Lock.SetActive(false);
            cam6Lock.SetActive(false);
            cam7Lock.SetActive(false);

            UIManager.Instance.cam2LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam3LockUi.color = UIManager.Instance.green;
            UIManager.Instance.cam4LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam6LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam7LockUi.color = UIManager.Instance.red;

            cam2LockOn = false;
            cam4LockOn = false;
            cam6LockOn = false;
            cam7LockOn = false;
        }
        else
        {
            cam2Lock.SetActive(false);
            cam3Lock.SetActive(false);
            cam4Lock.SetActive(false);
            cam6Lock.SetActive(false);
            cam7Lock.SetActive(false);

            UIManager.Instance.cam2LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam3LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam4LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam6LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam7LockUi.color = UIManager.Instance.red;
        }
    }
    bool cam4LockOn;
    public void Cam4Lock()
    {
        cam4LockOn = !cam4LockOn;
        if (cam4LockOn)
        {
            cam2Lock.SetActive(false);
            cam3Lock.SetActive(false);
            cam4Lock.SetActive(true);
            cam6Lock.SetActive(false);
            cam7Lock.SetActive(false);

            UIManager.Instance.cam2LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam3LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam4LockUi.color = UIManager.Instance.green;
            UIManager.Instance.cam6LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam7LockUi.color = UIManager.Instance.red;

            cam3LockOn = false;
            cam2LockOn = false;
            cam6LockOn = false;
            cam7LockOn = false;
        }
        else
        {
            cam2Lock.SetActive(false);
            cam3Lock.SetActive(false);
            cam4Lock.SetActive(false);
            cam6Lock.SetActive(false);
            cam7Lock.SetActive(false);

            UIManager.Instance.cam2LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam3LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam4LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam6LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam7LockUi.color = UIManager.Instance.red;
        }
    }
    bool cam6LockOn;
    public void Cam6Lock()
    {
        cam6LockOn = !cam6LockOn;
        if (cam6LockOn)
        {
            cam2Lock.SetActive(false);
            cam3Lock.SetActive(false);
            cam4Lock.SetActive(false);
            cam6Lock.SetActive(true);
            cam7Lock.SetActive(false);

            UIManager.Instance.cam2LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam3LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam4LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam6LockUi.color = UIManager.Instance.green;
            UIManager.Instance.cam7LockUi.color = UIManager.Instance.red;

            cam3LockOn = false;
            cam4LockOn = false;
            cam2LockOn = false;
            cam7LockOn = false;
        }
        else
        {
            cam2Lock.SetActive(false);
            cam3Lock.SetActive(false);
            cam4Lock.SetActive(false);
            cam6Lock.SetActive(false);
            cam7Lock.SetActive(false);

            UIManager.Instance.cam2LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam3LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam4LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam6LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam7LockUi.color = UIManager.Instance.red;
        }
    }
    bool cam7LockOn;
    public void Cam7Lock()
    {
        cam7LockOn = !cam7LockOn;
        if (cam7LockOn)
        {
            cam2Lock.SetActive(false);
            cam3Lock.SetActive(false);
            cam4Lock.SetActive(false);
            cam6Lock.SetActive(false);
            cam7Lock.SetActive(true);

            UIManager.Instance.cam2LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam3LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam4LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam6LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam7LockUi.color = UIManager.Instance.green;

            cam3LockOn = false;
            cam4LockOn = false;
            cam6LockOn = false;
            cam2LockOn = false;
        }
        else
        {
            cam2Lock.SetActive(false);
            cam3Lock.SetActive(false);
            cam4Lock.SetActive(false);
            cam6Lock.SetActive(false);
            cam7Lock.SetActive(false);

            UIManager.Instance.cam2LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam3LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam4LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam6LockUi.color = UIManager.Instance.red;
            UIManager.Instance.cam7LockUi.color = UIManager.Instance.red;
        }
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
