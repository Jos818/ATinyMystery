//EnvMusicTrigger.cs by Joseph Panara for A Tiny Mystery
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvMusicTrigger : MonoBehaviour
{
    public AudioSource Music;
    public bool Playing = false;
    public ConversationController conversationcontroller;

    //Finds the ConversationController object that will affect what music is playing
    private void Start()
    {
        conversationcontroller = FindObjectOfType<ConversationController>();
        Playing = false;
        Music.Stop();
    }
    //Triggers the background music for the area
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
            {
            //conversationcontroller.musicTrigger = this;
            if (Playing != true)
            {
                Music.Play();
                Playing = true;
            }
            }

        }
    //Stops the background music if a conversation is started, so conversation-specific music can play
    private void OnTriggerStay2D(Collider2D other)
    {
        if (conversationcontroller.conversationStarted != false)
        {
            Music.Stop();
            Playing = false;
        }

        if (other.gameObject.tag == "Player" & conversationcontroller.conversationStarted != true & Playing != true)
        {
            Music.Play();
            Playing = true;
        }
    }
    //Stops the background music when the player leaves the area
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (other.tag == "Player")
            {
                Music.Stop();
                Playing = false;
            }

        }
    }
}
