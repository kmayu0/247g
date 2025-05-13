using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenButton : MonoBehaviour
{
    public string sceneToLoad;

    void OnMouseDown()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

