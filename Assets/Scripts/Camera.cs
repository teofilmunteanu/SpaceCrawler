using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("u"))
        {
            transform.localPosition = new Vector3(0, 4, -5);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

    }
}
