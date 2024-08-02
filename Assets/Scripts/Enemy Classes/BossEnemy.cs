using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public string enemyName = "Boss Enemy";
    public int health = 300;
    public float speed = 1f;
    public int damage = 20;
    public float specialAttackCooldown = 10f;
    private float nextSpecialAttackTime;

    void Update()
    {
        // Move forward constantly
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Time.time > nextSpecialAttackTime)
        {
            SpecialAttack();
            nextSpecialAttackTime = Time.time + specialAttackCooldown;
        }
    }

    public void Attack()
    {
        Debug.Log(enemyName + " performs a standard boss attack, dealing " + damage + " damage.");
        // Standard attack logic
    }

    public void SpecialAttack()
    {
        Debug.Log(enemyName + " performs a special attack!");
        // Special attack logic
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
