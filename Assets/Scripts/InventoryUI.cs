using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject itemTextPrefab; // Text prefab for displaying items
    public Transform itemListParent; // Where the items appear in the UI

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
            GameObject itemText = Instantiate(itemTextPrefab, itemListParent);
            itemText.GetComponent<Text>().text = item;
        }
    }
}
