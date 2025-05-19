using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader_Demo : MonoBehaviour
{
    // Call this function from your Button
    public void LoadZoomedPurpleScene()
    {
        SceneManager.LoadScene("Zoomed Purple Clock");
    }
}
