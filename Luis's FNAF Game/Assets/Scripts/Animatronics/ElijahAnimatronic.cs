using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElijahAnimatronic : BaseAnimatronic
{
    [Header("Phase Progress")]
    public List<Sprite> phaseImages = new List<Sprite>();
    public Sprite westHallwayRunning;
    public float setTimeTillDeath, timeTillDeath;

    public override void AnimatronicBehaviour()
    {
        ElijahMovement();
    }
    //performs movement
    //unlike the rest, i "move" by changing my phase until i actually attack
    //counter = 0: deactivated, counter = 1: just activated, counter = 2: sitting up right,
    //counter = 3: standing but near original pos, counter = 4: directly in front of cam, counter = 5: i am gone
    //when counter = 6, i am seen running down the hall and player has like a few seconds before i reach and they die
    //however it is only 6 when they check the WEST HALLWAY CAM
    void ElijahMovement()
    {
        switch (counter)
        {
            case 0:
                CamSystemManager.Instance.mainHall2BG = phaseImages[0];
                break;
            case 1:
                CamSystemManager.Instance.mainHall2BG = phaseImages[1];
                break;
            case 2:
                CamSystemManager.Instance.mainHall2BG = phaseImages[2];
                break;
            case 3:
                CamSystemManager.Instance.mainHall2BG = phaseImages[3];
                break;
            case 4:
                CamSystemManager.Instance.mainHall2BG = phaseImages[4];
                break;
            case 5:
                CamSystemManager.Instance.mainHall2BG = phaseImages[5];
                break;
            case 6:
                ElijahAttack();
                break;
        }
    }
    //handles my attacking
    void ElijahAttack()
    {
        CamSystemManager.Instance.westHallwayRunning = this.westHallwayRunning;
        if(timeTillDeath > 0)
        {
            timeTillDeath -= Time.deltaTime;
        }
        else
        {
            if (!AnimatronicManager.Instance.isLeftDoorClosed)
            {
                //dude dies
                GameManager.Instance.GameState = GameState.Dying;
                PlayElijahAnimation();
            }
            else
            {
                //dude doesnt die and counter is reset
                counter = 0;
                timeTillDeath = setTimeTillDeath;
            }
        }
    }
    void PlayElijahAnimation()
    {
        GameManager.Instance.GameState = GameState.Lose;
    }
}
