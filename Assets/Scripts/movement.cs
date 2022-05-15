using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    Vector3 up = Vector3.zero;
    public static int case1 = 0;
    public static int turn = 0;

    Vector3 currentDirection = Vector3.zero;

    Vector3 nextPos;
    public static Vector3 destination;

    float speed = 5f;
    float moveDistance = Mapa.baseScale;
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
        destination = new Vector3(Mapa.tiles[0, 0].x, Mapa.tiles[0, 0].height, Mapa.tiles[0, 0].z);//to be removed when a movement check is added(so it can be moved by effects)
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
                turn++;

            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentDirection += new Vector3(0, 90, 0);
                case1++;
                case1 %= 4;
                nextPos = forward();
                moved = true;
                turn++;

            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentDirection += new Vector3(0, 180, 0);
                case1 += 2;
                case1 %= 4;
                nextPos = forward();
                moved = true;
                turn++;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {

                currentDirection += new Vector3(0, -90, 0);
                case1 = case1 + 4 - 1;
                case1 %= 4;
                nextPos = forward();
                moved = true;
                turn++;
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
            Debug.Log(turn);
        }
    }

    Vector3 forward()
    {
        Vector3 pos = Vector3.zero;
        switch (case1)
        {
            case 0:
                pos = new Vector3(0, 0, moveDistance);
                break;
            case 1:
                pos = new Vector3(moveDistance, 0, 0);
                break;
            case 2:
                pos = new Vector3(0, 0, -moveDistance);
                break;
            case 3:
                pos = new Vector3(-moveDistance, 0, 0);
                break;
        }
        return pos;
    }
}

/////