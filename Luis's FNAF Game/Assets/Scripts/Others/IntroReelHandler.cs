using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroReelHandler : MonoBehaviour
{
    public VideoPlayer introPlayer;
    [SerializeField] float totalLength, currentLength;

    // Start is called before the first frame update
    void Start()
    {
        totalLength = introPlayer.frameCount;
    }

    // Update is called once per frame
    void Update()
    {
        currentLength = introPlayer.frame;

        if(currentLength >= totalLength)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
