using UnityEngine;

public class levelSpawn : MonoBehaviour
{
    public GameObject[] points;
    public GameObject[] pref;
    GameObject[] list = new GameObject[25];
    int zn, znc = -1;
    void Start()
    {
        for (int i = 0; i < points.Length; i++)
        {
            prf();
            list[i] = Instantiate(pref[zn], points[i].transform);
        }
    }
    private void prf()
    {
        int znv;
        znv = Random.Range(0, pref.Length);
        if (znv != znc)
        {
            znc = znv;
            zn = znv;
        }
        else prf();
    }
    public void refresh()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Destroy(list[i]);
        }
        for (int i = 0; i < points.Length; i++)
        {
            prf();
            list[i] = Instantiate(pref[zn], points[i].transform);
        }
    }
}
