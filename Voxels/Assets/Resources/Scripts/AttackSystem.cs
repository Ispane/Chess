using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    public static Vector2 entityPos;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDmg()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, GetComponent<UnitBase>().AttackRange * 10f))
        {
            if (hit.collider.tag != null)
            {
                if(hit.collider.gameObject.GetComponent<UnitBase>().UnitSide != GetComponent<UnitBase>().UnitSide)
                {
                    entityPos = hit.collider.transform.position;
                    DamageUI.Instance.AddText(GetComponent<UnitBase>().Damage, hit.collider.transform.position);

                    hit.collider.gameObject.GetComponent<UnitBase>().Health -= GetComponent<UnitBase>().Damage;
                }
            }
        }
    }
}
