using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; // Also needed for List<>

[System.Serializable]
public class ItemUIPrefab
{
    public string itemName;
    public GameObject prefab;
}

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Transform itemListParent;
    public List<ItemUIPrefab> itemPrefabs;

    private void Start()
    {
        inventoryPanel.SetActive(false);
        UpdateUI();
    }

    public void ToggleInventory()
    {
        bool isActive = inventoryPanel.activeSelf;
        inventoryPanel.SetActive(!isActive);
        if (!isActive)
            UpdateUI();
    }

    void UpdateUI()
    {
        foreach (Transform child in itemListParent)
        {
            Destroy(child.gameObject);
        }

        foreach (string item in InventoryManager.Instance.GetItems())
        {
            GameObject prefab = GetPrefabForItem(item);
            if (prefab != null)
            {
                Instantiate(prefab, itemListParent);
            }
            else
            {
                Debug.LogWarning("No prefab found for item: " + item);
            }
        }
    }

    GameObject GetPrefabForItem(string itemName)
    {
        foreach (var entry in itemPrefabs)
        {
            if (entry.itemName == itemName)
                return entry.prefab;
        }
        return null;
    }
}
