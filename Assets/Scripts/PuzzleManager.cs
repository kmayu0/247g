using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public DraggableUI[] puzzlePieces;
    public GameObject successMessage;

    void Start()
    {
        successMessage.SetActive(false);
    }

    public void CheckCompletion()
    {
        foreach (var piece in puzzlePieces)
        {
            if (piece.enabled) return; // Still draggable → not snapped yet
        }

        successMessage.SetActive(true); // All snapped!
    }
}
