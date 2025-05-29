using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryUIRoot : MonoBehaviour
{
    private static InventoryUIRoot instance;

    [SerializeField] private string[] hiddenInScenes = { "startGame", "intro" };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        foreach (string sceneName in hiddenInScenes)
        {
            if (scene.name == sceneName)
            {
                gameObject.SetActive(false);
                return;
            }
        }

        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
