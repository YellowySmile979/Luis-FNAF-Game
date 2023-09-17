using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaunAnimatronic : BaseAnimatronic
{
    public override void AnimatronicBehaviour()
    {
        ShaunMovement();
    }
    //handles the movement of Shaun
    void ShaunMovement()
    {
        //perform movement
        //we check the position at which the animatronic is at
        //and depending on which pos it is at, it determines which position it can go to
        //Main Stage: 0, Main Hall 1: 1, Main Hall 2: 2, Parts&Service: 3, Kitchen: 4, East Hallway: 5, West Hallway: 6,
        //Storage: 7, Party Room: 8, Entrance: 9, Waiting to Kill: 10
        if(AnimatronicManager.Instance.shaun.transform.position == whereToStart.transform.position)
        {
            AnimatronicManager.Instance.shaun.transform.position = listOfAllPlacesToMove[1].transform.position;
            whereIAmNow.transform.position = listOfAllPlacesToMove[1].transform.position;
        }
        else if(AnimatronicManager.Instance.shaun.transform.position == listOfAllPlacesToMove[1].transform.position)
        {
            float randomNumber = Random.Range(1, 100);
            if(randomNumber > 40)
            {
                AnimatronicManager.Instance.shaun.transform.position = listOfAllPlacesToMove[5].transform.position;
                whereIAmNow.transform.position = listOfAllPlacesToMove[5].transform.position;
            }
            else
            {
                float randomNo = Random.Range(1, 90);
                if(randomNo <= 30)
                {
                    AnimatronicManager.Instance.shaun.transform.position = listOfAllPlacesToMove[3].transform.position;
                    whereIAmNow.transform.position = listOfAllPlacesToMove[3].transform.position;
                }
                else if(randomNo > 30 && randomNo <= 60)
                {
                    AnimatronicManager.Instance.shaun.transform.position = listOfAllPlacesToMove[4].transform.position;
                    whereIAmNow.transform.position = listOfAllPlacesToMove[4].transform.position;
                }
                else if(randomNo > 60)
                {
                    AnimatronicManager.Instance.shaun.transform.position = listOfAllPlacesToMove[9].transform.position;
                    whereIAmNow.transform.position = listOfAllPlacesToMove[9].transform.position;
                }
            }
        }
        else if(AnimatronicManager.Instance.shaun.transform.position == listOfAllPlacesToMove[3].transform.position)
        {
            AnimatronicManager.Instance.shaun.transform.position = listOfAllPlacesToMove[1].transform.position;
            whereIAmNow.transform.position = listOfAllPlacesToMove[1].transform.position;
        }
        else if(AnimatronicManager.Instance.shaun.transform.position == listOfAllPlacesToMove[4].transform.position)
        {
            AnimatronicManager.Instance.shaun.transform.position = listOfAllPlacesToMove[1].transform.position;
            whereIAmNow.transform.position = listOfAllPlacesToMove[1].transform.position;
        }
        else if(AnimatronicManager.Instance.shaun.transform.position == listOfAllPlacesToMove[9].transform.position)
        {
            AnimatronicManager.Instance.shaun.transform.position = listOfAllPlacesToMove[1].transform.position;
            whereIAmNow.transform.position = listOfAllPlacesToMove[1].transform.position;
        }
        else if(AnimatronicManager.Instance.shaun.transform.position == listOfAllPlacesToMove[5].transform.position)
        {
            float randomNumber = Random.Range(1, 100);
            if (randomNumber <= 40)
            {
                float randomNo = Random.Range(1, 100);
                if (randomNo <= 50)
                {
                    AnimatronicManager.Instance.shaun.transform.position = listOfAllPlacesToMove[8].transform.position;
                    whereIAmNow.transform.position = listOfAllPlacesToMove[8].transform.position;
                }
                else
                {
                    AnimatronicManager.Instance.shaun.transform.position = listOfAllPlacesToMove[1].transform.position;
                    whereIAmNow.transform.position = listOfAllPlacesToMove[1].transform.position;
                }
            }
            else
            {
                AnimatronicManager.Instance.shaun.transform.position = listOfAllPlacesToMove[10].transform.position;
                whereIAmNow.transform.position = listOfAllPlacesToMove[10].transform.position;
            }
        }
        else if(AnimatronicManager.Instance.shaun.transform.position == listOfAllPlacesToMove[8].transform.position)
        {
            AnimatronicManager.Instance.shaun.transform.position = listOfAllPlacesToMove[5].transform.position;
            whereIAmNow.transform.position = listOfAllPlacesToMove[5].transform.position;
        }
        else if(AnimatronicManager.Instance.shaun.transform.position == listOfAllPlacesToMove[10].transform.position)
        {
            ShaunAttack();
        }
    }
    //handles shaun's attack
    void ShaunAttack()
    {
        if (AnimatronicManager.Instance.isRightDoorClosed)
        {
            AnimatronicManager.Instance.shaun.transform.position = whereToStart.transform.position;
            whereIAmNow.transform.position = listOfAllPlacesToMove[0].transform.position;
        }
        else
        {
            GameManager.Instance.GameState = GameState.Dying;
            //shaun attacks
            PlayShaunAnimation();
        }
    }
    //play mia's animation
    void PlayShaunAnimation()
    {
        GameManager.Instance.GameState = GameState.Lose;
    }
}
