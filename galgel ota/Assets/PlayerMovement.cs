using UnityEngine;

[RequireComponent(typeof(Movement))] 
public class PlayerInput : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPower = 10f;

    private Movement movementComponent; 

    // Capitalized the first letter to match C# style!
    void MoveHorizontal(float currentSpeed)
    {
        float moveInput = Input.GetAxis("Horizontal");
        movementComponent.MoveHorizontal(moveInput, currentSpeed);
    }
    
    // Cleaned up the name slightly to read like a question
    bool IsJumpLegal()
    {
        return Input.GetKeyDown(KeyCode.Space) && movementComponent.isStandingOnGround();
    }
    
    void Start()
    {
        movementComponent = GetComponent<Movement>(); 
    }

    void Update()
    {
        MoveHorizontal(speed);

        if (IsJumpLegal())
        {
            movementComponent.Jump(jumpPower);
        }
    }
}