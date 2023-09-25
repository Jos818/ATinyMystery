//QuestionController.cs by CodeAnvil
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script handles the Question event, where the player is allowed to choose different Conversation options
public class QuestionController : MonoBehaviour
{
    public Question question;
    public Text questionText;
    public Button choiceButton;

    private List<ChoiceController> choiceControllers = new List<ChoiceController>();
    //Activates the Question UI with a new Question
    public void Change(Question _question)
    {
        RemoveChoices();
        question = _question;
        gameObject.SetActive(true);
        Initialize();
    }
    //Runs RemoveChoices and hides the Question UI
    public void Hide(Conversation conversation)
    {
        RemoveChoices();
        gameObject.SetActive(false);
    }
    //Deletes all Choice Buttons
    private void RemoveChoices()
    {
        foreach(ChoiceController c in choiceControllers)
            Destroy(c.gameObject);

        choiceControllers.Clear();
    }
    
    //Creates the Choice Buttons for the Question UI
    private void Initialize()
    {
        questionText.text = question.text;

        for (int index = 0; index < question.choices.Length; index++)
        {
            ChoiceController c = ChoiceController.AddChoiceButton(choiceButton, question.choices[index], index);
            choiceControllers.Add(c);
        }

        choiceButton.gameObject.SetActive(false);
    }
}