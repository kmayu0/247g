using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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

    public PuzzleManager puzzleManager;  // 👈 Add reference to PuzzleManager

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
        // Clear existing UI items
        foreach (Transform child in itemListParent)
        {
            Destroy(child.gameObject);
        }

        // Add each collected item
        List<string> items = InventoryManager.Instance.GetItems();
        for (int i = 0; i < items.Count; i++)
        {
            string item = items[i];
            GameObject prefab = GetPrefabForItem(item);
            if (prefab != null)
            {
                GameObject go = Instantiate(prefab, itemListParent);

                // Assign puzzleManager and index if the script exists
                InventoryPieceButton pieceButton = go.GetComponent<InventoryPieceButton>();
                if (pieceButton != null)
                {
                    pieceButton.puzzleManager = puzzleManager;
                    pieceButton.pieceIndex = i;  // Assumes prefab order matches hiddenPuzzlePieces
                    Debug.Log($"Assigned pieceIndex {i} to {go.name}");

                }
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
