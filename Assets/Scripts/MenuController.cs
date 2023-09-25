//MenuController.cs by Joseph Panara for A Tiny Mystery
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menuUI;
    public bool menuOpen;
    public ConversationController conversationController;
    public Player_Movement movement;

    //Opens the player's inventory/notes menu while freezing their movement when 'I' is pressed and the conversation UI isn't on the screen
    void Update()
    {
       
        if (Input.GetKeyDown("i") && conversationController.conversationStarted == false)
        {
            if (menuOpen == false)
            {
                menuUI.SetActive(true);
                menuOpen = true;
                movement.canMove = false;
            }
            else
            {
                menuUI.SetActive(false);
                menuOpen = false;
                movement.canMove = true;
            }
        }
    }
}
