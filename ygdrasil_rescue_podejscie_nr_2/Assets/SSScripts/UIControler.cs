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

    public float time;

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
                if (levelDataCon.LevelStats.Stars[PlayerPrefs.GetInt("LevelToLoad") - 1] >= 1)
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
                if (levelDataCon.LevelStats.Stars[PlayerPrefs.GetInt("LevelToLoad") - 1] >= 2)
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
        levelDataCon.LevelStats.Stars[PlayerPrefs.GetInt("LevelToLoad") - 1] = count;
        saveTime(time);
        string tempjson = JsonUtility.ToJson(levelDataCon.LevelStats);
        Debug.Log(tempjson);
        PlayerPrefs.SetString("LevelStats", tempjson);
        PlayerPrefs.Save();
    }

    void saveTime(float time)
    {
        levelDataCon.LevelStats.Time[PlayerPrefs.GetInt("LevelToLoad") - 1] = time;       
    }

    void showTime()
    {

    }
}
