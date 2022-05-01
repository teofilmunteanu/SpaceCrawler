using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject map;

    Vector3[,] m = new Vector3[100, 100];
    GameObject[,] o = new GameObject[100, 100];
    public GameObject a ;
    void Start()
    {
        m[1, 1].y = 5;
        for (var i = 0; i < 10; i++)
        {
            for (var j = 0; j < 10; j++)
            {
                o[i,j] = Instantiate(map, new Vector3(i * 2.0f, m[i,j].y, j * 2.0f), Quaternion.identity);

                m[i,j].x = i * 2;
                m[i,j].z = j * 2;
            }
        }
        //Debug.Log(a.GetType().ToString());

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
