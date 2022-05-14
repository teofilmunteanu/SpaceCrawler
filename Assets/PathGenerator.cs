using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
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
    struct coord
    {
        public int x, y;
    }

    public GameObject block;
    Block[,] m = new Block[300, 300];
    GameObject[,] o = new GameObject[300, 300];

    float baseScale = 2;
    int lines = 250, columns = 250;
    int distance;


    int[,] state = new int[300 , 300];


    void addCell(int dir ,ref coord curent,ref coord finish)
    {
        switch(dir) 
        {
            case 0:
                curent.x++;
                break;
            case 1:
                curent.x--;
                break;
            case 2:
                curent.y++;
                break;
            case 3:
                curent.y--;
                break;
            default:
                Debug.Log("switch default");
                break;
        }
        if(curent.x<0)
        curent.x=0;
        if(curent.y<0)
        curent.y=0;
        if(curent.x>lines)
        curent.x=lines;
        if(curent.x>columns)
        curent.y=columns;
        state[curent.x,curent.y]=1;
        Debug.Log("cell placed");
    }

    int roulettewheel(int lastDir,coord curent,coord finish)
    {
        bool growx=false;
        bool growy=false;
        if(curent.x<finish.x)
            growx=true;
        if(curent.y<finish.y)
            growy=true;
        int xp,xm,yp,ym;// puncte de schimbare in for

        switch(lastDir) 
        {
            case 0:
                if(growx)
                {
                    xp=45;
                    xm=0;
                    if(growy)
                    {
                        yp=40;
                        ym=15;
                    }
                    else
                    {
                        yp=15;
                        ym=40;
                    }
                }
                else
                {
                    xp=20;
                    xm=0;
                    if(growy)
                    {
                        yp=50;
                        ym=30;
                    }
                    else
                    {
                        yp=30;
                        ym=50;
                    }
                }
                
                break;
            case 1:
                if(growx)
                {
                    xp=0;
                    xm=20;
                    if(growy)
                    {
                        yp=50;
                        ym=30;
                    }
                    else
                    {
                        yp=30;
                        ym=50;
                    }
                }
                else
                {
                    xp=0;
                    xm=45;
                    if(growy)
                    {
                        yp=40;
                        ym=15;
                    }
                    else
                    {
                        yp=15;
                        ym=40;
                    }
                }
                break;
            case 2:
                if(growy)
                {
                    yp=45;
                    ym=0;
                    if(growx)
                    {
                        xp=40;
                        xm=15;
                    }
                    else
                    {
                        xp=15;
                        xm=40;
                    }
                }
                else
                {
                    yp=20;
                    ym=0;
                    if(growx)
                    {
                        xp=50;
                        xm=30;
                    }
                    else
                    {
                        xp=30;
                        xm=50;
                    }
                }
                break;
            case 3:
                if(growy)
                {
                    yp=0;
                    ym=20;
                    if(growx)
                    {
                        xp=50;
                        xm=30;
                    }
                    else
                    {
                        xp=30;
                        xm=50;
                    }
                }
                else
                {
                    yp=0;
                    ym=45;
                    if(growx)
                    {
                        xp=40;
                        xm=15;
                    }
                    else
                    {
                        xp=15;
                        xm=40;
                    }
                }
                break;
            default:
                if(growx)
                {
                    xp=50;
                    xm=0;
                }
                else
                {
                    xp=0;
                    xm=50;
                }
                if(growy)
                {
                    yp=50;
                    ym=0;
                }
                else
                {
                    yp=0;
                    ym=50;
                }
                break;
        }


        int[] wheel = new int[4];
        wheel[0]=xp;
        wheel[1]=wheel[0] +xm;
        wheel[2]=wheel[1] +yp;
        wheel[3]=wheel[2] +ym;
        
        float dir=Random.Range(0f,99f);
        int i=0;
        while(dir>wheel[i])
            i++;
        return i;
        // 0= +x 1= -x 2= +y 3= -y
    }




    void PathG(coord curent,coord finish,bool path)
    {
        int distanceLeft=distance;
        int dir=roulettewheel(-1, curent, finish);
        addCell(dir,ref curent,ref finish);
        int lastDir=dir;
        while ((curent.x<finish.x-2 || curent.x>finish.x+2) || (curent.y<finish.y-2 || curent.y>finish.y+2))
        {

            dir=roulettewheel(lastDir, curent, finish);
            //Debug.Log(curent.x + "|"+curent.y+'|'+finish.x + ' '+finish.y+' ');
            addCell(dir,ref curent,ref finish);
            //Debug.Log(curent.x + "|"+curent.y+'|'+finish.x + ' '+finish.y+' ');
            lastDir=dir;
            distanceLeft--;
            if(distanceLeft==0 && path)
            {
                distanceLeft=distance;
                Debug.Log("path nou");
                initPoints(curent.x,curent.y,Random.Range(0,lines),Random.Range(0,columns),false);
                
            }
        }
        Debug.Log("path complet");



    }

    void initPoints(int sx,int sy,int fx,int fy,bool path)
    {
        coord curent;
        coord finish;

        curent.x=sx;
        curent.y=sy;
        state[curent.x,curent.y]=1;

        finish.x=fx;
        finish.y=fy;

        for (var i = -2; i < 3; i++)
        {
            for (var j = -2; j < 3 ; j++)
            {
                if(finish.x+i<lines && finish.y+j<columns && finish.x+i>0 && finish.y+j>0)
                state[finish.x+i,finish.y+j]=1;
            }
        }
        PathG( curent,finish,path);
    }

    void Start()
    {
        for (var i = 0; i < lines; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                state[i,j]=0;
            }
        }

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
        distance=(int)(Vector3.Distance(m[4,4].position(), m[lines-10,columns-10].position())/4);
        Debug.Log(distance);
        initPoints(4,4,lines-10,columns-10, true);

        //inaltimi initiale - pentru test
        for(int i = 0;i<lines;i++)
        {
            for (var j = 0; j < columns; j++)
            {
                //store height
                if(state[i,j]==1)
                 {m[i,j].height = 60;
                 //else
                    //m[i,j].height = 3 + Random.Range(Vector3.Distance(m[0,0].position(), m[i,j/2].position())/5 - 2f, Vector3.Distance(m[0,0].position(), m[i,j/2].position())/5 + 2f);
                o[i,j].transform.position = o[i,j].transform.position + new Vector3(0, m[i,j].height / 2, 0);
                o[i,j].transform.localScale = new Vector3(baseScale, m[i,j].height, baseScale);
                 }
                
                
            }
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
