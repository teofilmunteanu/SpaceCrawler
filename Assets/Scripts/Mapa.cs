using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    public GameObject block;

    Vector3[,] m = new Vector3[100, 100]; //x-x position, z-z position, y-height
    GameObject[,] o = new GameObject[100, 100];

    float baseScale = 3;
    void Start()
    {
        //inaltimi initiale - pentru test
        for(int i = 0;i<10;i++)
        {
            for (var j = 0; j < 10; j++)
            {
                m[i,j].y = 6;
            }
        }    

        //test
        m[2,3].y = 12;

        for (var i = 0; i < 10; i++)
        {
            for (var j = 0; j < 10; j++)
            {
                o[i,j] = Instantiate(block, new Vector3(i * baseScale, 0, j * baseScale), Quaternion.identity);
                o[i,j].transform.localScale = new Vector3(baseScale, m[i,j].y, baseScale);
                o[i,j].transform.position = o[i,j].transform.position + new Vector3(0, m[i,j].y / 2,0);

                m[i,j].x = i * 2;
                m[i,j].z = j * 2;
            }
        }
        
        //o[0,0].transform.position = o[0,0].transform.position + new Vector3(0,2.5f,0);
        //Debug.Log(a.GetType().ToString());

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
