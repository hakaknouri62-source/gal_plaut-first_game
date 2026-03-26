using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform groundCheck;    
    public float groundCheckRadius = 0.2f;    
    public LayerMask groundLayer;   
    private Rigidbody2D rb; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void MoveHorizontal(float directionInput, float moveSpeed)
    {
        rb.linearVelocity = new Vector2(directionInput * moveSpeed, rb.linearVelocity.y);
    }
    public void Jump(float jumpForce)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
    public bool isStandingOnGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}