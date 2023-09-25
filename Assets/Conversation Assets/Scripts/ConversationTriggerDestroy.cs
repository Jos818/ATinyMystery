//ConversationTriggerDestroy.cs by Joseph Panara for A Tiny Mystery
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTriggerDestroy : MonoBehaviour
{
    public GameObject trigger1;
    public GameObject trigger2;
    //Destroys one object and activates another. Used for destroying one-time-use ConversationTrigger objects and replacing them with another
    //Is also used to destroy barriers to player progression that are nested within the ConversationTrigger object in order to tie player progression to certain key conversations
    public void Switch()
    {
        Destroy(trigger1);
        trigger2.SetActive(true);
    }
}
