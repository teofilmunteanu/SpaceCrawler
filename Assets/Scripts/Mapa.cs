using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    struct Block
    {
        public float x, z;
        public float height;
    }

    public GameObject block;
    Block[,] m = new Block[100, 100];
    GameObject[,] o = new GameObject[100, 100];

    float baseScale = 2;
    void Start()
    {
        //inaltimi initiale - pentru test
        for(int i = 0;i<10;i++)
        {
            for (var j = 0; j < 10; j++)
            {
                m[i,j].height = 4;
            }
        }    

        //test
        m[2,3].height = 8;

        for (var i = 0; i < 10; i++)
        {
            for (var j = 0; j < 10; j++)
            {
                o[i,j] = Instantiate(block, new Vector3(i * baseScale, 0, j * baseScale), Quaternion.identity);
                //store position on the grid
                m[i,j].x = i * 2;
                m[i,j].z = j * 2;

                //store height
                o[i,j].transform.localScale = new Vector3(baseScale, m[i,j].height, baseScale);
                o[i,j].transform.position = o[i,j].transform.position + new Vector3(0, m[i,j].height / 2, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
