using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static float sensitivity = 1f;

    public static float smoothing = 1f;

    public GameObject character;

    private Vector2 mouseLook;
    private Vector2 smoothV;

    void Start()
    { 
        Cursor.lockState = CursorLockMode.Locked;
        character = transform.parent.gameObject;
    }

    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

        mouseLook += smoothV;

        if(mouseLook.y <= 80 && mouseLook.y >= -70)
        {
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        }
        else
        {
            if(mouseLook.y > 80)
            {
                mouseLook.y = 80;
            }
            if (mouseLook.y < -70)
            {
                mouseLook.y = -70;
            }
        }
            
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}