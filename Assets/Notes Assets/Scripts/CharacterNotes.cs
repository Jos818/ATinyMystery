//CharacterNotes.cs by Joseph Panara for A Tiny Mystery
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


//Where the notes information for the notes menu is stored
[CreateAssetMenu(fileName = "New Note", menuName = "Notes")]
public class CharacterNotes : ScriptableObject
{
    public Character character;
    public string description;
    public List<string> lines;
    public List<string> originallines;

    public void LineReset(List<string> lines)
    {
        lines.Clear();
        lines.AddRange(originallines);
    }
}

