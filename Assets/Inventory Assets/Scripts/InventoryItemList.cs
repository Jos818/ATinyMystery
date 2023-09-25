//InventoryItemList.cs by CodeAnvil
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InventoryItemList : MonoBehaviour
{
    [SerializeField]
    public GameObject _content = default;
    [SerializeField]
    private GameObject _menuItemTemplate = default;
    public List<InventoryItem> _inventoryItems = default;
    [SerializeField]
    private ActiveInventoryItemChangeEvent activeInventoryItemChangeEvent = default;

    void Awake()
    {
        ActivateFirstItem();
    }
    //Runs the AddMenuItem function for all items in the player's inventoryItems list
    public void AddMenuItems()
    {
        for (int index = 0; index < _inventoryItems.Count; index++)
        {
            AddMenuItem(_inventoryItems[index]);
        }
    }
    //Creates the UI object on the inventory menu for an item
    public void AddMenuItem(InventoryItem item)
    {
        GameObject newMenuItem;
        string label = $"{item.label}";
        newMenuItem = Instantiate(_menuItemTemplate, transform.position, transform.rotation);
        newMenuItem.name = label;
        newMenuItem.transform.SetParent(_content.transform, true);
        newMenuItem.SetActive(true);
        newMenuItem.GetComponentInChildren<Text>().text = label;
        newMenuItem.GetComponent<ItemChooser>().item = item;
        _inventoryItems.Add(item);
    }
    //Selects the first item in the list so the UI image isn't blank
    void ActivateFirstItem()
    {
        InventoryItem activeItem = _inventoryItems[0];

        if (activeItem != null)
        {
            activeInventoryItemChangeEvent.Invoke(activeItem);
        }
    }
}