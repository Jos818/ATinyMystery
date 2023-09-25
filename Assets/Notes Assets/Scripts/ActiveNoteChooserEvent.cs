//ActiveNoteChooserEvent by Joseph Panara for A Tiny Mystery
using UnityEngine.Events;

//Functionally identical to ActiveInventoryChangeEvent.cs by CodeAnvil
//Creates a Unity Event that activates an item in the inventory menu when a button is clicked
[System.Serializable]
public class ActiveNoteChooserEvent : UnityEvent<CharacterNotes> { }

