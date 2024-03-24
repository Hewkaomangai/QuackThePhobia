using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    
    [SerializeField] float ProjectileSpeed = 5f;
    

    private void Update()
    {
        transform.Translate(new Vector3(0f, 0f, ProjectileSpeed*Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerMove player = collision.gameObject.GetComponent<PlayerMove>();
            if (player != null)
            {
                HealBar.hpValue = HealBar.hpValue-1;
            }
            Destroy(gameObject);
        }
       
    }
}
