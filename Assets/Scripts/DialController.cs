using UnityEngine;
using UnityEngine.EventSystems;

public class DialController : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Camera uiCamera;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        // Automatically grab the correct camera if one is assigned to the Canvas
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas.renderMode != RenderMode.ScreenSpaceOverlay)
            uiCamera = canvas.worldCamera;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // No-op: we don't need to track initial angle anymore
        OnDrag(eventData); // Snap immediately on click
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldMousePosition;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, uiCamera, out worldMousePosition);

        Vector2 direction = worldMousePosition - rectTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Snap to 45-degree increments
        float snappedAngle = Mathf.Round(angle / 45f) * 45f;

        // Rotate the dial
        rectTransform.rotation = Quaternion.Euler(0, 0, snappedAngle);
    }
}
