using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    struct Block
    {
        public float x, z;
        public float height;

        public Vector3 position()
        {
            return new Vector3(x, 0 ,z);
        }
    }

    public GameObject block;
    Block[,] m = new Block[100, 100];
    GameObject[,] o = new GameObject[100, 100];

    float baseScale = 2;
    int lines = 50, columns = 50;

    void Start()
    {
        for (var i = 0; i < lines; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                o[i,j] = Instantiate(block, new Vector3(i * baseScale, 0, j * baseScale), Quaternion.identity);
                //store position on the grid
                m[i,j].x = i * baseScale;
                m[i,j].z = j * baseScale;     
            }
        }


        //inaltimi initiale - pentru test
        for(int i = 0;i<lines;i++)
        {
            for (var j = 0; j < columns; j++)
            {
                //store height
                m[i,j].height = 3 + Random.Range(Vector3.Distance(m[0,0].position(), m[i,j/2].position())/5 - 2f, Vector3.Distance(m[0,0].position(), m[i,j/2].position())/5 + 2f);
                o[i,j].transform.position = o[i,j].transform.position + new Vector3(0, m[i,j].height / 2, 0);
                o[i,j].transform.localScale = new Vector3(baseScale, m[i,j].height, baseScale);
            }
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
