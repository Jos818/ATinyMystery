//NoteDisplay.cs by Joseph Panara for A Tiny Mystery
using UnityEngine;
using UnityEngine.UI;

public class NoteDisplay : MonoBehaviour
{
    public CharacterNotes _note = default;

    [SerializeField]
    private UnityEngine.UI.Text _title = default;

    [SerializeField]
    private UnityEngine.UI.Text _description = default;

    [SerializeField]
    private UnityEngine.UI.Text _list = default;

    [SerializeField]
    private UnityEngine.UI.Image _sprite = default;

    //Sets the UI information for a character when their notes button is clicked
    public void SetNote(CharacterNotes note)
    {
        _note = note;
        _title.text = _note.character.fullName;
        _description.text = _note.description;
        _sprite.sprite = _note.character.portrait;
        _list.text = "";
        foreach (string item in _note.lines)
        {
            _list.text += item.ToString() + "\n";
        }
    }
}
