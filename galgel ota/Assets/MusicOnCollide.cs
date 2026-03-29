using UnityEngine;

public class MusicOnCollide : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject Explosion;
    public float boomScale;
    public AudioSource boomSong;
    public float boomThreshold;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        // collidor = GetComponent<CircleCollidor2D>(); 
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

        //if we hit it hard enough it also explodess
        float impactSpeed = collision.relativeVelocity.magnitude;

        if (impactSpeed >= boomThreshold)
        {
            // Calculate scale based on speed
            float size = impactSpeed * boomScale;
            Explode(size);
        }
        
    }
    void Explode(float boomSize)
    {
// 1. Spawn Visuals
        GameObject boom = Instantiate(Explosion, transform.position, Quaternion.identity);
        boom.transform.localScale *= boomSize;
        // 2. Physical Blast
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(transform.position, boomSize);
        
        foreach (Collider2D col in objectsInRange)
        {
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Calculate direction from explosion to object
                Vector2 direction = (col.transform.position - transform.position).normalized;
                rb.AddForce(direction * boomSize);
            }
        }

        // 3. RIP my granny she got hit by a bazooka
        boomSong.Play();

        // 4. Remove the original ball
        Destroy(gameObject);
        Destroy(boom,1);
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
