//NoteChooser.cs by Joseph Panara for A Tiny Mystery
using UnityEngine;
using UnityEngine.Events;
//Functionally identical to the ItemChooser.cs by CodeAnvil
public class NoteChooser : MonoBehaviour
{
    [SerializeField]
    private ActiveNoteChooserEvent activenotechooserEvent = default;

    public CharacterNotes note;
    //Creates an event that allows a character's notes to be activated in the notes menu when a button is clicked
    public void ChooseNote()
    {
        activenotechooserEvent.Invoke(note);
    }
}
