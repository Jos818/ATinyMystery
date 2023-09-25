using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AddItem : MonoBehaviour
{
    //This component is placed on any object that is a keyItem pick up and to be placed in your "inventory"\
    [SerializeField]
    private InventoryItem item;
    [SerializeField]
    private InventoryItemList inventory;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inventory.AddMenuItem(item);
            //inventory._inventoryItems.Add(item);
        }
    }
}
