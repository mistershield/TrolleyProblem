using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public float textSpeed = 0.05f;
    private string currentLine = "";

    public Dictionary<string, string> GameDialogue;

    private void Awake()
    {
        // Initialize the scene dialogues
        GameDialogue = new Dictionary<string, string>();

        //Narration
        GameDialogue["Chapter1"] = "This is a game about Stanley.";

        // Add dialogues for each option
        GameDialogue["Scene1Option1"] = "Turning off his alarm Stanley stretched and rose up out of bed, wide awake he was ready to face the day.";

        GameDialogue["Scene1Option0"] = "With a lazy wave Stanley slapped the snooze button before rolling over and going back to sleep. Refusing to wake up, Stanley slowly wasted away.";

        GameDialogue["Scene1Option2"] = "Forcefully throwing the alarm in frustration the grating beep stopped suddenly as it burst apart on impact with the wall.";        
    }

    private void Start()
    {
       PlayDialogue("Chapter1");
    }    

    public void PlayDialogue(string sceneName)
    {
        string nextLine = GameDialogue[sceneName];
        dialogueText.text = "";
        StartCoroutine(TypeLine(nextLine));        
    }

    private IEnumerator TypeLine(string lineToPrint)
    {        
        for (int i = 0; i < lineToPrint.Length; i++)
        {
            dialogueText.text += lineToPrint[i];
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void EndDialogue()
    {
        // Perform any desired actions when the dialogue ends
        // For example, close the dialogue box or trigger an event
    }
}