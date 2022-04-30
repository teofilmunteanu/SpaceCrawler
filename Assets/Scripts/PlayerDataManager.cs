using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    /******************singleton***************/
    public static PlayerDataManager PlayerInstance { get; private set; }
    private void Awake()
    {
        if (PlayerInstance != null && PlayerInstance != this)
        {
            Destroy(this);
        }
        else
        {
            PlayerInstance = this;
        }
        
    }
    
    /******************************************/

    // static Dictionary<string, bool> completedPlanets = new Dictionary<string, bool>();
    // public static Dictionary<string, bool> CompletedPlanets { get => completedPlanets; set => completedPlanets = value; }
    static int currentSystemIndex = 0;
    static int currentPlanetIndex = 0;
    static bool[] completedSystems = new bool[WorldDataManager.totalNrOfSystems];
    //static bool[] completedPlanets = new bool[WorldDataManager.totalNrOfPlanets];

    public static int CurrentSolarSystemIndex { get => currentSystemIndex; set => currentSystemIndex = value; }
    public static int CurrentPlanetIndex { get => currentPlanetIndex; set => currentPlanetIndex = value; }
    public static bool[] CompletedSystems { get => completedSystems; set => completedSystems = value; }
    //public static bool[] CompletedPlanets { get => completedPlanets; set => completedPlanets = value; }

    void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.name == "Coordinate")
        {
            completedSystems[currentSystemIndex] = true;
            Debug.Log("Completed system"+currentSystemIndex);
            //other things that happen when planet is completed
        }
    }
}
