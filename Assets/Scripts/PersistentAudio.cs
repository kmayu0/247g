using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentAudio : MonoBehaviour
{
    private static PersistentAudio instance;

    // Change this to the name of the scene where music should stop
    public string stopOnSceneName = "GameOverScene";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Listen for scene changes
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == stopOnSceneName)
        {
            Destroy(gameObject); // Kill audio and self-destruct
        }
    }

    void OnDestroy()
    {
        // Clean up the event listener when destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
