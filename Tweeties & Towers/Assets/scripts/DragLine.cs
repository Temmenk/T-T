using UnityEngine;

public class DragLine : MonoBehaviour
{
    LineRenderer _lineRenderer;
    Bird _bird;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>(); // Get the LineRenderer component attached to this GameObject
        _bird = FindObjectOfType<Bird>(); // Find the Bird component in the scene
        // Vector3 lineZeroPosition = new Vector3(
        //     _bird.transform.position.x, // Set the X position of the line to the Bird's X position
        //     _bird.transform.position.y, // Set the Y position of the line to the Bird's Y position
        //     -0.1f); // Set the Z position of the line to -0.1

        _lineRenderer.SetPosition(0, _bird.transform.position); // Set the first position of the line to the Bird's position
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_bird.IsDragging) // Check if the bird is being dragged
        {
            _lineRenderer.enabled = true; // Enable the line renderer to show the line
            _lineRenderer.SetPosition(1, _bird.transform.position); // Set the first position of the line to the position of the Bird
        }
        else
        {
            _lineRenderer.enabled = false; // Disable the line renderer when not dragging
        }
    }
}
