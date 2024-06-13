using UnityEngine;

public class ChessMovement : MonoBehaviour
{
    public static GameObject selectedUnit;

    private int i;
    private MeshRenderer platformIndicator;

    void Awake()
    {
        platformIndicator = GameObject.Find("PlatformIndicator").GetComponentInChildren<MeshRenderer>();
    }

    void Update()
    {
        if (selectedUnit != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                if (hit.collider.tag != null)
                {
                    if (Mathf.Abs(hit.collider.transform.position.x - selectedUnit.transform.position.x) <= selectedUnit.GetComponent<UnitBase>().MoveRange * 10 && Mathf.Abs(hit.collider.transform.position.z - selectedUnit.transform.position.z) <= selectedUnit.GetComponent<UnitBase>().MoveRange * 10 && hit.collider.tag != "PlayerChess" && hit.collider.tag != "EnemyChess")
                    {
                        if (hit.collider.tag == "Ground")
                            if (hit.collider.gameObject.GetComponent<FieldCell>().busy)
                                platformIndicator.material.color = Color.red;
                            else
                                platformIndicator.material.color = Color.green;
                        else    
                            platformIndicator.material.color = Color.green;
                    } 
                    else
                        platformIndicator.material.color = Color.red;

                    if (Input.GetMouseButtonDown(0))
                    {
                        i++;
                        if (i > 1)
                        {
                            if (platformIndicator.material.color == Color.green)
                            {
                                MoveChess(hit);
                            }
                        }
                    }
                }
            }
        }     
    }

    private void MoveChess(RaycastHit hit)
    {
        selectedUnit.transform.position = new Vector3(hit.collider.transform.position.x, selectedUnit.transform.position.y - 2f, hit.collider.transform.position.z);
        selectedUnit = null;
        platformIndicator.material.color = Color.white;
        i = 0;
    }
}
