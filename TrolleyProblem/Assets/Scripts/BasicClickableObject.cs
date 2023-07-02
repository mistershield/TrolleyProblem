using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicClickableObject : MonoBehaviour
{
    //The description of the choice, its used to find is corresponding result in the Choices script
    public string description;
    //A reference to the game manager
    public GameManager gameManager;
    //A boolean that tells if the choice is correct
    public bool isCorrectAnswer;

    //Detects when the player clicks on it
    private void OnMouseDown()
    {
        gameManager.DoActionBasedOnChoice(description, isCorrectAnswer);
    }
}
