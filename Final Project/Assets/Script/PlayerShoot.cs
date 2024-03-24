using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public float shootSpeed = 300f;
    // Start is called before the first frame update
    

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shootBullet();
        }
    }
    void shootBullet()
    {
        //Get the Rigidbody that is attached to that instantiated bullet
        var projectile = Instantiate(bulletPrefab, transform.position, transform.rotation);

        //Shoot the Bullet
        projectile.velocity = transform.forward * shootSpeed;
    }

    

            
        
        
}

    

