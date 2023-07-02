using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemChanger : MonoBehaviour
{
    //A reference to the game manager
    public GameManager gameManager;

    //Calls the gamemanager to change the current problem
    private void OnMouseDown()
    {
        gameManager.ChangeProblem();
    }
}
