using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    public string fullText = "Typing like a typewriter!";
    public float typingSpeed = 0.05f;
    public GameObject[] nextButtons; // Changed to array

    void Start()
    {
        if (tmpText == null)
        {
            Debug.LogError("tmpText is not assigned!");
            return;
        }

        if (nextButtons != null)
        {
            foreach (GameObject button in nextButtons)
            {
                if (button != null)
                    button.SetActive(false); // Hide each at start
            }
        }

        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        tmpText.text = "";
        foreach (char c in fullText)
        {
            tmpText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        if (nextButtons != null)
        {
            foreach (GameObject button in nextButtons)
            {
                if (button != null)
                    button.SetActive(true); // Show each when done
            }
        }
    }
}
