using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    float fillAmount = 0;
    public Image starImage;
    public GameObject latStar;
    public bool isEnded = false;
    Coroutine starCor;
    public bool fastSpawn = false;

    void Start()
    {
        starImage = GetComponent<Image>();
        starImage.fillAmount = 0;
    }

    private void Update()
    {
        if (fastSpawn == true)
        {
            starImage.fillAmount = 1f;
        }
        else if (latStar != null)
        {
            Debug.LogWarning("shold show olny from first star");
            if (latStar.GetComponent<Star>().isEnded)
            {
                starCor = StartCoroutine(SpawnStar());
            }
        }
        else
        {
            starCor = StartCoroutine(SpawnStar());
        }
    }

    IEnumerator SpawnStar()
    {
        if (fillAmount < 1)
        {
            fillAmount += 0.02f;
            starImage.fillAmount = fillAmount;
        }
        else if (fillAmount >= 1)
        {
            isEnded = true;
            //jakkieś dodatkowe efekty
        }
        else
            yield return null;
    }
}
