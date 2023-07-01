using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicClickableObject : MonoBehaviour
{
    public string description;
    public GameManager gameManager;

    private void OnMouseDown()
    {
        gameManager.DoActionBasedOnChoice(description);
    }
}
