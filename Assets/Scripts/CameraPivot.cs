using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
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
            Debug.Log("ceva");
            transform.localPosition = new Vector3(0, 0, 0);
            transform.localRotation = Quaternion.Euler(new Vector3(15.215f, 59.758f, -1.002f));
        }


        if (Input.GetKeyDown("i"))
        {
            transform.localPosition = new Vector3(0, 0, 0);
            transform.localRotation = Quaternion.Euler(new Vector3(15.215f, 134.229f, -1.002f));
        }

        if (Input.GetKeyDown("o"))
        {
            transform.localPosition = new Vector3(0, 0, 0);
            transform.localRotation = Quaternion.Euler(new Vector3(15.215f, 216.2f, -1.002f));
        }

        if (Input.GetKeyDown("p"))
        {
            transform.localPosition = new Vector3(0, 0, 0);
            transform.localRotation = Quaternion.Euler(new Vector3(15.215f, 311.469f, -1.002f));
        }
    }
}