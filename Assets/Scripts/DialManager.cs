using UnityEngine;
using System.Collections;

public class DialManager : MonoBehaviour
{
    public DialController[] dials;
    public float[] targetAngles = new float[] { 45f, 90f, 315f, 180f };

    public GameObject solvedPopup; 

    private bool puzzleSolved = false;

    void Start()
    {
        foreach (var dial in dials)
        {
                 string key = dial.gameObject.name + "_DialAngle";
        if (PlayerPrefs.HasKey(key))
        {
            float savedAngle = PlayerPrefs.GetFloat(key);
            dial.SetDialAngle(savedAngle);
        }
            dial.OnDialRotated += OnAnyDialRotated;
        }

        if (solvedPopup != null)
            solvedPopup.SetActive(false); // hide initially
    }

    void OnAnyDialRotated(float snappedAngle)
    {
        if (puzzleSolved) return;

        bool allCorrect = true;

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
            puzzleSolved = true;
            Debug.Log("✅ Puzzle solved!");
            if (solvedPopup != null)
                StartCoroutine(ShowPopup());
        }
    }

    IEnumerator ShowPopup()
    {
        solvedPopup.SetActive(true);
        solvedPopup.transform.localScale = Vector3.zero;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 4f;
            solvedPopup.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            yield return null;
        }
    }
   

}
