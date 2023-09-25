//ItemChooser.cs by CodeAnvil
using UnityEngine;
using UnityEngine.Events;

public class ItemChooser : MonoBehaviour
{
    [SerializeField]
    private ActiveInventoryItemChangeEvent activeInventoryItemChangeEvent = default;

    public InventoryItem item;
    //Creates an event that allows an item to be activated in the inventory menu when a button is clicked
    public void ChooseItem()
    {
        activeInventoryItemChangeEvent.Invoke(item);
    }
}