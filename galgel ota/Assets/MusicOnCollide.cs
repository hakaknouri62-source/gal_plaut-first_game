using UnityEngine;

public class MusicOnCollide : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // collidor = GetComponent<CircleCollidor2D>(); 
        // public audioSource = GetComponent<AudioSource>();
    }

    // Called on every collision
    void OnCollisionEnter2D(Collision2D collision)
    {   
        // if collided with player
        if (collision.gameObject.CompareTag("Player") && !audioSource.isPlaying)
        {
            // Plays the sound
            audioSource.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
