using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonWithSoundAndDelay : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;
    public string sceneToLoad = "intro";
    public float delayBeforeLoad = 0.3f; // sound length

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(PlayAndLoad()));
    }

    private System.Collections.IEnumerator PlayAndLoad()
    {
        if (clickSound != null)
            audioSource.PlayOneShot(clickSound);

        yield return new WaitForSeconds(delayBeforeLoad);

        SceneManager.LoadScene(sceneToLoad);
    }
}

