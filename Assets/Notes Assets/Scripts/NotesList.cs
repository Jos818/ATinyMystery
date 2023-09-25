//NotesList.cs by Joseph Panara for A Tiny Mystery
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor;

//Functionally identical to the InventoryItemList.cs by CodeAnvil
public class NotesList : MonoBehaviour
{
    [SerializeField]
    public GameObject _content = default;
    [SerializeField]
    private GameObject _buttonTemplate = default;
    public List<CharacterNotes> _characternotes = default;
    public List<CharacterNotes> _resetlist = default;
    [SerializeField]
    private ActiveNoteChooserEvent activenotechooserEvent = default;


   void Awake()
    {
        ActivateFirstNote();
        
    }
    //Runs the AddMenuItem function for all items in the player's inventoryItems list
    public void AddMenuItems()
    {
        for (int index = 0; index < _characternotes.Count; index++)
        {
            AddMenuItem(_characternotes[index]);
        }
    }
    //Creates the UI object on the inventory menu for an item
    public void AddMenuItem(CharacterNotes note)
    {
        note.LineReset(note.lines);
        GameObject newMenuItem;
        string label = $"{note.character.fullName}";
        newMenuItem = Instantiate(_buttonTemplate, transform.position, transform.rotation);
        newMenuItem.name = label;
        newMenuItem.transform.SetParent(_content.transform, true);
        newMenuItem.SetActive(true);
        newMenuItem.GetComponentInChildren<Text>().text = label;
        newMenuItem.GetComponent<NoteChooser>().note = note;
        _characternotes.Add(note);
    }
    //Selects the first item in the list so the UI text box isn't blank
    void ActivateFirstNote()
    {
        CharacterNotes activeNote = _characternotes[0];

        if (activeNote != null)
        {
            activenotechooserEvent.Invoke(activeNote);
        }
    }
}
