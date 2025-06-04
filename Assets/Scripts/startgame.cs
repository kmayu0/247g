using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;
    public string sceneToLoad = "Intro1";
    public float delayBeforeLoad = 5f;

    // Optional DialManager - can be null
    public DialManager dialManager;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(PlayAndLoad()));
    }

    private System.Collections.IEnumerator PlayAndLoad()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
            // Wait for the clip length instead of fixed delay
            yield return new WaitForSeconds(clickSound.length);
        }
        else
        {
            // If no clip, fallback to fixed delay
            yield return new WaitForSeconds(delayBeforeLoad);
        }

        if (dialManager != null)
        {
            // optional dialManager logic here
        }

        string[] dialNames = { "Dial1", "Dial2", "Dial3", "Dial4" };
        foreach (string dialName in dialNames)
        {
            PlayerPrefs.DeleteKey(dialName + "_DialAngle");
        }
        PlayerPrefs.Save();

        SceneManager.LoadScene(sceneToLoad);
    }
}
