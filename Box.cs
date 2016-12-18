using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

    public GameObject original;
    public GameObject parent;
    private GameObject a;
    public GameObject[,] box;
    public int hen;

	// Use this for initialization
	void Start () {
        a = Instantiate(parent, new Vector3((float)hen / 2f, (float)hen / 2f, (float)hen / 2f), Quaternion.identity) as GameObject;
        box = new GameObject[hen, hen];
        for (int p = 0; p < hen; p++)   //縦
        {
            for (int i = 0; i < hen; i++)   //奥行き
            {
                for (int j = 0; j < hen; j++)   //横
                {
                    if (p == 0 || p == hen - 1) Instans(j, p, i);
                    else if (i == 0 || i == hen - 1) Instans(j, p, i);
                    else if (j == 0 || j == hen - 1) Instans(j, p, i);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Instans(float j, float p, float i)
    {
        GameObject g = Instantiate(original, new Vector3((float)j, (float)p, (float)i), Quaternion.identity) as GameObject;
        g.transform.parent = a.transform;
    }
}
