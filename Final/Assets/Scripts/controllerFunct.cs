using UnityEngine;
using UnityEngine.InputSystem;

public class controllerFunct : MonoBehaviour
{
    public InputActionReference pauseAction;
    public InputActionReference resetAction;
    public InputActionReference quitAction;

    private bool paused = false;

    void OnEnable()
    {
        pauseAction.action.Enable();
        resetAction.action.Enable();
        quitAction.action.Enable();

        pauseAction.action.performed += PausePressed;
        resetAction.action.performed += ResetPressed;
        quitAction.action.performed += QuitPressed;
    }

    void OnDisable()
    {
        pauseAction.action.performed -= PausePressed;
        resetAction.action.performed -= ResetPressed;
        quitAction.action.performed -= QuitPressed;

        pauseAction.action.Disable();
        resetAction.action.Disable();
        quitAction.action.Disable();
    }

    private void PausePressed(InputAction.CallbackContext ctx)
    {
        paused = !paused;

        Time.timeScale = paused ? 0f : 1f;

        Debug.Log(paused ? "Paused" : "Resumed");
    }

    private void ResetPressed(InputAction.CallbackContext ctx)
    {
        Debug.Log("Reset Pressed");

        // teleport back to spawn or reload scene
    }

    private void QuitPressed(InputAction.CallbackContext ctx)
    {
        Debug.Log("Quit Pressed");

        Application.Quit();
    }
}
