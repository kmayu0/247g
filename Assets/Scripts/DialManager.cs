using UnityEngine;

public class DialManager : MonoBehaviour
{
    public DialController[] dials;
    public float[] targetAngles = new float[] { 45f, 90f, 315f, 180f }; // Example targets

    void Start()
    {
        // Subscribe to the OnDialRotated event for each dial
        foreach (var dial in dials)
        {
            dial.OnDialRotated += OnAnyDialRotated;
        }
    }

    void OnAnyDialRotated(float snappedAngle)
    {
        // Track if each dial is correct
        bool allCorrect = true;

        // Iterate through each dial and check if its angle matches the target
        for (int i = 0; i < dials.Length; i++)
        {
            float currentAngle = Mathf.Round(dials[i].GetDialAngle());
            float expectedAngle = targetAngles[i];
            if (Mathf.Abs(Mathf.DeltaAngle(currentAngle, expectedAngle)) > 1f)
            {
                allCorrect = false;
            }
        }
        if (allCorrect)
        {
            Debug.Log("✅ Puzzle solved!");
        }
    }
}
