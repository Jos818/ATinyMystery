//ButtonSizeChange.cs by Joseph Panara for A Tiny Mystery
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSizeChange : MonoBehaviour
{
    //For it to work properly, add all button elements directly to button, including separate sprites
    //Add Event Trigger to the Button and add the OnPointerEnter and OnPointerExit events
    //Add Grow and Shrink Functions where appropriate
    public GameObject ButtonContainer;
    public int GrowSize;
    public int MovePositionX;
    public int MovePositionY;
    public int StartPositionX;
    public int StartPositionY;

    //Increases the size of the button
    public void Grow()
    {
        ButtonContainer.transform.localScale += new Vector3(GrowSize, GrowSize, 1);
    }
    //Decreases the size of the button
    public void Shrink()
    {
        ButtonContainer.transform.localScale += new Vector3(-GrowSize, -GrowSize, 1);
    }
    //Changes the positioning of the button if necessary
    public void Move()
    {
        ButtonContainer.transform.position += new Vector3(MovePositionX, MovePositionY, 1);
    }
    public void Return()
    {
        ButtonContainer.transform.position += new Vector3(StartPositionX, StartPositionY, 1);
    }
}
