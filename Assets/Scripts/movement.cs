using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{

    Vector3 up = Vector3.zero;
    int case1 = 0;

    Vector3 currentDirection = Vector3.zero;

    Vector3 nextPos, destination;

    float speed = 5f;
    bool moved;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
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
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        if (!moved)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                nextPos = forward();
                moved = true;

            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentDirection += new Vector3(0, 90, 0);
                case1++;
                case1 %= 4;
                nextPos = forward();
                moved = true;

            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentDirection += new Vector3(0, 180, 0);
                case1 += 2;
                case1 %= 4;
                nextPos = forward();
                moved = true;

            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {

                currentDirection += new Vector3(0, -90, 0);
                case1 = case1 + 4 - 1;
                case1 %= 4;
                nextPos = forward();
                moved = true;

            }
        }
        
       
        if (Vector3.Distance(destination, transform.position) <= 0.00001f)
        {
            if (moved)
            {
                transform.localEulerAngles = currentDirection;
                 destination = transform.position + nextPos;
                moved = false;
            }

        }

    }

    Vector3 forward()
    {
        Vector3 pos = Vector3.zero;
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
        return pos;
    }
}

/////