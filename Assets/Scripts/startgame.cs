using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;
    public string sceneToLoad = "Intro1";
    public float delayBeforeLoad = 5f;

    public string[] puzzlePieceIDs = { }; 

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(PlayAndLoad()));
    }

    private System.Collections.IEnumerator PlayAndLoad()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
            yield return new WaitForSeconds(clickSound.length);
        }
        else
        {
            yield return new WaitForSeconds(delayBeforeLoad);
        }

        PlayerPrefs.DeleteAll(); 
        PlayerPrefs.Save();

        SceneManager.LoadScene(sceneToLoad);
    }
}
