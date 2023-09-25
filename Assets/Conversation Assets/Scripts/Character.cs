//Character.cs by CodeAnvil
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
//The Character information that determines the name, portrait sprite, and voice audio information for each character
public class Character : ScriptableObject
{
    public string fullName;
    public Sprite portrait;
    public AudioClip Voice;
}
