using UnityEngine;

public class MeleeEnemy : Enemy
{
    public float attackRange = 2f;

    void Update()
    {
        // Simple forward movement
        transform.Translate(Vector3.forward * enemyData.speed * Time.deltaTime);
    }

    public override void Attack()
    {
        Debug.Log(enemyData.enemyName + " attacks with melee, dealing " + enemyData.damage + " damage.");
        // Add melee attack logic here
    }
}
