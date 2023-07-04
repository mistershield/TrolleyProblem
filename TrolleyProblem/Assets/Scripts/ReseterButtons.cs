using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReseterButtons : MonoBehaviour
{
    public int sceneIndex; 
    public SceneManagerScript scnenManager;
    private void OnMouseDown()
    {
        scnenManager.LoadScene(sceneIndex);
    }
}
