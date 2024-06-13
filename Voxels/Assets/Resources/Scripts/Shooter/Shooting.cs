using UnityEngine;

public class Shooting : MonoBehaviour
{
    private GameObject playerCamera;
    private float shootingTemp;

    private float timer;

    void Start()
    {
        playerCamera = GameObject.Find("PlayerCamera");
        shootingTemp = 0.8f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GunShooting();
        }

       /* if (Input.GetMouseButton(0))
        {
            timer += Time.fixedDeltaTime * shootingTemp;
            if(timer >= 1) 
            {
                timer= 0;
                GunShooting();
            }  
        }

        if(Input.GetMouseButtonUp(0)) 
        {
            timer = 0;
        }*/
    }

    private void GunShooting()
    {
        RaycastHit hit;
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            if(hit.collider.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<EnemyStats>().health -= 1;
            }
        }
    }
}
