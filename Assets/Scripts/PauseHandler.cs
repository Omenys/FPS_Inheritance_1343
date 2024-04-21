using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        InputManager.controls.UI.Pause.performed += Pause;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause(InputAction.CallbackContext ctx)
    {
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
    }

}
