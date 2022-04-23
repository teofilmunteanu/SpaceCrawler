using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SerializationManager
{
    public static string Save(string fileName, object data)
    {
        string saveFolderPath = Application.dataPath + "/saves"; //or persistentDataPath
        if (!Directory.Exists(saveFolderPath))
        {
            Directory.CreateDirectory(saveFolderPath);
        }

        string json = JsonUtility.ToJson(data, true);

        Debug.Log("Data written in " + saveFolderPath + ":\n" + json);
        File.WriteAllText(saveFolderPath + "/" + fileName + ".json", json);

        return json;
    }

    public static T Load<T>(string json)
    { 
        return JsonUtility.FromJson<T>(json);
    }
}
