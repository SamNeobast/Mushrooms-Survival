using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float shootInterval;
    [SerializeField] private GameObject bulletPrefab;


    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private float shootTimer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Shooting();
    }

    private void FixedUpdate()
    {
        Movement();
    }


    private void Movement()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
    }

    private void Shooting()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            shootTimer = 0;
            GameObject bullet = Instantiate(bulletPrefab, transform);
        }
    }
}
