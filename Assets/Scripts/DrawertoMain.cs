using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToKitchen : MonoBehaviour
{
    public string sceneToLoad = "MainKitchen";

    void OnMouseDown()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

