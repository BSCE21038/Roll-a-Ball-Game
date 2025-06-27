using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This function will be called when "Play" button is clicked
    public void StartGame()
    {
        // Load the gameplay scene
        // ⚠️ Make sure the scene name matches the actual name in your "Scenes" folder
        SceneManager.LoadScene("GameScene");
    }

    // This function will be called when "Quit" button is clicked
    public void QuitGame()
    {
        // Only works in build, not in the Unity editor
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
