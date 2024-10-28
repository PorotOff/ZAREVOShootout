using System.IO;
using UnityEngine;

public class JSONFileManager
{
    private string filePath;

    public JSONFileManager(string fileName)
    {
        string directoryPath = Path.Combine(Application.dataPath, "GameResources", "Saves");

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        filePath = Path.Combine(directoryPath, fileName);
    }

    public void Save<T>(T saveData)
    {
        string jsonData = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(filePath, jsonData);
    }
    public T Load<T>(T saveDataByDefault = default(T))
    {
        if (!File.Exists(filePath) && saveDataByDefault != null)
        {
            Save(saveDataByDefault);
            return saveDataByDefault;
        }
        
        string jsonSavedData = File.ReadAllText(filePath);
        var saveData = JsonUtility.FromJson<T>(jsonSavedData);

        return saveData;
    }
}