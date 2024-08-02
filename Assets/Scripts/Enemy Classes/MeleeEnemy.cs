using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public string enemyName = "Melee Enemy";
    public int health = 100;
    public float speed = 2f;
    public int damage = 10;
    public float attackRange = 2f;

    void Update()
    {
        // Move forward constantly
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void Attack()
    {
        Debug.Log(enemyName + " attacks with melee, dealing " + damage + " damage.");
        // Melee attack logic
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
