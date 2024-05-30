using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneIndexFinder : MonoBehaviour
{
    void Start()
    {
        // Get the active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Get the build index of the active scene
        int sceneIndex = currentScene.buildIndex;

        // Print the scene index to the console
        Debug.Log("Current Scene Index: " + sceneIndex);
    }
}