using System.Collections.Generic;
using UnityEngine;

public class FieldGeneration : MonoBehaviour
{
    public Vector2Int gridSize;
    public GameObject prefab1;
    public GameObject prefab2;
    public Transform parent;

    private int y;
    private int o;

    public void Generate()
    {
        var size = prefab1.GetComponent<MeshRenderer>().bounds.size;
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                y++;
                if (y%2 == 1)
                {
                    var pos = new Vector3(i * size.x, 0, j * size.z);
                    var cell = Instantiate(prefab1, pos, Quaternion.identity, parent);
                }  
            }
            if (i % 2 == 1)
                y = 0;
            else
                y = 1;
        }

        var size2 = prefab2.GetComponent<MeshRenderer>().bounds.size;
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                o++;
                if (o % 2 == 0)
                {
                    var pos = new Vector3(i * size2.x, 0, j * size2.z);
                    var cell = Instantiate(prefab2, pos, Quaternion.identity, parent);
                }
            }
            if (i % 2 == 0)
                o = 1;
            else
                o = 0;
        }
    }
}
