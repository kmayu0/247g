using UnityEngine;
using UnityEngine.UI;

public class InventoryPieceButton : MonoBehaviour
{
    public int pieceIndex; // index in PuzzleManager.hiddenPuzzlePieces
    public PuzzleManager puzzleManager;

    void Start()
    {
        // Optional: if this script is on a Button component, add the listener automatically
        GetComponent<Button>().onClick.AddListener(OnPieceClicked);
    }

    public void OnPieceClicked()
    {
        if (puzzleManager != null)
        {
            puzzleManager.RevealPiece(pieceIndex);
        }
        else
        {
            Debug.LogWarning("PuzzleManager not assigned!");
        }
    }
}
