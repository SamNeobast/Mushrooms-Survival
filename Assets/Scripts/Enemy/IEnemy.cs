using UnityEngine;

public abstract class IEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Transform target;

    private void Start()
    {
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

    }
}
