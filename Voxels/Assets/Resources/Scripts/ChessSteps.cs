using System.Collections.Generic;
using UnityEngine;

public class ChessSteps : MonoBehaviour
{
    private List<GameObject> enemy = new List<GameObject>();
    private GameObject closest;

    public GameObject rayPoint;

    private bool once;
    private Collider coll;

    void Start()
    {
        rayPoint.transform.position = new Vector3(transform.position.x - GetComponent<UnitBase>().MoveRange * 10f, rayPoint.transform.position.y, rayPoint.transform.position.z);
        once= true;

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("PlayerChess").Length; i++)
        {
            enemy.Add(GameObject.FindGameObjectsWithTag("PlayerChess")[i]);
        } 
    }

    void Update()
    {
       if(!BattleSystem.allySideStep)
       {
            Step();
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(coll.transform.position.x, transform.position.y, coll.transform.position.z), Time.fixedDeltaTime);
       }
       else
            once= true;
    }

    private void Step()
    {
        if(once)
        {
            Ray ray1 = new Ray(transform.position, transform.forward);
            RaycastHit hit1;
            Debug.DrawRay(transform.position, transform.forward, Color.red, Mathf.Infinity);
            if (Physics.Raycast(ray1.origin, ray1.direction, out hit1, GetComponent<UnitBase>().AttackRange * 10f))
            {
                if (hit1.collider.tag == "EnemyChess" || hit1.collider.tag == "PlayerChess")
                {
                    coll = GetComponent<Collider>();
                }
            }
            else
            {
                if (Physics.Raycast(ray1.origin, ray1.direction, out hit1, 5f))
                {
                    if (hit1.collider.tag == "EnemyChess" || hit1.collider.tag == "PlayerChess")
                    {
                        coll = GetComponent<Collider>();
                    }
                }
                else
                {
                    Ray ray = new Ray(rayPoint.transform.position, rayPoint.transform.up);
                    RaycastHit hit;
                    if (Physics.Raycast(ray.origin, ray.direction, out hit, 5f))
                    {
                        if (hit.collider.tag != null)
                        {
                            if (hit.collider.tag == "Ground")
                            {
                                coll = hit.collider;
                                once = false;
                            }
                            else if (GetComponent<UnitBase>().MoveRange > 1)
                                DeletStep();
                        }
                        else if (GetComponent<UnitBase>().MoveRange > 1)
                            DeletStep();
                    }
                    else if (GetComponent<UnitBase>().MoveRange > 1)
                        DeletStep();
                }
            }
        }
    }

    private void DeletStep()
    {
        for (int i = 0; i < GetComponent<UnitBase>().MoveRange; i++)
        {
            rayPoint.transform.position = new Vector3(transform.position.x - (GetComponent<UnitBase>().MoveRange - i) * 10f, rayPoint.transform.position.y, rayPoint.transform.position.z);

            Ray ray2 = new Ray(rayPoint.transform.position, rayPoint.transform.up);
            RaycastHit hit2;

            if (Physics.Raycast(ray2.origin, ray2.direction, out hit2, 5f))
            {
                if (hit2.collider.tag != null)
                {
                    if (hit2.collider.tag == "Ground")
                    {
                        coll = hit2.collider;
                        once = false;
                        break;
                    }
                }
            }
        }
    }

    GameObject FindClosestEnemies()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        for (int i = 0; i < enemy.Count; i++)
        {
            Vector3 diff = enemy[i].transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = enemy[i];
                distance = curDistance;
            }
        }
        return closest;
    }
}
