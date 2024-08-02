using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public EnemyData enemyData;

    protected int currentHealth;

    protected virtual void Start()
    {
        InitializeEnemy();
    }

    void InitializeEnemy()
    {
        currentHealth = enemyData.health;
        Debug.Log(enemyData.enemyName + " initialized with " + currentHealth + " health.");
    }

    public abstract void Attack();

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(enemyData.enemyName + " took " + amount + " damage, remaining health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(enemyData.enemyName + " died.");
        Destroy(gameObject);
    }
}
