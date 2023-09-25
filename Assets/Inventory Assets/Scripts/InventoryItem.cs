//InventoryItem.cs by CodeAnivl
using UnityEngine;

//Where the item information is stored for the inventory menu
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 0)]
public class InventoryItem : ScriptableObject
{
    public string label = "Item";
    public int ID = 0;
    public string description;
    public Sprite image;
}