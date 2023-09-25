//ConversationController.cs by CodeAnvil
//Adapted by Joseph Panara for A Tiny Mystery
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;

//This script handles a majority of the game's conversation functions including UI and text display, adaptive background music, and occasional scene management
//Integrations with required items, player inventory, player movement, the notes menu, and music were all written by Joseph Panara
[System.Serializable]
public class QuestionEvent : UnityEvent<Question> {}

public class ConversationController : MonoBehaviour
{
    public Conversation conversation;
    public QuestionEvent questionEvent;
    public QuestionController questionController;

    //This conversation system supports 2 speakers, one on the left and one on the right.
    public GameObject speakerLeft;
    public GameObject speakerRight;

    private SpeakerUI speakerUILeft;
    private SpeakerUI speakerUIRight;

    private int activeLineIndex;
    public bool conversationStarted = false;

    public ConversationTrigger currentTrigger;
    public bool skip = false;
    public Player_Movement movement;

    public InventoryItemList inventory;

    public NotesList noteslist;
    public NoteDisplay notedisplay;

    public AudioSource textblip;
    public AudioSource backgroundmusic;

    //Changes the Conversation to be shown from the current one to the nextConversation indicated in the current Conversation, if there is one
    public void ChangeConversation(Conversation nextConversation)
    {
        conversationStarted = false;
        conversation = nextConversation;
        //AdvanceLine();
    }
    //Gets the SpeakerUI components
    public void Start()
    {
        speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
        speakerUIRight = speakerRight.GetComponent<SpeakerUI>();
        AdvanceLine();
        backgroundmusic.Stop();
        //Debug.Log(1);

    }
    //Ends the conversation when the player presses 'X'
    public void Update()
    {

        if (Input.GetKeyDown("x"))
        {
            EndConversation();
            questionController.Hide(conversation);
        }
        }

    //When a conversation is ended, this functrion hids the UI elements, stops all conversation-specific audio, and allows the player to move
    public void EndConversation()
    {
        conversationStarted = false;
        speakerUILeft.Hide();
        speakerUIRight.Hide();
        activeLineIndex = 0;
        movement.canMove = true;
        textblip.Stop();
        backgroundmusic.Stop();


    }
    //Inputs the information from the Conversation into the ConversationController, including which sprites to use for the left and right speaker and what music to play
    public void Initialize()
    {
        conversationStarted = true;
        activeLineIndex = 0;
        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;
        if (conversation.music != null)
        {
            backgroundmusic.clip = conversation.music;
            backgroundmusic.Play();
        }
        if (conversation.StopMusic != false)
        {
            backgroundmusic.Stop();
        }
            
    }
    //The AdvanceLine funciton removes the current dialogue and replaces it with the next line
    //If there are no more lines for the current Conversation, it tries to move to the nextConversation with the AdvanceConversation funciton
    public void AdvanceLine()
    {
        movement.canMove = false;
        textblip.Stop();
        if (conversation == null) return;
        if (!conversationStarted) Initialize();

        if (activeLineIndex < conversation.lines.Length)
        DisplayLine();
        else
            AdvanceConversation();
    }
    //The AdvanceConversationFunction replaces the current Conversation with the next event, which can either be a new Conversation, a Question, or the EndConversation function

    public void AdvanceConversation()
    {
        //Loads the Question Menu and adds a Notes object to the player's menu if both the conversation has notes to give and the player doesn't already have the current Conversation's notes
        if (conversation.question != null)
        {
            questionEvent.Invoke(conversation.question);
            if (conversation.notes != null & conversation.alreadyhasnotes != true & conversation.hasnoteaddition != true)
            {
                noteslist.AddMenuItem(conversation.notes);
                conversation.alreadyhasnotes = true;
                notedisplay.SetNote(conversation.notes);
            }
            if (conversation.hasnoteaddition != false & conversation.alreadyhasnotes != true)
            {
                conversation.notes.lines.AddRange(conversation.noteaddition);
                conversation.alreadyhasnotes = true;
                notedisplay.SetNote(conversation.notes);
            }
        }
        //Loads the next Conversation indicated in the current Conversation
        //Checks if the current Conversation has a new Conversation that can be triggered by an item in the player's inventory. It will load that Conversation instead if the player has the required item
        //If the current Conversation has an item that the player doesn't already have in their inventory, the item will be added
        //Changes the background music if the background music for the nextConversation isn't the same as the background music for the current Conversation
        //Also adds a Notes object to the player's inventory in the same fashion as the Question Event above
        else if (conversation.nextConversation != null)
        {
            if (conversation.item != null & conversation.alreadyhasitem != true)
            {
                inventory.AddMenuItem(conversation.item);
                conversation.alreadyhasitem = true;
            }
            if (conversation.notes != null & conversation.alreadyhasnotes != true & conversation.hasnoteaddition != true)
            {
                noteslist.AddMenuItem(conversation.notes);
                conversation.alreadyhasnotes = true;
                notedisplay.SetNote(conversation.notes);
            }
            if (conversation.hasnoteaddition != false & conversation.alreadyhasnotes != true)
            {
                conversation.notes.lines.AddRange(conversation.noteaddition);
                conversation.alreadyhasnotes = true;
                notedisplay.SetNote(conversation.notes);
            }
            if (conversation.nextConversation.music != null & conversation.nextConversation.music != conversation.music)
            {
                backgroundmusic.Stop();
                backgroundmusic.clip = conversation.nextConversation.music;
                backgroundmusic.Play();
            }
            ChangeConversation(conversation.nextConversation);
            AdvanceLine();

        }
        //If there isn't a Question or nextConversation listed in the current Conversation, the EndConversation function is called
        //Destroys the current ConversationTrigger if denoted in the Conversation information
        //Changes the scene if denoted in the Conversation information
        //Also adds Notes objects and Item objects to the player's inventory in the same fashion as the nextConversation event above
        else
        {
            EndConversation();
            if (conversation.item != null & conversation.alreadyhasitem != true)
            {
                inventory.AddMenuItem(conversation.item);
                conversation.alreadyhasitem = true;
            }
            if (conversation.notes != null & conversation.alreadyhasnotes != true & conversation.hasnoteaddition != true)
            {
                noteslist.AddMenuItem(conversation.notes);
                conversation.alreadyhasnotes = true;
                notedisplay.SetNote(conversation.notes);
            }
            if (conversation.hasnoteaddition != false & conversation.alreadyhasnotes != true)
            {
                conversation.notes.lines.AddRange(conversation.noteaddition);
                conversation.alreadyhasnotes = true;
                notedisplay.SetNote(conversation.notes);
            }
            if (conversation.DestroyTrigger != false)
            {
                currentTrigger.gameObject.GetComponent<ConversationTriggerDestroy>().Switch();
            }
            if (conversation.FinalTrigger != false)
            {
                SceneManager.LoadScene(conversation.EndScreenSceneIndex);
            }
        }
    }
    //Displays the text of each line of the Conversation and plays the dialogue sound denoted in the Character information
    private void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if (speakerUILeft.SpeakerIs(character))
        {
            textblip.clip = character.Voice;
            SetDialogue(speakerUILeft, speakerUIRight, line.text);
        }
        else
        {
            textblip.clip = character.Voice;
            SetDialogue(speakerUIRight, speakerUILeft, line.text);
        }
        activeLineIndex += 1;

    }
    //Sets the text and UI information for each line of the Conversation and changes them as needed
    public void SetDialogue(
         SpeakerUI activeSpeakerUI,
         SpeakerUI inactiveSpeakerUI,
         string text
         )
    {
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();
        activeSpeakerUI.Dialogue = text;

            activeSpeakerUI.Dialogue = " ";
            StopAllCoroutines();
            StartCoroutine(EffectTypewriter(text, activeSpeakerUI));
    }
    //Causes the text to type out one character at a time like a typewriter
    private IEnumerator EffectTypewriter(string text, SpeakerUI controller)
    {
        textblip.Play();
        {
            foreach (char character in text.ToCharArray())
            {
                
                    controller.Dialogue += character;
                if (!skip)
                {
                    yield return new WaitForSeconds(0.04f);
                }
                else
                {
                    textblip.Stop();
                }
            }

       }
        textblip.Stop();
        skip = true;
    }
   
}
