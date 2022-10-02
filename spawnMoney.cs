using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMoney : MonoBehaviour
{
    public GameObject[] points;
    public GameObject money;
    void Start()
    {
        int r = Random.Range(0, 2);
        if (r == 1)
        {
            int i = Random.Range(0, points.Length);
            Instantiate(money, points[i].transform);
        }
    }
}
