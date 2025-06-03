using UnityEngine;

public class ShowPanelOnce : MonoBehaviour
{
    public GameObject panel; // Assign in Inspector
    private static bool hasSeenPanel = false;

    void Start()
    {
        if (!hasSeenPanel)
        {
            panel.SetActive(true);
            hasSeenPanel = true;
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
