using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public DraggableUI[] puzzlePiecesUI;           // UI panel puzzle pieces
    public GameObject[] hiddenPuzzlePieces;        // Hidden pieces in the scene
    public GameObject successMessage;

    private const string RevealedKeyPrefix = "PieceRevealed_";

    void Start()
    {
        successMessage.SetActive(false);

        // Assign unique IDs and load positions
        for (int i = 0; i < puzzlePiecesUI.Length; i++)
        {
            puzzlePiecesUI[i].pieceID = "Piece_" + i;
            puzzlePiecesUI[i].LoadPosition(); // Load saved position
        }

        // Load revealed state and update pieces visibility
        for (int i = 0; i < hiddenPuzzlePieces.Length; i++)
        {
            bool revealed = PlayerPrefs.GetInt(RevealedKeyPrefix + i, 0) == 1;
            hiddenPuzzlePieces[i].SetActive(revealed);
        }
    }

    public void RevealPiece(int index)
    {
        Debug.Log("Revealing piece at index: " + index);

        if (index >= 0 && index < hiddenPuzzlePieces.Length)
        {
            hiddenPuzzlePieces[index].SetActive(true);

            // Save revealed state
            PlayerPrefs.SetInt(RevealedKeyPrefix + index, 1);
            PlayerPrefs.Save();
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
            PlayerPrefs.DeleteKey(RevealedKeyPrefix + piece.pieceIndex);  // Also clear revealed flags
        }

        PlayerPrefs.Save();
    }
}
