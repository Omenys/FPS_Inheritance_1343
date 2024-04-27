using System.IO;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    string path;

    void Start()
    {
        path = Path.Combine(Application.persistentDataPath + "save.json");
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
        try
        {
            FPSController player = FindObjectOfType<FPSController>();

            SaveData sd = new SaveData();
            sd.playerPosition = FindObjectOfType<FPSController>().transform.position;
            Debug.Log("Saved player position: " + sd.playerPosition);

            sd.playerHealth = FindObjectOfType<FPSController>().health;
            Debug.Log("Saved player health: " + sd.playerHealth);

            sd.currentAmmo = FindObjectOfType<Gun>().GetAmmo();
            Debug.Log("Saved ammo: " + sd.currentAmmo);

            sd.currentGunIndex = FindObjectOfType<FPSController>().GetCurrentGun();
            Debug.Log("Saved current gun: " + sd.currentGunIndex);


            string jsonText = JsonUtility.ToJson(sd);
            Debug.Log(jsonText);

            File.WriteAllText(path, jsonText);

            Debug.Log("Saved data to: " + path);
        }
        catch (System.IO.FileNotFoundException)
        {
            Debug.Log("That file does not exist");
        }

        catch (System.Exception e)
        {
            Debug.Log(e);
        }


    }

    public void OnLoad()
    {

        if (File.Exists(path))
        {
            try
            {
                string saveText = File.ReadAllText(path);
                Debug.Log("Loaded data from: " + saveText);

                SaveData myData = JsonUtility.FromJson<SaveData>(saveText);

                FindObjectOfType<CharacterController>().enabled = false; //Disable character controller
                FindObjectOfType<FPSController>().transform.position = myData.playerPosition; // Save position
                FindObjectOfType<CharacterController>().enabled = true; //Reenable character controller
            }
            catch (System.IO.FileNotFoundException)
            {
                Debug.Log("That file does not exist");
            }

            catch (System.Exception e)
            {
                Debug.Log(e);
            }
        }

    }

}

[System.Serializable]
public class SaveData
{
    public Vector3 playerPosition;
    public int playerHealth;
    public int currentAmmo;
    public int currentGunIndex;

}
