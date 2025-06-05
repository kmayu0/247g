using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public DraggableUI[] puzzlePiecesUI;           // UI panel puzzle pieces
    public GameObject[] hiddenPuzzlePieces;        // Hidden pieces in the scene
    public GameObject successMessage;
    private const string PuzzleCompleteKey = "PuzzleComplete";
    private const string RevealedKeyPrefix = "PieceRevealed_";

    void Start()
    {
        bool puzzleComplete = PlayerPrefs.GetInt(PuzzleCompleteKey, 0) == 1;
        successMessage.SetActive(puzzleComplete);

        // Assign unique IDs and load positions
        for (int i = 0; i < puzzlePiecesUI.Length; i++)
        {
            puzzlePiecesUI[i].pieceID = "Piece_" + i;
            puzzlePiecesUI[i].LoadPosition();
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
        PlayerPrefs.SetInt(PuzzleCompleteKey, 1);
        PlayerPrefs.Save();
    }

    public void ResetSavedPositions()
    {
        foreach (var piece in puzzlePiecesUI)
        {
            PlayerPrefs.DeleteKey(piece.pieceID + "_x");
            PlayerPrefs.DeleteKey(piece.pieceID + "_y");
            PlayerPrefs.DeleteKey(RevealedKeyPrefix + piece.pieceIndex);
            PlayerPrefs.DeleteKey("Locked_" + piece.pieceID);
        }

        PlayerPrefs.DeleteKey(PuzzleCompleteKey); // Clear success flag
        PlayerPrefs.Save();
    }
    
    public void LockPiece(int index)
    {
        if (index < 0 || index >= puzzlePiecesUI.Length) return;

        var piece = puzzlePiecesUI[index];
        piece.enabled = false; // disable dragging
        PlayerPrefs.SetInt("Locked_" + piece.pieceID, 1); // Save locked state
        PlayerPrefs.Save();
    }

}
