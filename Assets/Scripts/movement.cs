using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    Vector3 up = Vector3.zero;
    Vector3 right = new Vector3(0, 90, 0);
    Vector3 down = new Vector3(0, 180, 0);
    Vector3 left = new Vector3(0, 270, 0);
    int case1 = 0;

    Vector3 currentDirection = Vector3.zero;

    Vector3 nextPos, destination, direction;

    float speed = 5f;
    bool moved;

    // Start is called before the first frame update
    void Start()
    {
        currentDirection = up;
        case1 = 0;
        nextPos = Vector3.forward;
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //nextPos = Vector3.forward;
            //currentDirection = up;
            nextPos = forward();
            //Debug.Log(nextPos);
            moved = true;
            if (Vector3.Distance(destination, transform.position) <= 0.00001f)
                destination = transform.position + nextPos;

        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //nextPos = Vector3.right;
            currentDirection += new Vector3(0, 90, 0);
            case1++;
            case1 %= 4;
            Debug.Log("direction" + currentDirection);
            transform.localEulerAngles = currentDirection;
            nextPos = forward();
            //Debug.Log(nextPos);
            moved = true;
            if (Vector3.Distance(destination, transform.position) <= 0.00001f)
                destination = transform.position + nextPos;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            //nextPos = Vector3.back;
            //case1 += 2;
            //case1 %= 4;
            nextPos = -forward();
            //Debug.Log(nextPos);
            //currentDirection += new Vector3(0, 180, 0);
            moved = true;
            if (Vector3.Distance(destination, transform.position) <= 0.00001f)
                destination = transform.position + nextPos;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            currentDirection += new Vector3(0, -90, 0);
            case1= case1 +4 -1;
            Debug.Log(case1);
            case1 %= 4;
            transform.localEulerAngles = currentDirection;
            nextPos = forward();
            //Debug.Log(nextPos);
            moved = true;
            if (Vector3.Distance(destination, transform.position) <= 0.00001f)
                destination = transform.position + nextPos;
        }

        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        //if(Vector3.Distance(destination,transform.position)<=0.00001f)
        //{
        //    if(moved)
        //    {
        //        destination = transform.position + nextPos;
        //        //direction = nextPos;
        //        moved = false;
        //    }

        //}

    }

    Vector3 forward()
    {
        Vector3 pos = Vector3.zero;
        //Debug.Log(transform.localEulerAngles.y);
        switch (case1)
        {
            case 0:
                pos = new Vector3(0, 0, 1);
                break;
            case 1:
                pos = new Vector3(1, 0, 0);
                break;
            case 2:
                pos = new Vector3(0, 0, -1);
                break;
            case 3:
                pos = new Vector3(-1, 0, 0);
                break;
            

        }
        Debug.Log("pos: " + pos);
        return pos;
    }
}

/////