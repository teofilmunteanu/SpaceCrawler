using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Mapa : MonoBehaviour
{
    
    public struct Tile
    {
        public float x, z;
        public float height;
        public int effectIndex;

        public Vector3 position()
        {
            return new Vector3(x, 0 ,z);
        }
    }

    public List<GameObject> tileTypes = new List<GameObject>(); //to assign in inspector
    public static Tile[,] tiles = new Tile[100,100];
    GameObject[,] tileObjects = new GameObject[100, 100];

    public static float baseScale = 2;
    int lines = 50, columns = 50;

    public int test = 123;
    void Awake()
    {
        initializeBlocks();

        // if(SceneManager.GetActiveScene().name == "Scenariu2")
        // {
        //     setBlocksIncreasing();  
        // }

        // if(SceneManager.GetActiveScene().name != "Scenariu2")//== "TileEffectsTesting")
        // {
        //     setBlocksTileEffectsTesting();  
        // }

        //if(planet never visited)
        //{   
            if(SceneManager.GetActiveScene().name == "Planet0")
            {
                setBlocksIncreasing();  
            }

            if(SceneManager.GetActiveScene().name == "Planet1")//== "TileEffectsTesting")
            {
                setBlocksTileEffectsTesting();  
            }
        //}
        //else 
            //Load from map savefile
    }

    void Start()
    {
        
    }

    void initializeBlocks()
    {
        //effect test - replaced by list of effects?
       tiles[0,1].effectIndex = 2;
       tiles[0,2].effectIndex = 1;
       tiles[1,0].effectIndex = 3;

        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                //store position on the grid
                tiles[i,j].x = i * baseScale;
                tiles[i,j].z = j * baseScale; 
            
                //every tile instantiates with its corresponding prefab(tile type)
                tileObjects[i,j] = Instantiate(tileTypes[tiles[i,j].effectIndex], tiles[i,j].position(), Quaternion.identity);
                tileObjects[i,j].transform.parent = transform;  
            }
            
        }
    }

    void setBlocksIncreasing()
    {
        //inaltimi initiale - pentru test
        for(int i = 0;i<lines;i++)
        {
            for (var j = 0; j < columns; j++)
            {
                //store height
                tiles[i,j].height = 3 + Random.Range(Vector3.Distance(tiles[0,0].position(), tiles[i,j/2].position())/5 - 2f, Vector3.Distance(tiles[0,0].position(), tiles[i,j/2].position())/5 + 2f);
                tileObjects[i,j].transform.position = tileObjects[i,j].transform.position + new Vector3(0, tiles[i,j].height / 2, 0);
                tileObjects[i,j].transform.localScale = new Vector3(baseScale, tiles[i,j].height, baseScale);
            }
        }  
    }

    void setBlocksTileEffectsTesting()
    {
        for(int i = 0;i<lines;i++)
        {
            for (int j = 0; j < columns; j++)
            {
                tiles[i,j].height = 3;
                tileObjects[i,j].transform.position = tileObjects[i,j].transform.position + new Vector3(0, tiles[i,j].height / 2, 0);
                tileObjects[i,j].transform.localScale = new Vector3(baseScale, tiles[i,j].height, baseScale);
            }
        }  
    }

    public static Tile getTile(Vector3 pos)
    {
        return tiles[(int)(pos.x/baseScale), (int)(pos.z/baseScale)];
    }
}
