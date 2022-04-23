using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class PlanetMap
{
    public int id;

    public int mapTest1;
    public int mapTest2;

    public PlanetMap(int id, int t)
    {
        this.id = id;
        mapTest1 = t;
        mapTest2 = t + 1;
    }

    ////public float[,] heights;
    //item locations: item - Vector2D coordinate(list)
    //tiles locations: tile - Vector2D coordinate(list)
    //map heights+shape matrix
}

public class Planet
{
    public PlanetMap map;
    //items that can be found -> List<item> items;
    //specific tiles -> List<tiles> tiles;
}

public class SolarSystem
{
    public int nrOfPlanets;
    public Planet[] planets;

    public SolarSystem(int nrOfPlanets, Planet[] planets)
    {
        this.nrOfPlanets = nrOfPlanets;
        this.planets = planets;
    }
}

[System.Serializable]//doar partile generate trebuie stocate
public class PlanetMapsData
{
    public int TESTING;
    public PlanetMap[] planetMaps;
}

public class WorldMap : MonoBehaviour
{
    /******************singleton*****************/
    public static WorldMap WorldInstance { get; private set; }

    public const int totalNrOfPlanets = 3;
    public const int totalNrOfSystems = 2;

    public PlanetMapsData mapsData = new PlanetMapsData();
    public SolarSystem[] solarSystems = new SolarSystem[totalNrOfSystems];

    private void Awake()
    {
        if (WorldInstance != null && WorldInstance != this)
        {
            Destroy(this);
        }
        else
        {
            WorldInstance = this;
        }
    }
    /******************************************/

    void settingData()
    {
        //maps
        int id = 0;
        mapsData.planetMaps = new PlanetMap[]
        {
            new PlanetMap(id++, 123),
            new PlanetMap(id++, 334),
            new PlanetMap(id++, 574),
        };
        mapsData.TESTING = 111;

        //planets
        Planet[] planets = new Planet[totalNrOfPlanets];
        for (int i = 0; i < totalNrOfPlanets; i++)
        {
            planets[i] = new Planet();
            planets[i].map = mapsData.planetMaps[i];
        }
        
        //solar systems
        solarSystems[0] = new SolarSystem(0, new Planet[] { planets[0] }); ;
        solarSystems[1] = new SolarSystem(2, new Planet[] { planets[1], planets[2] });
    }

    void Start()
    {
        settingData();
        string json = SerializationManager.Save("world_save", mapsData);

        PlanetMapsData loadedData = SerializationManager.Load<PlanetMapsData>(json);
        Debug.Log("loaded " + loadedData.TESTING);
    }
}
