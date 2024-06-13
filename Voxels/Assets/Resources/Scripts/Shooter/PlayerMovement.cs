using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool ground;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.Translate(movement * Time.fixedDeltaTime * 0.5f);

        if (Physics.Raycast(transform.position, Vector3.down, 1f, 1))
            ground = true;
        else
            ground = false;

        if (Input.GetKeyDown(KeyCode.Space) && ground)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 10f, 0), ForceMode.Impulse);
        }
    }
}
