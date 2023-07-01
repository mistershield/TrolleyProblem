using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedScreen : MonoBehaviour
{
    //A reference to the pause screen object
    public GameObject pauseScreen;

    //A boolean that is used to establish if the game is paused or not
    private bool isGamePaused;

    //Checks if the player presses the cancel button (esc) and if isGamePaused is false pauses the game otherwise  resumes the game
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(!isGamePaused)
            {
                StopGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }
    //Activates the pause screen object, sets isGamePaused to true, and sets the time scale to 0
    public void StopGame()
    {
        pauseScreen.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0;
    }
    //Does the opposite of the StopGame function
    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1;
    }
}
