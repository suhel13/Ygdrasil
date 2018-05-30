using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGGrounChange : MonoBehaviour
{

    public GameObject BGPrefab1;
    public GameObject BGPrefab2;
    List<GameObject> BackGroutParts = new List<GameObject>();
    List<Vector2> Positions = new List<Vector2>();

    Vector2 Pos1 = new Vector2(-12, 0);
    Vector2 Pos2 = new Vector2(-6, 0);
    Vector2 Pos3 = new Vector2(0, 0);
    Vector2 Pos4 = new Vector2(6, 0);
    Vector2 Pos5 = new Vector2(12, 0);
    // Use this for initialization
    void Start()
    {
        loadBackgrounds();
        Positions.Add(Pos1);
        Positions.Add(Pos2);
        Positions.Add(Pos3);
        Positions.Add(Pos4);
        Positions.Add(Pos5);
    }


    public void moveBackGroud()
    {
        foreach (GameObject item in BackGroutParts)
        {
            int index = Positions.IndexOf(item.transform.position);
            if (index - 1 < 0)
            {
                index = Positions.Count - 1;
            }
            else
            {
                index -= 1;
            }

            item.transform.position = Positions[index];
        }
    }

    void loadBackgrounds()
    {
        BackGroutParts.Add(GameObject.Instantiate(BGPrefab1, Pos1, Quaternion.identity));
        BackGroutParts.Add(GameObject.Instantiate(BGPrefab2, Pos2, Quaternion.identity));
        BackGroutParts.Add(GameObject.Instantiate(BGPrefab1, Pos3, Quaternion.identity));
        BackGroutParts.Add(GameObject.Instantiate(BGPrefab2, Pos4, Quaternion.identity));
        BackGroutParts.Add(GameObject.Instantiate(BGPrefab1, Pos5, Quaternion.identity));
    }
}
