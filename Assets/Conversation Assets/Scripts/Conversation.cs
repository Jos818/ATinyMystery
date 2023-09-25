//Conversation.cs by CodeAnvil
//Adapted by Joseph Panara for A Tiny Mystery
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Where the text for a Conversation is input
[System.Serializable]
public struct Line
{
    public Character character;

    [TextArea(2, 5)]
    public string text;
}

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
//Where all the information for the Conversation is stored
//Additions for background music, item and note integration, and scene management written by Joseph Panara
public class Conversation : ScriptableObject
{
    public Character speakerLeft;
    public Character speakerRight;
    public Question question;
    public InventoryItem item;
    public bool alreadyhasitem = false;
    public CharacterNotes notes;
    public List<string> noteaddition;
    public bool hasnoteaddition;
    public bool alreadyhasnotes = false;
    public bool DestroyTrigger = false;
    public bool FinalTrigger = false;
    public int EndScreenSceneIndex;
    public AudioClip music;
    public bool StopMusic = false;
    public Conversation nextConversation;
    public Line[] lines;

    private void Start()
    {
        alreadyhasitem = false;
        alreadyhasnotes = false;
    }
}