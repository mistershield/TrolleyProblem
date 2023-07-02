using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public string[] lines;
    public float textSpeed = 0.05f;
    public float deltaTextSpeed = 0.01f;
    private float tempTextSpeed;

    private int currentLineIndex = -1;
    private bool isFastForwarding = false;
    private bool isTyping = false;
    private string currentLine = "";

    private float lastClickTime;
    private float doubleClickDelay = 0.3f;

    private void Start()
    {
        NextLine();
        tempTextSpeed = textSpeed;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isTyping)
            {
                NextLine();
            }

            lastClickTime = Time.time;
        }

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            textSpeed = 0.00001f;
        }
        else
        {
            textSpeed = tempTextSpeed;
        }        
    }

    private IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = "";
        currentLine = lines[currentLineIndex];

        //dialogueText.text = "";

        //foreach (char letter in lines[currentLineIndex].ToCharArray())
        //{
        //    if (!isFastForwarding)
        //    {
        //        dialogueText.text += letter;
        //        yield return new WaitForSeconds(textSpeed);
        //    }
        //    else
        //    {
        //        dialogueText.text = lines[currentLineIndex]; // Set the full line instantly
        //    }
        //}

        for (int i = 0; i < currentLine.Length; i++)
        {
            dialogueText.text += currentLine[i];
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
        isFastForwarding = false;
    }

    private void NextLine()
    {
        currentLineIndex++;

        if (currentLineIndex < lines.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            // Dialogue is finished, do something else (e.g., load next scene)
        }
    }

    private void EndDialogue()
    {
        // Perform any desired actions when the dialogue ends
        // For example, close the dialogue box or trigger an event
    }
}