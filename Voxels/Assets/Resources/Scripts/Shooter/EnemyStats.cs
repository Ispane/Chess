using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health;
    public int armor;
    public int damage;
    public int moveSpeed;

    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
