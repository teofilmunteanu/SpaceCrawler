using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataManager : MonoBehaviour
{
    /******************singleton***************/
    public static PlayerDataManager PlayerInstance { get; private set; }
    private void Awake()
    {
        if (PlayerInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            PlayerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }
    /******************************************/

    // static Dictionary<string, bool> completedPlanets = new Dictionary<string, bool>();
    // public static Dictionary<string, bool> CompletedPlanets { get => completedPlanets; set => completedPlanets = value; }
    public static int currentSystemIndex;
    static int currentPlanetIndex;
    public static bool[] completedSystems = new bool[WorldDataManager.totalNrOfSystems];
    //static bool[] completedPlanets = new bool[WorldDataManager.totalNrOfPlanets];

    public static int CurrentSolarSystemIndex { get => currentSystemIndex; set => currentSystemIndex = value; }
    public static int CurrentPlanetIndex { get => currentPlanetIndex; set => currentPlanetIndex = value; }
    public static bool[] CompletedSystems { get => completedSystems; set => completedSystems = value; }
    //public static bool[] CompletedPlanets { get => completedPlanets; set => completedPlanets = value; }

    // void OnTriggerEnter (Collider col)
    // {
    //     if(col.gameObject.name == "Coordinate")
    //     {
    //         completedSystems[currentSystemIndex] = true;
    //         Debug.Log("Completed system"+currentSystemIndex);
    //         //other things that happen when planet is completed
    //     }
    // }

    void Start()
    {
        //SceneManager.LoadScene("Planet0");
        PlayerDataManager.CurrentSolarSystemIndex = 0;
        PlayerDataManager.CurrentPlanetIndex = 0;

        //testing
        completedSystems[0] = true;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //So it's at the height of the first tile
        //Might be changed if the player should go to his last position in a map(his position saved in -playerprefs or json)
        gameObject.transform.position = new Vector3(0,Mapa.tiles[0,0].height,0); 
        gameObject.transform.rotation = Quaternion.identity;
    }
}
