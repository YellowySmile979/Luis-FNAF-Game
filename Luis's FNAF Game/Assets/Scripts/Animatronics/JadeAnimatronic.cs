using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JadeAnimatronic : BaseAnimatronic
{
    public override void AnimatronicBehaviour()
    {
        JadeMovement();
    }
    //handles jade's movement
    void JadeMovement()
    {
        //perform movement
        //we check the position at which the animatronic is at
        //and depending on which pos it is at, it determines which position it can go to
        //Parts & Service (Main): 0, Parts & Service (Vents): 1, Main Hall 1: 2, Main Hall 2: 3, Kitchen: 4, Party Room: 5,
        //East Hallway: 6, West Hallway: 7, Storage: 8, Waiting to Kill: 9
        if(AnimatronicManager.Instance.jade.transform.position == whereToStart.transform.position)
        {
            //from initial pos to initial vent
            AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[1].transform.position;
            whereIAmNow = listOfAllPlacesToMove[1];
        }
        else if(AnimatronicManager.Instance.jade.transform.position == listOfAllPlacesToMove[1].transform.position)
        {
            float randomNumber = Random.Range(1, 100);
            if(randomNumber <= 30)
            {
                //from initial vent to Main Hall 1 vent
                AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[2].transform.position;
                whereIAmNow = listOfAllPlacesToMove[2];
            }
            else
            {
                //from initial vent to Main Hall 2 vent
                AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[3].transform.position;
                whereIAmNow = listOfAllPlacesToMove[3];
            }
        }
        else if(AnimatronicManager.Instance.jade.transform.position == listOfAllPlacesToMove[2].transform.position)
        {
            float randomNumber = Random.Range(1, 100);
            if (randomNumber > 40)
            {
                //from Main Hall 1 vent to West Hallway vent
                AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[7].transform.position;
                whereIAmNow = listOfAllPlacesToMove[7];
            }
            else
            {
                float randomNo = Random.Range(1, 100);
                if (randomNo <= 60)
                {
                    //from Main Hall 1 vent to initial vent
                    AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[1].transform.position;
                    whereIAmNow = listOfAllPlacesToMove[1];
                }
                else
                {
                    //from Main Hall 1 to the Kitchen
                    AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[4].transform.position;
                    whereIAmNow = listOfAllPlacesToMove[4];
                }
            }
        }
        else if(AnimatronicManager.Instance.jade.transform.position == listOfAllPlacesToMove[3].transform.position)
        {
            float randomNumber = Random.Range(1, 100);
            if (randomNumber <= 40)
            {
                float randomNo = Random.Range(1, 100);
                if (randomNo <= 50)
                {
                    //from Main Hall 2 vent to Kitchen vent
                    AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[4].transform.position;
                    whereIAmNow = listOfAllPlacesToMove[4];
                }
                else
                {
                    //from Main Hall 2 vent to initial vent
                    AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[1].transform.position;
                    whereIAmNow = listOfAllPlacesToMove[1];
                }
            }
            else
            {
                //from Main Hall 2 vent to Party Room vent
                AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[5].transform.position;
                whereIAmNow = listOfAllPlacesToMove[5];
            }
        }
        else if(AnimatronicManager.Instance.jade.transform.position == listOfAllPlacesToMove[4].transform.position)
        {
            float randomNumber = Random.Range(1, 100);
            if (randomNumber <= 50)
            {
                //from Kitchen vent to Main Hall 2
                AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[3].transform.position;
                whereIAmNow = listOfAllPlacesToMove[3];
            }
            else
            {
                //from Kitchen vent to Main Hall 1
                AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[2].transform.position;
                whereIAmNow = listOfAllPlacesToMove[2];
            }
        }
        else if(AnimatronicManager.Instance.jade.transform.position == listOfAllPlacesToMove[5].transform.position)
        {
            float randomNumber = Random.Range(1, 100);
            if(randomNumber <= 40)
            {
                //from Party Room vent to Main Hall 1 vent
                AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[2].transform.position;
                whereIAmNow = listOfAllPlacesToMove[2];
            }
            else
            {
                float randomNo = Random.Range(1, 100);
                if (randomNo <= 60)
                {
                    //from Party Room vent to East Hallway vent
                    AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[6].transform.position;
                    whereIAmNow = listOfAllPlacesToMove[6];
                }
                else
                {
                    //from Party Room vent to Storage vent
                    AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[8].transform.position;
                    whereIAmNow = listOfAllPlacesToMove[8];
                }
            }
        }
        else if(AnimatronicManager.Instance.jade.transform.position == listOfAllPlacesToMove[6].transform.position)
        {
            float randomNumber = Random.Range(1, 100);
            if(randomNumber <= 40)
            {
                float randomNo = Random.Range(1, 100);
                if (randomNo <= 50)
                {
                    //from East Hallway vent to Party Room vent
                    AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[5].transform.position;
                    whereIAmNow = listOfAllPlacesToMove[5];
                }
                else
                {
                    //from East Hallway vent to Storage vent
                    AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[8].transform.position;
                    whereIAmNow = listOfAllPlacesToMove[8];
                }
            }
            else
            {
                //from East Hallway vent to Office vent
                AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[9].transform.position;
                whereIAmNow = listOfAllPlacesToMove[9];
            }
        }
        else if(AnimatronicManager.Instance.jade.transform.position == listOfAllPlacesToMove[7].transform.position)
        {
            float randomNumber = Random.Range(1, 100);
            if(randomNumber <= 40)
            {
                float randomNo = Random.Range(1, 100);
                if (randomNo <= 50)
                {
                    //from West Hallway vent to Storage vent
                    AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[8].transform.position;
                    whereIAmNow = listOfAllPlacesToMove[8];
                }
                else
                {
                    //from West Hallway vent to Party Room vent
                    AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[5].transform.position;
                    whereIAmNow = listOfAllPlacesToMove[5];
                }
            }
            else
            {
                //from West Hallway vent to Office vent
                AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[9].transform.position;
                whereIAmNow = listOfAllPlacesToMove[9];
            }
        }
        else if(AnimatronicManager.Instance.jade.transform.position == listOfAllPlacesToMove[8].transform.position)
        {
            float randomNumber = Random.Range(1, 100);
            if(randomNumber <= 50)
            {
                //from Storage vent to East Hallway
                AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[6].transform.position;
                whereIAmNow = listOfAllPlacesToMove[6];
            }
            else
            {
                //from Storage vent to West Hallway
                AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[7].transform.position;
                whereIAmNow = listOfAllPlacesToMove[7];
            }
        }
        else if(AnimatronicManager.Instance.jade.transform.position == listOfAllPlacesToMove[9].transform.position)
        {
            JadeAttack();
        }
    }
    void JadeAttack()
    {
        float randomNumber = Random.Range(1, 100);
        if (randomNumber <= 99)
        {
            GameManager.Instance.GameState = GameState.Dying;
            //jade attacks
            PlayJadeAnimation();
        }
        else
        {
            float randomNo = Random.Range(1, 100);
            if (randomNo <= 50)
            {
                //from Office vent to East Hallway vent
                AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[6].transform.position;
                whereIAmNow = listOfAllPlacesToMove[6];
            }
            else
            {
                //from Office vent to West Hallway vent
                AnimatronicManager.Instance.jade.transform.position = listOfAllPlacesToMove[7].transform.position;
                whereIAmNow = listOfAllPlacesToMove[7];
            }
        }
    }
    void PlayJadeAnimation()
    {
        GameManager.Instance.GameState = GameState.Lose;
    }
}
