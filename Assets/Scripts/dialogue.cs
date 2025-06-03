using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem; // For the new Input System

public class DialogueImageSwitcher : MonoBehaviour
{
    public Image dialogueImage;
    public Sprite[] dialogueSprites;
    public GameObject nextButton;
    private int currentIndex = 0;

    void Start()
    {
        if (dialogueSprites.Length > 0)
        {
            dialogueImage.sprite = dialogueSprites[0];
        }
        if (nextButton != null)
        {
            nextButton.SetActive(false);
        }
    }

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            AdvanceDialogue();
        }
    }

    void AdvanceDialogue()
    {
        currentIndex++;
        if (currentIndex < dialogueSprites.Length)
        {
            dialogueImage.sprite = dialogueSprites[currentIndex];
        }
        else
        {
            Debug.Log("End of dialogue.");
             if (nextButton != null)
            {
                nextButton.SetActive(true);
            }

            // Optionally, disable further clicking
            this.enabled = false;

        }
    }
}
