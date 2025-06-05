using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public DraggableUI[] puzzlePiecesUI;           // UI panel puzzle pieces
    public GameObject[] hiddenPuzzlePieces;        // Hidden pieces in the scene
    public GameObject successMessage;

    void Start()
    {
        successMessage.SetActive(false);

        // Assign unique IDs and load positions
        for (int i = 0; i < puzzlePiecesUI.Length; i++)
        {
            puzzlePiecesUI[i].pieceID = "Piece_" + i;
            puzzlePiecesUI[i].LoadPosition(); // Load saved position
        }

        // Hide all puzzle pieces in the scene at start
        foreach (var piece in hiddenPuzzlePieces)
        {
            piece.SetActive(false);
        }
    }

    public void RevealPiece(int index)
    {
        Debug.Log("Revealing piece at index: " + index);

        if (index >= 0 && index < hiddenPuzzlePieces.Length)
        {
            hiddenPuzzlePieces[index].SetActive(true);
        }
        else
        {
            Debug.LogWarning("Invalid piece index: " + index);
        }
    }

    public void CheckCompletion()
    {
        foreach (var piece in puzzlePiecesUI)
        {
            if (piece.enabled) return; // Not locked yet
        }

        successMessage.SetActive(true); // Puzzle complete!
    }

    public void ResetSavedPositions()
    {
        foreach (var piece in puzzlePiecesUI)
        {
            PlayerPrefs.DeleteKey(piece.pieceID + "_x");
            PlayerPrefs.DeleteKey(piece.pieceID + "_y");
        }

        PlayerPrefs.Save();
    }
}
