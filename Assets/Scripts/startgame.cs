using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;
    public string sceneToLoad = "intro";
    public float delayBeforeLoad = 0.3f;

    public DialManager dialManager; // Assign this in the Inspector

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(PlayAndLoad()));
    }

    private System.Collections.IEnumerator PlayAndLoad()
    {
        if (clickSound != null)
            audioSource.PlayOneShot(clickSound);

        yield return new WaitForSeconds(delayBeforeLoad);

        // Reset dial memory
        if (dialManager != null)
            dialManager.ResetDialMemory();

        SceneManager.LoadScene(sceneToLoad);
    }
}
