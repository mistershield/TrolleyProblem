using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    //The bounds of the object
    public Bounds bounds = new Bounds();

    private bool clicked;
    private Vector3 mousePosition;

    //Detects if the object is being clicked
    private void OnMouseDown()
    {
        clicked = true;
    }

    //Detects when the object stops being clicked
    private void OnMouseUp()
    {
        clicked = false;
    }

    //Sets the position of the object to the world position of the player cursor if the position is within the bounds of the object
    private void Update()
    {
        if (clicked && Time.timeScale > 0)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
            transform.position = bounds.ClosestPoint(transform.position);
        }
    }
}
