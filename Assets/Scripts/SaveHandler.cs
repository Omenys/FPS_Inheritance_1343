using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class SaveHandler : MonoBehaviour
{

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            SaveData sd = new SaveData();
            sd.playerPosition = FindObjectOfType<FPSController>().transform.position;

            string jsonText = JsonUtility.ToJson(sd);
            Debug.Log(jsonText);

            string path = Path.Combine(Application.persistentDataPath, "save.json");
            File.WriteAllText(path, jsonText);

            Debug.Log("Saved data to: " + path);
        }
    }
}

[System.Serializable]
public class SaveData
{
    public Vector3 playerPosition;

}
