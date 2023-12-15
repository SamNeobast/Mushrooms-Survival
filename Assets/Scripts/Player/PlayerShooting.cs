using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float shootInterval;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform gunPoint;
    [SerializeField] private float shootSpeed;

    private float shootTimer;

    private IEnemy[] enemies;
    private void Start()
    {
        enemies = new IEnemy[0];
    }

    private void Update()
    {
        Shooting();
    }

    private void Shooting()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            IEnemy closest = FindClosestEnemy();
            if (closest != null)
            {
                shootTimer = 0;
                GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, Quaternion.identity);
                Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
                Vector3 direction = (closest.transform.position - gunPoint.transform.position).normalized;

                rbBullet.AddForce(direction * shootSpeed);
            }
        }
    }

    private IEnemy FindClosestEnemy()
    {
        IEnemy closestEnemy = null;
        float minDistanse = float.MaxValue;

        foreach (IEnemy enemy in enemies)
        {
            float distance = (enemy.transform.position - transform.position).magnitude;
            if (distance < minDistanse)
            {
                minDistanse = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }



    private void AddEnemyToArray(IEnemy enemy)
    {
        IEnemy[] newArray = new IEnemy[enemies.Length + 1];

        for (int i = 0; i < enemies.Length; i++)
        {
            newArray[i] = enemies[i];
        }

        newArray[enemies.Length] = enemy;

        enemies = newArray;
    }

    private void RemoveEnemyFromArray(IEnemy enemy)
    {
        if (System.Array.IndexOf(enemies, enemy) != -1)
        {
            IEnemy[] newArray = new IEnemy[enemies.Length - 1];

            for (int i = 0, j = 0; i < enemies.Length; i++)
            {
                if (enemies[i] != enemy)
                {
                    newArray[j] = enemies[i];
                    j++;
                }
            }

            enemies = newArray;
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        IEnemy enemyComponent = other.GetComponent<IEnemy>();

        if (enemyComponent != null)
        {
            AddEnemyToArray(enemyComponent);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IEnemy enemyComponent = other.GetComponent<IEnemy>();

        if (enemyComponent != null)
        {
            RemoveEnemyFromArray(enemyComponent);
        }
    }
}