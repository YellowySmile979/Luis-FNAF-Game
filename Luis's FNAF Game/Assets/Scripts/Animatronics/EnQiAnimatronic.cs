using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnQiAnimatronic : BaseAnimatronic
{
    [Header("Songs")]
    public List<AudioClip> listOfAllSongs = new List<AudioClip>();
    public AudioClip triggerSong;
    public float setTimeTillDeath = 7f, timeTillDeath;

    public override void AnimatronicBehaviour()
    {
        EnQiMovement();
    }
    //handles en qi's movement
    //there should be one specific song in the list that causes en qi to attack
    void EnQiMovement()
    {
        float randomNumber = Random.Range(0, listOfAllSongs.Count);
        AudioClip audioClip;
        audioClip = listOfAllSongs[(int)randomNumber];
        AnimatronicManager.Instance.audioSource.PlayOneShot(audioClip);

        //checks to see if the song that is playing is the trigger song
        if(audioClip == triggerSong)
        {
            if(timeTillDeath > 0)
            {
                timeTillDeath -= Time.deltaTime;
            }
            else
            {
                EnQiAttack();
            }
        }
        else
        {
            timeTillDeath = setTimeTillDeath;
        }
    }
    //handles death of Luis
    void EnQiAttack()
    {
        GameManager.Instance.GameState = GameState.Dying;
        //play En Qi death animation
        PlayEnQiAnimation();
    }
    void PlayEnQiAnimation()
    {
        GameManager.Instance.GameState = GameState.Lose;
    }
}
