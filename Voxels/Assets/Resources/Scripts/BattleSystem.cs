using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private List<GameObject> unitsGroup = new List<GameObject>();

    private GameObject enemies;
    private GameObject allies;

    public static bool allySideStep;

    void Start()
    {
        allies = GameObject.Find("Ally");
        enemies = GameObject.Find("Enemy");
        allySideStep= true;
    }

    public void endStep()
    {
        allySideStep = !allySideStep;

        unitsGroup.Clear();

        if(allySideStep)
        {
            for (int i = 0; i < allies.transform.childCount; i++)
            {
                unitsGroup.Add(allies.transform.GetChild(i).gameObject);
            }

            for (int i = 0; i < unitsGroup.Count; i++)
            {
                unitsGroup[i].GetComponent<AttackSystem>().TakeDmg();
            }
        }
        else
        {
            for (int i = 0; i < enemies.transform.childCount; i++)
            {
                unitsGroup.Add(enemies.transform.GetChild(i).gameObject);
            }

            for (int i = 0; i < unitsGroup.Count; i++)
            {
                unitsGroup[i].GetComponent<AttackSystem>().TakeDmg();
            }
        }
    }
}
