using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private UserInput userInput;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveInput;

    private void Awake()
    {
        userInput = GetComponent<UserInput>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    private void Update()
    {
        ReadMovement();
    }

    private void ReadMovement()
    {
        moveInput = userInput.MoveInput;

        if (moveInput == Vector2.zero)
        {
            animator.SetBool("moving", false);

            return;
        }

        animator.SetBool("moving", true);
        animator.SetFloat("xValue", moveInput.x);
        animator.SetFloat("yValue", moveInput.y);
    }
}
