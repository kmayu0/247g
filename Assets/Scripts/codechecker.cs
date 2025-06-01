using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CodeChecker : MonoBehaviour
{
    public TMP_InputField codeInputField; // or TMP_InputField if using TMP
    public GameObject doorButton;     // The door button GameObject
    public string correctCode = "1234"; // Change this to your code

    public void CheckCode()
    {
        if (codeInputField.text == correctCode)
        {
            doorButton.SetActive(true);      // Show the door button
            codeInputField.gameObject.SetActive(false); // Hide input field
        }
        else
        {
            Debug.Log("Incorrect code.");
        }
    }
}
