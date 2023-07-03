using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Choices : MonoBehaviour
{
    //The time the player has to make a choice
    public float time;
    //The choice that will be selected if the timer runs out and the player dident make a choice
    public GameObject defaultChoice;

    //A list of the BasicClickableObjects in the problem
    public List<BasicClickableObject> choicesDescription = new List<BasicClickableObject>();
    //All the results that can happen in the choice, they should be in the same index as their corresponding BasicClickableObject
    //for example if the index in choicesDescription of the choice where the player eats cereal is 2 then the index in ResultObjects of
    //its respective result should also be 2
    public List<GameObject> ResultObjects = new List<GameObject>();
    //A list of all the drag and drop objects related tho the choice
    public List<GameObject> dragAndDropObjects = new List<GameObject>();
    //A reference to all the starting positions of all the drag and drop objects of the choice
    private List<Vector3> dragAndDropStartingPosition = new List<Vector3>();

    //A container that saves the problem results that uses the description of the choice as the index
    public Dictionary<string, GameObject> choiceOption = new Dictionary<string, GameObject>();

    //Sets the default  choice and fills choiceOption using the choicesDescription and ResultObjects
    private void Start()
    {
        choiceOption.Add("Default", defaultChoice);

        for (int i = 0; i < choicesDescription.Count; i++)
        {
            choiceOption.Add(choicesDescription[i].description, ResultObjects[i]);
        }

        if(dragAndDropObjects.Count > 0)
        {
            foreach(GameObject tmpObject in dragAndDropObjects)
            {
                dragAndDropStartingPosition.Add(tmpObject.transform.position);
            }
        }
    }
    //Resets all the elements in the choice 
    public void ResetChoice()
    {
        defaultChoice.SetActive(false);
        foreach (GameObject tmpResultObject in ResultObjects)
        {
            tmpResultObject.SetActive(false);
        }
        for(int i = 0; i < dragAndDropObjects.Count; i++)
        {
            dragAndDropObjects[i].transform.position = dragAndDropStartingPosition[i];
        }
    }
}
