using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JsonData : MonoBehaviour
{
    public int stars;
    public float time;

    public JsonData()
    {
        stars = 0;
        time = 0;
    }
}
