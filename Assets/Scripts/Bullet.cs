using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float shootSpeed;

    private Rigidbody2D rb;
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Vector3 direction = transform.right;

        rb.AddForce(direction * shootSpeed);

    }
}
