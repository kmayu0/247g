using UnityEngine;

public class meow : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Makes the GameObject persist
    }
}
