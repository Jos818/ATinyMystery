using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AddNote : MonoBehaviour
{
    [SerializeField]
    private CharacterNotes note;
    [SerializeField]
    private NotesList list;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            list.AddMenuItem(note);
            //inventory._inventoryItems.Add(item);
        }
    }
}
