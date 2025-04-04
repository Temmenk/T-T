using System;
using System.Collections;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float _launchForce = 1000;
    [SerializeField] float _maxDragDistance = 5;
    Vector2 _startPosition;
    Rigidbody2D _rigidbody2D;

    SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to this GameObject
        _spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component attached to this GameObject
        _startPosition = _rigidbody2D.position; // Store the initial position of the Rigidbody2D component
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startPosition = _rigidbody2D.position; // Store the initial position of the Rigidbody2D component
        _rigidbody2D.isKinematic = true; // Set the Rigidbody2D to kinematic mode 
    }

    void OnMouseDown()
    {
        _spriteRenderer.color = Color.red; // Change the color of the sprite to red when clicked
    }
    void OnMouseUp()
    {
        var currentPosition = _rigidbody2D.position; // Get the current position of the Rigidbody2D component
        Vector2 direction = _startPosition - currentPosition; // Calculate the direction from the current position to the start position
        direction.Normalize();
        
        _rigidbody2D.isKinematic = false; // Set the Rigidbody2D to non-kinematic mode to allow physics interactions
        _rigidbody2D.AddForce(direction * _launchForce); // Apply a force in the direction of the start position
        
        _spriteRenderer.color = Color.white; // Change the color of the sprite back to white when released

        
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get the mouse position in world coordinates

        Vector2 desiredPosition = mousePosition; // Set the desired position to the mouse position
        
        float distance = Vector2.Distance(desiredPosition, _startPosition); // Calculate the distance from the desired position to the start position
        
        if (distance > _maxDragDistance)
        {
            Vector2 direction = desiredPosition - _startPosition; // Calculate the direction from the start position to the desired position
            direction.Normalize(); // Normalize the direction vector
            desiredPosition = _startPosition + (direction * _maxDragDistance); // Clamp the desired position to the maximum drag distance
        }
        if (desiredPosition.x > _startPosition.x)
        {
            desiredPosition.x = _startPosition.x; // Clamp the x position to the start position
        }

        _rigidbody2D.position = desiredPosition; // Set the position of the Rigidbody2D component to the desired position

 
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay()); // Start the coroutine to reset the object after a delay
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        _rigidbody2D.position = _startPosition; // Reset the position to the start position
        _rigidbody2D.isKinematic = true; // Set the Rigidbody2D to kinematic mode
        _rigidbody2D.linearVelocity = Vector2.zero; // Reset the velocity to zero
    }
}
