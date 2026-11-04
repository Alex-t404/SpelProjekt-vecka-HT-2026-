using UnityEngine;
using UnityEngine.SceneManagement; // Krävs för att hantera scener

public class SceneChanger : MonoBehaviour
{
    // Laddar nästa scen i Build Settings
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // Startar om den nuvarande scenen från början
    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
