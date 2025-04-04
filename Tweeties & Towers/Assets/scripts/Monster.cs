using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]

public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite; // Reference to the dead sprite
    [SerializeField] ParticleSystem _particleSystem; // Reference to the particle system
    
    bool _hasDied;
    [SerializeField] float _maxFallDistance = 10f;
    
    float _startY; // Store the initial Y position of the monster

    void Start()
    {
        _startY = transform.position.y; // Store the initial Y position of the monster
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDieFromCollision(collision))
        {
            StartCoroutine(Die()); // Call the Die method if the collision is with a Bird
        }
    }

    bool ShouldDieFromCollision(Collision2D collision)
    {
        if (_hasDied) return false; // If the monster has already died, ignore further collisions

        if (_startY - transform.position.y > _maxFallDistance)
        return true;
        
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
        
            return true; // The collision is with a Bird, so the monster should die

            if (collision.contacts[0].normal.y < -0.5f)
            {
                return true; // The collision is with a Bird, so the monster should die
            }

            return false; // The collision is not with a Bird, so the monster should not die
        
    }
    IEnumerator Die()
    {
        _hasDied = true; // Set the monster as dead to prevent further deaths
        GetComponent<SpriteRenderer>().sprite = _deadSprite; // Change the sprite to the dead sprite
        _particleSystem.Play(); // Play the particle system
        yield return new WaitForSeconds(3.0f); // Wait for 3 seconds before playing the particle system
        gameObject.SetActive(false); // Deactivate the monster GameObject
    }
}