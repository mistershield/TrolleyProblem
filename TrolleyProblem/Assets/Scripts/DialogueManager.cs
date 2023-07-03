using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public float textSpeed = 0.05f;
    public List<DialogueContainer> dialogueContainerList = new List<DialogueContainer>();

    private string nextLine;

    public void PlayDialogue(int problemDialogueSetIndex, string currentDialogueDescription)
    {
        dialogueText.text = "";
        StopAllCoroutines();
        nextLine = dialogueContainerList[problemDialogueSetIndex].dialogueDictorinary[currentDialogueDescription];
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
}