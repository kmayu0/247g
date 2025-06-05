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

    public int pieceIndex;

    public string pieceID; // ✅ NEW

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition;
        LoadPosition();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;

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
            SavePosition(); // ✅ NEW
            this.enabled = false;
            if (puzzleManager != null)
            {
                puzzleManager.CheckCompletion();
            }
        }
        else
        {
            SavePosition(); // ✅ NEW (save even if not snapped, so user drag persists)
        }
    }

    public void SavePosition() // ✅ NEW
    {
        PlayerPrefs.SetFloat(pieceID + "_x", rectTransform.anchoredPosition.x);
        PlayerPrefs.SetFloat(pieceID + "_y", rectTransform.anchoredPosition.y);
        PlayerPrefs.Save();
    }

    public void LoadPosition()
    {
        if (rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>();
        }

        if (string.IsNullOrEmpty(pieceID))
        {
            Debug.LogWarning($"[DraggableUI] pieceID not set on {gameObject.name}");
            return;
        }

        if (PlayerPrefs.HasKey(pieceID + "_x") && PlayerPrefs.HasKey(pieceID + "_y"))
        {
            float x = PlayerPrefs.GetFloat(pieceID + "_x");
            float y = PlayerPrefs.GetFloat(pieceID + "_y");
            rectTransform.anchoredPosition = new Vector2(x, y);
        }
    }
}
