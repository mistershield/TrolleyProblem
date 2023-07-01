using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public Bounds bounds = new Bounds();
    private bool clicked;
    private Vector3 mousePosition;

    private void OnMouseDown()
    {
        clicked = true;
    }

    private void OnMouseUp()
    {
        clicked = false;
    }
    private void Update()
    {
        if (clicked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
            transform.position = bounds.ClosestPoint(transform.position);
        }
    }
}
