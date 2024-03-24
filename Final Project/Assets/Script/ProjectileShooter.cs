using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;
    public float nextFire = 0.0f;
    public float fireRate = 1f;
    public int bulletDMG = 3;
    [SerializeField][Range(0f, 10f)] public float timeToDestroy = 0.5f;
    public AudioSource BulletSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire && PlayerHealth.IsDead == false)
        {
            BulletSound.Play();
            nextFire = Time.time + fireRate;
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
            Destroy(ball, timeToDestroy);
        }
    }
    

}
