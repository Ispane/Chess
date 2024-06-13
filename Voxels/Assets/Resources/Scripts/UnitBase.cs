using UnityEngine;

public enum Side
{
    Enemy,
    Ally
}

public class UnitBase : MonoBehaviour
{
    public string Name;

    public float MoveRange;
    public float AttackRange;

    public Side UnitSide;

    public int MaxHealth;
    [HideInInspector] public int Health;
    public int Armor;
    public int Damage;

    private void Start()
    {
        Health = MaxHealth;
    }

    private void Update()
    {
        if(Health <= 0)
            Destroy(gameObject);
    }
}
