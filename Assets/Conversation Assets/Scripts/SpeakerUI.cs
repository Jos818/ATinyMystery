using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeakerUI : MonoBehaviour
{
    public Image portrait;
    public Text fullName;
    public Text dialogue;
    public SpriteRenderer spriteRenderer;

    private Character speaker;
    public Character Speaker
    {
        get { return speaker;  }
        set
        {
            speaker = value;
            portrait.sprite = speaker.portrait;
            fullName.text = speaker.fullName;
            spriteRenderer.sprite = speaker.portrait;
        }
    }
    public string Dialogue
    {
        get { return dialogue.text; }
        set { dialogue.text = value;  }
    }

    public bool HasSpeaker()
    {
        return speaker != null;
    }

    public bool SpeakerIs(Character character)
    {
        return speaker == character;
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}