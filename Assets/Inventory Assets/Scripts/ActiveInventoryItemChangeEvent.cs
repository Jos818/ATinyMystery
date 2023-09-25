//ActiveInventoryChangeEvent.cs by CodeAnvil
using UnityEngine.Events;

//Creates a Unity Event that activates an item in the inventory menu when a button is clicked
[System.Serializable]
public class ActiveInventoryItemChangeEvent : UnityEvent<InventoryItem> { }