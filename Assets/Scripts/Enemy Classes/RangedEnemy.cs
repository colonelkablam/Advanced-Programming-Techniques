using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public string enemyName = "Ranged Enemy";
    public int health = 80;
    public float speed = 1.5f;
    public int damage = 5;
    public GameObject projectilePrefab;
    public float fireRate = 1f;
    private float nextFireTime;

    void Update()
    {
        // Move forward constantly
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Time.time > nextFireTime)
        {
            Attack();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    public void Attack()
    {
        Debug.Log(enemyName + " attacks with a ranged projectile, dealing " + damage + " damage.");
        // Instantiate and fire projectile
        Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log(enemyName + " took " + amount + " damage, remaining health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(enemyName + " died.");
        Destroy(gameObject);
    }
}
