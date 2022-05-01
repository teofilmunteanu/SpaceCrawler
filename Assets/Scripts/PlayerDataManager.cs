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
    static int currentSystemIndex;
    static int currentPlanetIndex;
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

    void Start()
    {
        SceneManager.LoadScene("Planet0");
        PlayerDataManager.CurrentSolarSystemIndex = 0;
        PlayerDataManager.CurrentPlanetIndex = 0;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameObject.transform.position = new Vector3(0.5f,0,0.5f);
        gameObject.transform.rotation = Quaternion.identity;
    }
}
