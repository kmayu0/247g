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
    public GameObject inventoryToggleButton;
    public List<ItemUIPrefab> itemPrefabs;
    public PuzzleManager puzzleManager;

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
    {
        UpdateUI();
        inventoryToggleButton.SetActive(false); // hide the button when panel opens
    }
    else
    {
        inventoryToggleButton.SetActive(true);  // show the button when panel closes
    }
}


    void UpdateUI()
    {
        // Clear existing UI items
        foreach (Transform child in itemListParent)
        {
            Destroy(child.gameObject);
        }

        // Step 1: Get item names in inventory
        List<string> itemNames = InventoryManager.Instance.GetItems();

        // Step 2: Build a temporary list of instantiated buttons with their index
        List<(int pieceIndex, GameObject button)> buttons = new List<(int, GameObject)>();

        foreach (string item in itemNames)
        {
            GameObject prefab = GetPrefabForItem(item);
            if (prefab != null)
            {
                GameObject go = Instantiate(prefab); // instantiate without parent yet
                InventoryPieceButton btn = go.GetComponent<InventoryPieceButton>();

                if (btn != null)
                {
                    btn.puzzleManager = puzzleManager;
                    buttons.Add((btn.pieceIndex, go));
                    Debug.Log($"Loaded button for {item} with index {btn.pieceIndex}");
                }
            }
            else
            {
                Debug.LogWarning("No prefab found for item: " + item);
            }
        }

        // Step 3: Sort buttons by pieceIndex ascending (top = 0)
        buttons.Sort((a, b) => a.pieceIndex.CompareTo(b.pieceIndex));

        // Step 4: Add them to the UI top-down
        foreach (var (index, go) in buttons)
        {
            go.transform.SetParent(itemListParent, false);
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
