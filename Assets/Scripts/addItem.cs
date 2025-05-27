using UnityEngine;

public class AddItemButton : MonoBehaviour
{
    public string itemName; 

    public void AddItemToInventory()
    {
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.AddItem(itemName);
        }
        else
        {
            Debug.LogWarning("InventoryManager not found!");
        }
    }
}
