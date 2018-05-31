using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControler : MonoBehaviour
{

    public LevelDataControler levelDataCon;
    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject firstStar;
    public GameObject secendStar;

    public void activeWinPanel()
    {
        WinPanel.SetActive(true);
        LosePanel.SetActive(false);
    }

    public void activeLosePanel()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(true);
    }

    public void deactiveboth()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
    }

    public void activeStar(int number)
    {
        switch (number)
        {
            case 1:
                if (levelDataCon.Stars[PlayerPrefs.GetInt("LevelToLoad") - 1].stars >= 1)
                {
                    firstStar.GetComponent<Star>().fastSpawn = true;
                    firstStar.SetActive(true);
                }
                else
                {
                    firstStar.SetActive(true);
                    saveStars(1);
                }
                break;
            case 2:
                if (levelDataCon.Stars[PlayerPrefs.GetInt("LevelToLoad") - 1] .stars>= 2)
                {
                    secendStar.GetComponent<Star>().fastSpawn = true;
                    secendStar.SetActive(true);
                }
                else
                {
                    secendStar.SetActive(true);
                    saveStars(2);
                }
                break;
            default:
                break;
        }
    }

    void saveStars(int count)
    {
        levelDataCon.Stars[PlayerPrefs.GetInt("LevelToLoad") - 1].stars = count;
        string tempjson = JsonUtility.ToJson(levelDataCon.Stars);
        Debug.Log(tempjson);
        PlayerPrefs.SetString("Stars", tempjson);
        PlayerPrefs.Save();
    }
}
