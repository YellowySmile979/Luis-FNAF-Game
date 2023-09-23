using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnQiAnimatronic : BaseAnimatronic
{
    [Header("Songs")]
    public List<AudioClip> listOfAllSongs = new List<AudioClip>();
    public AudioClip triggerSong;
    public float setTimeTillDeath = 7f, timeTillDeath;
    public AudioClip current, audioClip;

    public override void AnimatronicBehaviour()
    {
        EnQiMovement();
    }
    //handles en qi's movement
    //there should be one specific song in the list that causes en qi to attack
    float counterr = 0;
    public void EnQiMovement(bool skip = false)
    {
        AudioManager.Instance.audioSource.Stop();
        if (!skip)
        {
            float randomNumber = Random.Range(0, listOfAllSongs.Count);
            audioClip = listOfAllSongs[(int)randomNumber];
        }
        AudioManager.Instance.audioSource.clip = audioClip;
        AudioManager.Instance.audioSource.Play();

        //ensures that if the trigger song hasnt been played, it will play
        if(counterr > 3)
        {
            audioClip = triggerSong;
        }

        current = audioClip;
        print("Song playing: " + audioClip);
        //checks to see if the song that is playing is the trigger song
        if(audioClip == triggerSong)
        {
            isTriggerSong = true;
            print("hELLO");
        }
        else
        {
            isTriggerSong = false;
            print("Hello");
        }        
    }
    public void UpdateLocalVariable(AudioClip clip)
    {
        audioClip = clip;
    }
    void FixedUpdate()
    {
        if(current != null)
        {
            UIManager.Instance.SongPlayer(AudioManager.Instance.audioSource.time, current.length, current.name);
        }

        if (isTriggerSong)
        {
            if (timeTillDeath > 0)
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
