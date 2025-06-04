using UnityEngine;

public class ClickSoundPlayer : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayClickSound()
    {
        if (audioSource != null)
            audioSource.Play();
    }
}
