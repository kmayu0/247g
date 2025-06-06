using UnityEngine;
using UnityEngine.UI;

public class InventoryPieceButton : MonoBehaviour
{
    public int pieceIndex; // index in PuzzleManager.hiddenPuzzlePieces
    public PuzzleManager puzzleManager;
    // public GameObject screenToDisableClickOn;

    private Button button;
    private string prefsKey;

    void Start()
    {
        button = GetComponent<Button>();
        prefsKey = "ButtonClicked_" + pieceIndex;

        // Hide button if it was clicked before (persisted)
        if (PlayerPrefs.GetInt(prefsKey, 0) == 1)
        {
            gameObject.SetActive(false);
        }
        else
        {
            button.onClick.AddListener(OnPieceClicked);
        }
    }

    public void OnPieceClicked()
    {
           if (screenToDisableClickOn != null && screenToDisableClickOn.activeInHierarchy)
        {
            Debug.Log("Click ignored: this button is disabled on the current screen.");
            return;
        }
        if (puzzleManager != null)
        {
            puzzleManager.RevealPiece(pieceIndex);
        }
        else
        {
            Debug.LogWarning("PuzzleManager not assigned!");
        }

        // Hide this button and save the clicked state
        gameObject.SetActive(false);
        PlayerPrefs.SetInt(prefsKey, 1);
        PlayerPrefs.Save();
    }
}
