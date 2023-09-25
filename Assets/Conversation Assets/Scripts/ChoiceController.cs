//ChoiceController.cs by CodeAnvil
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class ConversationChangeEvent : UnityEvent<Conversation> { }

//This script runs the Choice Buttons that appear in the Question UI
public class ChoiceController: MonoBehaviour
{
    public Choice choice;
    public ConversationChangeEvent conversationChangeEvent;
    //Creates a Choice Button
    public static ChoiceController AddChoiceButton(Button choiceButtonTemplate, Choice choice, int index)
    {
        int buttonSpacing = -80;
            Button button = Instantiate(choiceButtonTemplate);

        button.transform.SetParent(choiceButtonTemplate.transform.parent);
        button.transform.localScale = Vector3.one;
        button.transform.localPosition = new Vector3(0, index * buttonSpacing, 0);
        button.name = "Choice" + (index + 1);
        button.gameObject.SetActive(true);

        ChoiceController choiceController = button.GetComponent<ChoiceController>();
        choiceController.choice = choice;
        return choiceController;
    }

    private void Start()
    {
        if (conversationChangeEvent == null)
            conversationChangeEvent = new ConversationChangeEvent();

        GetComponent<Button>().GetComponentInChildren<Text>().text = choice.text;
    }
    //Sends the Choice Button's nextConversation information to the ConversationController
    public void MakeChoice()
    {
        conversationChangeEvent.Invoke(choice.conversation);

    }
}