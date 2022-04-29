using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneChangeManager : MonoBehaviour
{
    public void loadPlanet()
    {
        //Button has to have the same name as the scene
        GameObject planetButton = EventSystem.current.currentSelectedGameObject;
        if(planetButton.name == "Planet0")
            SceneManager.LoadScene("Planet0");
        else
        {
            int selectedPlanetIndex = System.Int32.Parse(Regex.Match(planetButton.name, @"\d+").Value);
            int selectedPlanetSystemIndex = WorldDataManager.planets[selectedPlanetIndex].SolarSystemIndex;

            //If one of the selected planet's previous solar system's planets is complete = If the selected planet's previous system is complete
            if(PlayerDataManager.CompletedSystems[selectedPlanetSystemIndex-1])
            {
                SceneManager.LoadScene(planetButton.name);
            } 
            else
            {
                Debug.Log("Planet inaccessible, complete one of the neighbouring planets.");
            }
        }    
    }

     void Start()
    {
        //when planet is completed 
        //PlayerDataManager pd = new PlayerDataManager();
        // PlayerDataManager.CompletedPlanets["Planet0"] = true;
        PlayerDataManager.CompletedSystems[0] = true;
    }
}
