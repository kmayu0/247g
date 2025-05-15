using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenButton : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
