using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    bool isPaused = false;

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
        if (ctx.performed)
        {

            if (!isPaused)
            {
                isPaused = true;
                SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
                Time.timeScale = 0;
            }
            else
            {
                isPaused = false;
                SceneManager.UnloadSceneAsync("PauseMenu");
                Time.timeScale = 1;
            }
        }
    }

}
