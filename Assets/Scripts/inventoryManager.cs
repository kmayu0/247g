using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<string> items = new List<string>(); // Can be changed to a custom Item class

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(string item)
    {
        items.Add(item);
        Debug.Log("Added item: " + item);
    }

    public List<string> GetItems()
    {
        return items;
    }
}
