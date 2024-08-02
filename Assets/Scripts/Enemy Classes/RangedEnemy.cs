using UnityEngine;

public class RangedEnemy : Enemy
{
    public GameObject projectilePrefab;
    public float fireRate = 1f;
    private float nextFireTime;

    void Update()
    {
        // Simple forward movement
        transform.Translate(Vector3.forward * enemyData.speed * Time.deltaTime);

        if (Time.time > nextFireTime)
        {
            Attack();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    public override void Attack()
    {
        Debug.Log(enemyData.enemyName + " attacks with a ranged projectile.");
        // Instantiate a projectile and shoot it
        Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation);
    }
}
