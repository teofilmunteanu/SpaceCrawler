using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public void loadPlanet0()
    {
        SceneManager.LoadScene("Planet0");
    }

    public void loadPlanet1()
    {
        SceneManager.LoadScene("Planet1");
    }
}
