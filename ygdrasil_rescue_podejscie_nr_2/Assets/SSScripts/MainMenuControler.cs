using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuControler : MonoBehaviour {

    public GameObject menuPanel;

    public void play()
    {
        menuPanel.SetActive(false);
    }

}
