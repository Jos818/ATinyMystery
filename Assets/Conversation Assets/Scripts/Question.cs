//Question.cs by CodeAnvil
using UnityEngine;
using UnityEngine.UI;

//Where the information for a Choice Button is stored
[System.Serializable]
public struct Choice
{
    [TextArea(2, 5)]
    public string text;
    public Conversation conversation;
}
//Stores the Question information for the QuestionController
[CreateAssetMenu(fileName = "New Question", menuName = "Question")]
public class Question : ScriptableObject
{
    [TextArea(2, 5)]
    public string text;
    public Choice[] choices;
}
