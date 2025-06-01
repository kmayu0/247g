using UnityEngine;

public class AddItemButton : MonoBehaviour
{
    public string itemName;

    void Start()
    {
        // If the item was collected during this session, hide it
        if (SessionCollectedItems.collectedItems.Contains(itemName))
        {
            gameObject.SetActive(false);
        }
    }

    public void AddItemToInventory()
    {
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.AddItem(itemName);
            SessionCollectedItems.collectedItems.Add(itemName); // Mark as collected this session
            gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("InventoryManager not found!");
        }
    }
}
