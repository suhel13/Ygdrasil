using UnityEngine;
using UnityEngine.SceneManagement;

public class RunLevel : MonoBehaviour {

    public ScenTransition scenTran;
    public int level;


    private void OnMouseDown()
    {
        Debug.Log("klikłeś");
        PlayerPrefs.SetInt("LevelToLoad", level);
        PlayerPrefs.Save();
        scenTran.loadScene("GameScen");
    }
}
