using UnityEngine;
using UnityEngine.EventSystems;

public class DialController : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Vector2 centerPoint;
    private float initialAngle;
    private float currentAngle;

    // Event that gets called when the dial is rotated
    public event System.Action<float> OnDialRotated;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Convert the pointer position to local space
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out var localPoint);
        
        // Record the initial angle when dragging starts
        centerPoint = rectTransform.rect.center;
        initialAngle = GetAngle(centerPoint, localPoint);
        currentAngle = rectTransform.eulerAngles.z;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Convert the pointer position to local space
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out var localPoint);
        
        // Calculate the current angle based on the drag position
        float currentAngle = GetAngle(centerPoint, localPoint);
        float angleDelta = currentAngle - initialAngle;

        // Rotate the dial smoothly by applying the angle delta
        float newAngle = Mathf.Repeat(this.currentAngle + angleDelta, 360f);

        // Snap to nearest 45 degrees
        float snapped = Mathf.Round(newAngle / 45f) * 45f;

        // Apply the snapped angle to the dial (smooth rotation)
        SetDialAngle(snapped);

        // Update initialAngle for the next frame's drag
        this.currentAngle = snapped;

        // Trigger the event to notify the DialManager
        OnDialRotated?.Invoke(snapped);
    }

    // Utility function to calculate the angle of a point relative to the center of the dial
    private float GetAngle(Vector2 center, Vector2 point)
    {
        Vector2 direction = point - center;
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    // Set the dial's rotation angle
    public void SetDialAngle(float angle)
    {
        rectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Get the current angle of the dial
    public float GetDialAngle()
    {
        return rectTransform.eulerAngles.z;
    }
}
