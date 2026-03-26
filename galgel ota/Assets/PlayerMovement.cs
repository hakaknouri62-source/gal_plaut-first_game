using UnityEngine;

[RequireComponent(typeof(Movement))] 
public class PlayerInput : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPower = 10f;

    private Movement movementComponent; 

    void Start()
    {
        movementComponent = GetComponent<Movement>(); 
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        
        movementComponent.MoveHorizontal(moveInput, speed);

        if (Input.GetKeyDown(KeyCode.Space) && movementComponent.isStandingOnGround())
        {
            
            movementComponent.Jump(jumpPower);
        }
    }
}