using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{


    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void QuitGame()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void GoToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToEndMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("EndMenu");
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainGame");
    }

    public void GoToScene(string sceneName)
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene(sceneName);
    }
}
