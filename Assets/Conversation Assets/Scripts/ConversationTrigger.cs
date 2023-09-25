//ConversationTrigger.cs by Joseph Panara for A Tiny Mystery
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConversationTrigger : MonoBehaviour
{
    public ConversationController conversationcontroller;
    bool inArea = false;
    public Conversation convo;
    public InventoryItemList inventory;
    public InventoryItem requireditem;
    public Conversation itemconvo;
    public Conversation notesconvo;
    public Player_Movement movement;
    private SpriteRenderer spriteRenderer;
    public bool animated;
    public Animator animator;
    [SerializeField] private Sprite interactiveSprite = default;
    [SerializeField] private Sprite basicSprite = default;
    public MenuController menucontroller;
    public EnvMusicTrigger envmusic;

    //Finds the objects with the ConversationController and MenuController scripts for the conversation scripts to function properly
    //Also finds the Animator or SpriteRenderer to use the glow effect that tells the player that they can interact with the trigger
    private void Start()
    {
        if (animated)
        {
            animator = gameObject.GetComponent<Animator>(); 
        }
        else
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
        conversationcontroller = FindObjectOfType<ConversationController>();
        menucontroller = FindObjectOfType<MenuController>();

    }
    //While the player is in the trigger, hitting the space bar begins and interacts with the ConversationController
    private void Update()
    {
        if (inArea && Input.GetKeyDown("space") && conversationcontroller.skip != false)
        {
            conversationcontroller.skip = false;
            conversationcontroller.AdvanceLine();
            menucontroller.menuUI.SetActive(false);
            envmusic.Music.Stop();
            envmusic.Playing = false;
        }
        else if (inArea && Input.GetKeyDown("space") && conversationcontroller.skip != true)
        {
            conversationcontroller.skip = true;
            envmusic.Music.Stop();
        }
    }
    //Delivers the Conversation information contained within the trigger to the ConversationController when the player enters the trigger
    //Also triggers the glow effect to the trigger's object
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            conversationcontroller.currentTrigger = this;
            conversationcontroller.ChangeConversation(convo);
            if (animated)
            {
                animator.SetBool("Triggered", true);
            }
            else
            {
                spriteRenderer.sprite = interactiveSprite;
            }
              //Changes the Conversation that the trigger sends to the ConversationController from the original conversation, to a conversation that requires a specific item in the player's inventory
            if (requireditem)
            {
                    if (inventory._inventoryItems.Contains(requireditem))
                    {
                        conversationcontroller.ChangeConversation(itemconvo);
                    }
            }
        }
    }
    

        private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inArea = true;
        }
    }
    //Removes any conversation currently queued in the Conversation Controller so conversations are only begun when in the range of the trigger.
    //Also stops the glow animation that shows the player they can interact with the trigger's object.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            conversationcontroller.ChangeConversation(null);
            if (animated)
            {
                animator.SetBool("Triggered", false);
            }
            else
            {
                spriteRenderer.sprite = basicSprite; ;
            }
            
        }
        inArea = false;
        
    }
}