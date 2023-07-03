using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueContainer : MonoBehaviour
{
    public List<string> descriptionsList = new List<string>();
    public List<string> dialoguesList = new List<string>();
    public Dictionary<string, string> dialogueDictorinary = new Dictionary<string, string>();


    private void Awake()
    {
        for (int i = 0; i < dialoguesList.Count; i++)
        {
            dialogueDictorinary.Add(descriptionsList[i], dialoguesList[i]);
        }
    }
}
