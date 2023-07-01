using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choices : MonoBehaviour
{
    public float time;
    public GameObject defaultChoice;
    public List<string> choicesDescription = new List<string>();
    public List<GameObject> ChoicesObjects = new List<GameObject>();

    public Dictionary<string, GameObject> choiceOption = new Dictionary<string, GameObject>();

    private void Start()
    {
        choiceOption.Add("default", defaultChoice);
        for (int i = 0; i < choicesDescription.Count; i++)
        {
            choiceOption.Add(choicesDescription[i], ChoicesObjects[i]);
        }
    }
}
