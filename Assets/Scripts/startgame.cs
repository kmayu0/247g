using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;
    public string sceneToLoad = "Intro1";
    public float delayBeforeLoad = 0.3f;

    public DialManager dialManager; 

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(PlayAndLoad()));
    }

    private System.Collections.IEnumerator PlayAndLoad()
{
    if (clickSound != null)
        audioSource.PlayOneShot(clickSound);

    yield return new WaitForSeconds(delayBeforeLoad);

  
string[] dialNames = { "Dial1", "Dial2", "Dial3", "Dial4" }; 
foreach (string dialName in dialNames)
{
    PlayerPrefs.DeleteKey(dialName + "_DialAngle");
}
PlayerPrefs.Save();


    SceneManager.LoadScene(sceneToLoad);
}

}
