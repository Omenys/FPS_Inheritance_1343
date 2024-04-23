using System.IO;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    string path;

    void Start()
    {
        path = Path.Combine(Application.persistentDataPath, "save.json");
    }
    void Update()
    {

        /*string path = Path.Combine(Application.persistentDataPath, "save.json");

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            SaveData sd = new SaveData();
            sd.playerPosition = FindObjectOfType<FPSController>().transform.position;

            string jsonText = JsonUtility.ToJson(sd);
            Debug.Log(jsonText);

            File.WriteAllText(path, jsonText);

            Debug.Log("Saved data to: " + path);
        }

        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            string saveText = File.ReadAllText(path);
            Debug.Log("Loaded data from: " + saveText);

            SaveData myData = JsonUtility.FromJson<SaveData>(saveText);
            FindObjectOfType<FPSController>().transform.position = myData.playerPosition;
        }*/
    }

    public void OnSave()
    {

        SaveData sd = new SaveData();
        sd.playerPosition = FindObjectOfType<FPSController>().transform.position;

        string jsonText = JsonUtility.ToJson(sd);
        Debug.Log(jsonText);

        File.WriteAllText(path, jsonText);

        Debug.Log("Saved data to: " + path);

    }

    public void OnLoad()
    {

        if (File.Exists(path))
        {
            string saveText = File.ReadAllText(path);
            Debug.Log("Loaded data from: " + saveText);

            SaveData myData = JsonUtility.FromJson<SaveData>(saveText);
            FindObjectOfType<FPSController>().transform.position = myData.playerPosition;
        }

    }

}

[System.Serializable]
public class SaveData
{
    public Vector3 playerPosition;

}
