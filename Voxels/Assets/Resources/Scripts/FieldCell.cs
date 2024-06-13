using UnityEngine;

public class FieldCell : MonoBehaviour
{
    public bool busy;
    private GameObject platformIndicator;

    void Awake()
    {
        platformIndicator = GameObject.Find("PlatformIndicator");
    }

    void Start()
    {
        if(platformIndicator.activeSelf)
            platformIndicator.SetActive(false);
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit2;
        if (Physics.Raycast(ray.origin, ray.direction, out hit2, 5f))
            busy = true;
        else
            busy = false;
    }

    private void OnMouseEnter()
    {
        platformIndicator.SetActive(true);
        platformIndicator.transform.position = new Vector3(transform.position.x, platformIndicator.transform.position.y, transform.position.z);
    }

    private void OnMouseExit()
    {
        if (platformIndicator.activeSelf)
            platformIndicator.SetActive(false);
    }
}
