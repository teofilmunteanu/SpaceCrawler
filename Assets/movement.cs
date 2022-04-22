using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    Vector3 up = Vector3.zero;
    Vector3 right = new Vector3(0,90,0);
    Vector3 down = new Vector3(0, 180, 0);
    Vector3 left = new Vector3(0, 270, 0);
    Vector3 currentDirection = Vector3.zero;

    Vector3 nextPos, destnation, direction;

    float speed = 5f;
    bool moved;

    // Start is called before the first frame update
    void Start()
    {
        currentDirection = up;
        nextPos = Vector3.forward;
        destnation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, destnation, speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            nextPos = Vector3.forward;
            currentDirection = up;
            moved = true;

        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            nextPos = Vector3.right;
            currentDirection = right;
            moved = true;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            nextPos = Vector3.back;
            currentDirection = down;
            moved = true;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            nextPos = Vector3.left;
            currentDirection = left;
            moved = true;
        }

        if(Vector3.Distance(destnation,transform.position)<=0.00001f)
        {
            transform.localEulerAngles = currentDirection;
            if(moved)
            {
                destnation = transform.position + nextPos;
                direction = nextPos;
                moved = false;
            }
            
        }

    }
}

/////