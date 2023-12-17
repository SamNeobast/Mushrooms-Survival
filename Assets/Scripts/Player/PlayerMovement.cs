using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 movementDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        ActivateMovingAnimation();
    }

    private void Movement()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
    }

    private const string NameWalkingBoolAnim = "Walking";
    private void ActivateMovingAnimation()
    {
        if (movementDirection != Vector2.zero)
        {
            anim.SetBool(NameWalkingBoolAnim, true);
        }
        else
        {
            anim.SetBool(NameWalkingBoolAnim, false);
        }
    }
}
