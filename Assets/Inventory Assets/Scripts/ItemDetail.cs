//ItemDetail.cs by CodeAnvil
using UnityEngine;
using UnityEngine.UI;

public class ItemDetail : MonoBehaviour
{
    [SerializeField]
    private InventoryItem _item = default;

    [SerializeField]
    private UnityEngine.UI.Text _title = default;

    [SerializeField]
    private UnityEngine.UI.Text _description = default;

    [SerializeField]
    private UnityEngine.UI.Image _sprite = default;
    //Sets the UI elements for when one of the item buttons is clicked
    public void SetItem(InventoryItem item)
    {
        _item = item;
        _title.text = _item.label;
        _description.text = _item.description;
        _sprite.sprite = _item.image;
    }
}