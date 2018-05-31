using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JsonData
{
    public List<int> Stars;
    public List<float> Time;

    public JsonData()
    {
        Stars = new List<int>();
        Time = new List<float>();
    }
}
