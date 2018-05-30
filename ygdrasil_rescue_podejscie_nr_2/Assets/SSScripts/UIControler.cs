using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControler : MonoBehaviour {

    public GameObject WinPanel;
    public GameObject LosePanel;

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
	
}
