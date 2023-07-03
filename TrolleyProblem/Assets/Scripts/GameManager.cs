using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //A reference to the game element that tells the gamemanager to change problems
    public GameObject problemChanger;
    //A reference to the timer object on the scene
    public Timer timerObject;
    //A reference to the music player on the scene
    public MusicPlayer musicPlayer;
    //A list of all the problems in the game
    public List<Choices> problems = new List<Choices>();

    //The available time for the current problem
    private float timer;
    //The index of the current problem in the problems list
    private int currentProblem = 0;
    //A boolean that dictates if the player has made a choice
    private bool madeAChoice = false;
    //Saves if the player made a correct choice
    private bool madeAGoodChoice;

    //Sets the time for the first problem
    private void Start()
    {
        timer = problems[currentProblem].time;
        timerObject.timerValue = timer;
    }

    //If the player hasn't made a choice the code makes a countdown,
    //if the countdown ends and the player hasn't made a choice the code tells the current problem to use the default choice
    private void Update()
    {
        if (!madeAChoice)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                DoActionBasedOnChoice("default", false);
            }
        }
    }

    //Changes the current problem, updates the timer, and resets the madeAChoice variable
    public void ChangeProblem()
    {
        if(madeAGoodChoice)
        {
            if (currentProblem < problems.Count - 1)
            {
                problems[currentProblem].gameObject.SetActive(false);
                currentProblem++;
                problems[currentProblem].gameObject.SetActive(true);
            }
        }
        else 
        {
            problems[currentProblem].ResetChoice();
            musicPlayer.PlayNormalMusic();
        }
        madeAChoice = false;
        problemChanger.SetActive(false);
        timer = problems[currentProblem].time;
        timerObject.timerValue = timer;
        timerObject.UpdateTimer();
    }

    //Tells the current problem the choice the player made, and activates the problemChanger object, and sets madeAChoiceto true
    public void DoActionBasedOnChoice(string description, bool isCorrect)
    {
        if (!madeAChoice)
        {
            if(!isCorrect)
            {
                musicPlayer.PlayBadMusic();
            }
            madeAGoodChoice = isCorrect;
            problems[currentProblem].choiceOption[description].SetActive(true);
            madeAChoice = true;
            timerObject.timerValue = 0;
            timerObject.UpdateTimer();
            problemChanger.SetActive(true);
        }
    }
}
