using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField] AudioClip[] _clips; // Array of audio clips to play on collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 5f)
        {
            var clip = _clips[UnityEngine.Random.Range(0, _clips.Length)]; // Select a random audio clip from the array
            GetComponent<AudioSource>().PlayOneShot(clip); // Play the audio clip attached to the AudioSource component
        }
        else
        {
            Debug.Log("collision was not strong enough to play sound"); // Log a message if the collision was not strong enough
        }
    }
}
