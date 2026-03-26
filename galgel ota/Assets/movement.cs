using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Ground Detection")]
    /* The specific point on the character (usually the feet) to check for the ground */
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    
    /* How wide the invisible ground-checking circle should be */
    public float groundCheckRadiusLeft = 0.2f;    
    public float groundCheckRadiusRight = 0.2f; 
    
    /* Tells the physics engine which layers (like "Floor" or "Platform") count as solid ground */
    public LayerMask groundLayer;   

    /* The physics body we will push around to make the character move */
    private Rigidbody2D rb; 

    void Start()
    {
        /* Grab the Rigidbody2D component attached to this GameObject as soon as the game starts */
        rb = GetComponent<Rigidbody2D>();
    }

    /* * Moves the Rigidbody2D left or right based on input, without interrupting gravity/falling.
     * directionInput: The horizontal axis input (usually between -1 and 1).
     * moveSpeed: How fast the character should move.
     */
    public void MoveHorizontal(float directionInput, float moveSpeed)
    {
        rb.linearVelocity = new Vector2(directionInput * moveSpeed, rb.linearVelocity.y);
    }

    /* * Applies an instant vertical velocity to make the character jump.
     * jumpForce: The upward power of the jump.
     */
    public void Jump(float jumpForce)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    /* * Checks if the invisible circles at the character's feet are overlapping with the ground layer.
     * Returns true if AT LEAST ONE foot is touching the ground.
     */
    public bool isStandingOnGround()
    {
        // Changed && to || so you can still jump when standing on a ledge!
        bool leftFootGrounded = Physics2D.OverlapCircle(groundCheckLeft.position, groundCheckRadiusLeft, groundLayer);
        bool rightFootGrounded = Physics2D.OverlapCircle(groundCheckRight.position, groundCheckRadiusRight, groundLayer);
        
        return leftFootGrounded || rightFootGrounded;
    }

    /* * This is a built-in Unity method that draws visual debugging shapes in the Scene view.
     * We make sure the slots aren't empty before trying to draw around them.
     */
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; 

        // Draw Left Foot
        if (groundCheckLeft != null)
        {
            Gizmos.DrawWireSphere(groundCheckLeft.position, groundCheckRadiusLeft);
        }

        // Draw Right Foot
        if (groundCheckRight != null)
        {
            Gizmos.DrawWireSphere(groundCheckRight.position, groundCheckRadiusRight);
        }
    }
}