using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
