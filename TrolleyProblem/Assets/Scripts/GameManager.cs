using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject problemChanger;
    public List<Choices> problems = new List<Choices>();

    private float timer;
    private int currentProblem = 0;
    private bool madeAChoice = false;

    private void Start()
    {
        timer = problems[currentProblem].time;
    }

    private void Update()
    {
        if (!madeAChoice)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                DoActionBasedOnChoice("default");
            }
        }
    }

    public void ChangeProblem()
    {
        if (currentProblem < problems.Count - 1)
        {
            problems[currentProblem].gameObject.SetActive(false);
            timer = problems[currentProblem].time;
            currentProblem++;
            madeAChoice = false;
            problems[currentProblem].gameObject.SetActive(true);
            problemChanger.SetActive(false);
            Debug.Log("Changed problem");
        }
    }

    public void DoActionBasedOnChoice(string description)
    {
        if (!madeAChoice)
        {
            Debug.Log("Made a choice");
            problems[currentProblem].choiceOption[description].SetActive(true);
            madeAChoice = true;
            problemChanger.SetActive(true);
        }
    }
}
