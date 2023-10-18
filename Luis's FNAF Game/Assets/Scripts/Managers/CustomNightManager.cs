using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomNightManager : MonoBehaviour
{
    [Header("AI Lvl Text")]
    public List<Text> aiLvlText = new List<Text>();
    public float miaLvl = 0f, shaunLvl = 0f, jadeLvl = 0f, enQiLvl = 0f, elijahLvl = 0f;

    [Header("Image Opacity")]


    public static CustomNightManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseLvl()
    {
        if(FindObjectOfType<Text>().CompareTag("Mia"))
        {
            if(miaLvl < 20) miaLvl++;
            aiLvlText.Find(s => s.CompareTag("Mia")).text = miaLvl.ToString();
        }
        else if (FindObjectOfType<Text>().CompareTag("Shaun"))
        {
            if (shaunLvl < 20) shaunLvl++;
            aiLvlText.Find(s => s.CompareTag("Shaun")).text = shaunLvl.ToString();
        }
        else if (FindObjectOfType<Text>().CompareTag("Jade"))
        {
            if (jadeLvl < 20) jadeLvl++;
            aiLvlText.Find(s => s.CompareTag("Jade")).text = jadeLvl.ToString();
        }
        else if(FindObjectOfType<Text>().CompareTag("En Qi"))
        {
            if (enQiLvl < 20) enQiLvl++;
            aiLvlText.Find(s => s.CompareTag("En Qi")).text = enQiLvl.ToString();
        }
        else if (FindObjectOfType<Text>().CompareTag("Elijah"))
        {
            if (elijahLvl < 20) elijahLvl++;
            aiLvlText.Find(s => s.CompareTag("Elijah")).text = elijahLvl.ToString();
        }
    }
    public void DecreaseLvl()
    {
        if (FindObjectOfType<Text>().CompareTag("Mia"))
        {
            if (miaLvl > 0) miaLvl--;
            aiLvlText.Find(s => s.CompareTag("Mia")).text = miaLvl.ToString();
        }
        else if (FindObjectOfType<Text>().CompareTag("Shaun"))
        {
            if (shaunLvl > 0) shaunLvl--;
            aiLvlText.Find(s => s.CompareTag("Shaun")).text = shaunLvl.ToString();
        }
        else if (FindObjectOfType<Text>().CompareTag("Jade"))
        {
            if (jadeLvl > 0) jadeLvl--;
            aiLvlText.Find(s => s.CompareTag("Jade")).text = jadeLvl.ToString();
        }
        else if (FindObjectOfType<Text>().CompareTag("En Qi"))
        {
            if (enQiLvl > 0) enQiLvl--;
            aiLvlText.Find(s => s.CompareTag("En Qi")).text = enQiLvl.ToString();
        }
        else if (FindObjectOfType<Text>().CompareTag("Elijah"))
        {
            if (elijahLvl > 0) elijahLvl--;
            aiLvlText.Find(s => s.CompareTag("Elijah")).text = elijahLvl.ToString();
        }
    }
}
