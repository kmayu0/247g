using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;

    public PuzzleManager puzzleManager;
    public RectTransform targetTransform;
    public float snapThreshold = 50f;

    public int pieceIndex; // 👈 Add this to match the hidden puzzle piece

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;

        // 👇 Reveal corresponding hidden puzzle piece on the scene
        if (puzzleManager != null)
        {
            puzzleManager.RevealPiece(pieceIndex);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        float distance = Vector2.Distance(rectTransform.anchoredPosition, targetTransform.anchoredPosition);
        if (distance < snapThreshold)
        {
            rectTransform.anchoredPosition = targetTransform.anchoredPosition;
            this.enabled = false; // Lock it in place
            if (puzzleManager != null)
            {
                puzzleManager.CheckCompletion();
            }
        }
    }
}
