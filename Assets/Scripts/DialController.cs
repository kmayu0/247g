using UnityEngine;
using UnityEngine.EventSystems;

public class DialController : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Vector2 centerPoint;
    private float initialAngle;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out var localPoint);
        centerPoint = rectTransform.rect.center;
        initialAngle = GetAngle(centerPoint, localPoint);
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out var localPoint);
        float currentAngle = GetAngle(centerPoint, localPoint);
        float angleDelta = currentAngle - initialAngle;

        rectTransform.Rotate(0, 0, angleDelta);
        initialAngle = currentAngle; // update for continuous dragging
    }

    private float GetAngle(Vector2 center, Vector2 point)
    {
        Vector2 direction = point - center;
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }
}
