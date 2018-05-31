using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenTransition : MonoBehaviour
{

    public Slider loadSlider;
    public GameObject loadPanel;
    public void loadScene(string sceneName)
    {
        PlayerPrefs.Save();
        StartCoroutine(loadAsync(sceneName));
    }

    IEnumerator loadAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadSlider.value = progress;
            Debug.Log(progress);
            loadPanel.SetActive(true);
            yield return null;
        }
        loadPanel.SetActive(false);
    }
}
