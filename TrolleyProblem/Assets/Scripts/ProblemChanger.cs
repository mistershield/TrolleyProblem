using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemChanger : MonoBehaviour
{
    public GameManager gameManager;
    private void OnMouseDown()
    {
        gameManager.ChangeProblem();
    }
}
