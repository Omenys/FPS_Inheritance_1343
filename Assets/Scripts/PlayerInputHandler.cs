using UnityEngine;


public class PlayerInputHandler : MonoBehaviour
{
    public IA_Player controls;

    // Start is called before the first frame update
    void Start()
    {
        if (controls == null)
        {
            controls = new IA_Player();
        }

    }

    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new IA_Player();
        }

        controls.Enable();
    }

    private void OnDisable()
    {
        if (controls == null)
        {
            controls = new IA_Player();
        }
        controls.Disable();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
