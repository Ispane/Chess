using UnityEngine;

public class SelectChess : MonoBehaviour
{
    private GameObject platformIndicator;

    void Awake()
    {
        platformIndicator = GameObject.Find("PlatformIndicator");
    }

    void Start()
    {
        if (platformIndicator.activeSelf)
            platformIndicator.SetActive(false);
    }

    private void OnMouseEnter()
    {
        platformIndicator.SetActive(true);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            if (hit.collider.tag != null)
            {
                var pos = hit.collider.transform.position;
                platformIndicator.transform.position = new Vector3(pos.x, platformIndicator.transform.position.y, pos.z);
            }
        }
    }

    private void OnMouseDown()
    {
        if(GetComponent<UnitBase>().UnitSide == Side.Ally)
        {
            if (ChessMovement.selectedUnit == null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
                    ChessMovement.selectedUnit = gameObject;
                }
            }
        } 
    }

    private void OnMouseExit()
    {
        if (platformIndicator.activeSelf)
            platformIndicator.SetActive(false);
    }
}
