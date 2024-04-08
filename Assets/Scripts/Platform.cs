using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust speed as needed

    private Vector3 touchPosition;
    private bool isDragging = false;

    void Update()
    {
        // Handle keyboard movement for testing on PC
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);

        // Simulate touch movement with mouse click and drag
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            touchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 delta = Input.mousePosition - touchPosition;
            transform.Translate(delta.x * moveSpeed * Time.deltaTime, delta.y * moveSpeed * Time.deltaTime, 0);
        }
    }
}
