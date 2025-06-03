using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    public string fullText = "Typing like a typewriter!";
    public float typingSpeed = 0.05f;
    public Button nextButton; // Optional

    void Start()
    {
        if (tmpText == null)
        {
            Debug.LogError("tmpText is not assigned!");
            return;
        }

        if (nextButton != null)
        {
            nextButton.gameObject.SetActive(false); // hide at start
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

        if (nextButton != null)
        {
            nextButton.gameObject.SetActive(true); // show when done
        }
    }
}
