using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    public float rateOfFire, SetRateOfFire;
    public bool IsRandom = false;
    public AudioSource BossBulletSound;

    private void Start()
    {
        rateOfFire = 0.75f;
    }
    private void Update()
    {

    }
    public float GetRateOfFire()
    {
        return rateOfFire;    
    }
    public void Fire()
    {
        BossBulletSound.Play();
        Instantiate(projectile, transform.position, transform.rotation);
    }

    

}
