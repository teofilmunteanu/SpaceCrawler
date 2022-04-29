using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

class PlayerData
{
    static Dictionary<string, bool> completedPlanets = new Dictionary<string, bool>();
    public static Dictionary<string, bool> CompletedPlanets { get => completedPlanets; set => completedPlanets = value; }
}

public class SceneChangeManager : MonoBehaviour
{

    void Start()
    {
        //when planet is completed 
        //PlayerData pd = new PlayerData();
        PlayerData.CompletedPlanets["Planet0"] = true;//better data type?? something that can be accessed instantly, but doesn't need an index and a value, just an index, kinda like a list
        PlayerData.CompletedPlanets["Planet1"] = true;
        PlayerData.CompletedPlanets["Planet3"] = true;
    }
    public void loadPlanet()
    {
        //Button has to have the same name as the scene
        GameObject planetButton = EventSystem.current.currentSelectedGameObject;
        
        //If one of the previous solar system's planets is complete
            SceneManager.LoadScene(planetButton.name);
    }
}
