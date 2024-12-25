using System.IO;
using UnityEngine;

public class JSONSaveLoad
{
    private string fileDirectory;
    private string filePath;

    public JSONSaveLoad(string fileDirectory, string fileName)
    {
        this.fileDirectory = fileDirectory;
        CheckOrCreateDirectory();

        filePath = Path.Combine(fileDirectory, fileName);
        CheckOrCreateFile();
    }

    private void CheckOrCreateDirectory()
    {
        if (!Directory.Exists(fileDirectory))
        {
            Directory.CreateDirectory(fileDirectory);
        }
    }

    private void CheckOrCreateFile()
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "{}");
        }
    }

    public void Save<T>(T saveData)
    {
        string jsonData = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(filePath, jsonData);
    }

    public T Load<T>()
    {
        string jsonSavedData = File.ReadAllText(filePath);
        T data = JsonUtility.FromJson<T>(jsonSavedData);

        return data;
    }
}