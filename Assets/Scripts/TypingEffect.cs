using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    public string fullText = "Typing like a typewriter!";
    public float typingSpeed = 0.05f;
    public Button nextButton; // 👈 Assign this in the Inspector

    void Start()
    {
        if (tmpText == null || nextButton == null)
        {
            Debug.LogError("tmpText or nextButton not assigned!");
            return;
        }

        nextButton.gameObject.SetActive(false); // 👈 hide at start
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

        nextButton.gameObject.SetActive(true); // 👈 show when done
    }
}
