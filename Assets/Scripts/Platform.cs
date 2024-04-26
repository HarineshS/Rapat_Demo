using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static Platform Instance { get; private set; }

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }
    public float HealthUpdate
    {
        get { return health; }
        set { health = value; }
    }
    public float health = 100f;

    public float moveSpeed = 5f; // Adjust speed as needed
    private Vector3 touchPosition;
    private bool isDragging = false;
    private Rigidbody2D rb;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple Platform instances detected. Make sure there's only one in the scene.");
            Destroy(gameObject);
        }

        rb = GetComponent<Rigidbody2D>();
    }

    public void IncreaseMoveSpeedByPercentage(float percentage)
    {
        moveSpeed *= 1 + percentage / 100f;
    }

    void Update()
    {
        // Handle keyboard movement for testing on PC
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = Vector3.zero;

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
