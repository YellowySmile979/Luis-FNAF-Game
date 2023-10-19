using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomNightManager : MonoBehaviour
{
    [Header("AI Lvl Text")]
    public List<Text> aiLvlText = new List<Text>();

    public float miaLvl = 0f, shaunLvl = 0f, jadeLvl = 0f, enQiLvl = 0f, elijahLvl = 0f;

    public const string miaKey = "Mia",
                        shaunKey = "Shaun",
                        jadeKey = "Jade",
                        enQiKey = "En Qi",
                        elijahKey = "Elijah";

    [Header("Image Opacity")]
    public Image[] profilePicsCover;

    public static CustomNightManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        aiLvlText.Find(s => s.CompareTag("Mia")).text = miaLvl.ToString();
        aiLvlText.Find(s => s.CompareTag("Shaun")).text = shaunLvl.ToString();
        aiLvlText.Find(s => s.CompareTag("Jade")).text = jadeLvl.ToString();
        aiLvlText.Find(s => s.CompareTag("En Qi")).text = enQiLvl.ToString();
        aiLvlText.Find(s => s.CompareTag("Elijah")).text = elijahLvl.ToString();

        PlayerPrefs.SetFloat(miaKey, miaLvl);
        PlayerPrefs.SetFloat(shaunKey, shaunLvl);
        PlayerPrefs.SetFloat(jadeKey, jadeLvl);
        PlayerPrefs.SetFloat(enQiKey, enQiLvl);
        PlayerPrefs.SetFloat(elijahKey, elijahLvl);
    }

    // Update is called once per frame
    void Update()
    {
        ImageFade();
    }
    void ImageFade()
    {
        float miaShaderNumber = (PlayerPrefs.GetFloat(miaKey) / 20) - 0.2f;
        if (miaShaderNumber <= 0) miaShaderNumber = 0;
        profilePicsCover[0].color = new Color(profilePicsCover[0].color.r, profilePicsCover[0].color.g, profilePicsCover[0].color.b, miaShaderNumber);

        float shaunShaderNumber = (PlayerPrefs.GetFloat(shaunKey) / 20) - 0.2f;
        if (shaunShaderNumber <= 0) shaunShaderNumber = 0;
        profilePicsCover[1].color = new Color(profilePicsCover[1].color.r, profilePicsCover[1].color.g, profilePicsCover[1].color.b, shaunShaderNumber);

        float jadeShaderNumber = (PlayerPrefs.GetFloat(jadeKey) / 20) - 0.2f;
        if (jadeShaderNumber <= 0) jadeShaderNumber = 0;
        profilePicsCover[2].color = new Color(profilePicsCover[2].color.r, profilePicsCover[2].color.g, profilePicsCover[2].color.b, jadeShaderNumber);

        float enQiShaderNumber = (PlayerPrefs.GetFloat(enQiKey) / 20) - 0.2f;
        if (enQiShaderNumber <= 0) enQiShaderNumber = 0;
        profilePicsCover[3].color = new Color(profilePicsCover[3].color.r, profilePicsCover[3].color.g, profilePicsCover[3].color.b, enQiShaderNumber);

        float elijahShaderNumber = (PlayerPrefs.GetFloat(elijahKey) / 20) - 0.2f;
        if (elijahShaderNumber <= 0) elijahShaderNumber = 0;
        profilePicsCover[4].color = new Color(profilePicsCover[4].color.r, profilePicsCover[4].color.g, profilePicsCover[4].color.b, elijahShaderNumber);
    }
    public void StartCustomNight()
    {
        PlayerPrefs.SetInt("Custom Night", 1);
        SceneManager.LoadScene("Custom Night");
    }
    public void CloseMenu()
    {
        PlayerPrefs.SetInt("Custom Night", 0);
        MenuManager.Instance.CloseCustomNight();      
    }

    public void IncreaseMiaLvl()
    {
        if (miaLvl < 20)
        {
            miaLvl++;
            PlayerPrefs.SetFloat(miaKey, miaLvl);
        }

        aiLvlText.Find(s => s.CompareTag("Mia")).text = PlayerPrefs.GetFloat(miaKey).ToString();
    }
    public void DecreaseMiaLvl()
    {
        if (miaLvl > 0)
        {
            miaLvl--;
            PlayerPrefs.SetFloat(miaKey, miaLvl);
        }

        aiLvlText.Find(s => s.CompareTag("Mia")).text = PlayerPrefs.GetFloat(miaKey).ToString();
    }
    public void IncreaseShaunLvl()
    {
        if (shaunLvl < 20)
        {
            shaunLvl++;
            PlayerPrefs.SetFloat(shaunKey, shaunLvl);
        }

        aiLvlText.Find(s => s.CompareTag("Shaun")).text = PlayerPrefs.GetFloat(shaunKey).ToString();
    }
    public void DecreaseShaunLvl()
    {
        if (shaunLvl > 0)
        {
            miaLvl--;
            PlayerPrefs.SetFloat(shaunKey, shaunLvl);
        }

        aiLvlText.Find(s => s.CompareTag("Shaun")).text = PlayerPrefs.GetFloat(shaunKey).ToString();
    }
    public void IncreaseJadeLvl()
    {
        if (jadeLvl < 20)
        {
            jadeLvl++;
            PlayerPrefs.SetFloat(jadeKey, jadeLvl);
        }

        aiLvlText.Find(s => s.CompareTag("Jade")).text = PlayerPrefs.GetFloat(jadeKey).ToString();
    }
    public void DecreaseJadeLvl()
    {
        if (jadeLvl > 0)
        {
            jadeLvl--;
            PlayerPrefs.SetFloat(jadeKey, jadeLvl);
        }

        aiLvlText.Find(s => s.CompareTag("Jade")).text = PlayerPrefs.GetFloat(jadeKey).ToString();
    }
    public void IncreaseEnQiLvl()
    {
        if (enQiLvl < 20)
        {
            enQiLvl++;
            PlayerPrefs.SetFloat(enQiKey, enQiLvl);
        }

        aiLvlText.Find(s => s.CompareTag("En Qi")).text = PlayerPrefs.GetFloat(enQiKey).ToString();
    }
    public void DecreaseEnQiLvl()
    {
        if (enQiLvl > 0)
        {
            enQiLvl--;
            PlayerPrefs.SetFloat(enQiKey, enQiLvl);
        }

        aiLvlText.Find(s => s.CompareTag("En Qi")).text = PlayerPrefs.GetFloat(enQiKey).ToString();
    }
    public void IncreaseElijahLvl()
    {
        if (elijahLvl < 20)
        {
            elijahLvl++;
            PlayerPrefs.SetFloat(elijahKey, elijahLvl);
        }

        aiLvlText.Find(s => s.CompareTag("Elijah")).text = PlayerPrefs.GetFloat(elijahKey).ToString();
    }
    public void DecreaseElijahLvl()
    {
        if (elijahLvl > 0)
        {
            elijahLvl--;
            PlayerPrefs.SetFloat(elijahKey, elijahLvl);
        }

        aiLvlText.Find(s => s.CompareTag("Elijah")).text = PlayerPrefs.GetFloat(elijahKey).ToString();
    }
}
