using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class maouController : MonoBehaviour
{
    public Transform firePoint; //Projectile
    public GameObject projectilePrefab; //Prefab กระสุน
    public float detectionRange = 75f; // ระยะ Detect
    
    private EnemyProjectile EnPro;
    private float fireRate;
    private float fireRateDelta;

    public GameObject Player;
    private Transform player; // Player ขยับ
    private float timeSinceLastFire = 0f; //ความถี่กระสุน

    public Animator animator;

    private bool isPlayerDetected = false;
    private bool hasRoared = false;

    public static int bossHP = 90;

    
    void Start()
    {
        EnPro = GetComponentInChildren<EnemyProjectile>();
        fireRate = EnPro.GetRateOfFire();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player object not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HealBar.hpValue > 0)
        {
            if (Vector3.Distance(transform.position, player.position) <= detectionRange)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.rotation = Quaternion.LookRotation(direction);
                isPlayerDetected = true;
                if (isPlayerDetected && !hasRoared)
                {
                    detectionRange = 200f;
                    animator.SetBool("isPlayerDetected", true);
                    animator.SetBool("triggerRoar", true);
                    hasRoared = true;
                    fireRateDelta -= Time.deltaTime;
                    if (fireRateDelta <= 0)
                    {
                        EnPro.Fire();
                        fireRateDelta = fireRate;
                    }
                }
                else
                {
                    isPlayerDetected = false;
                    hasRoared = false;
                }
            }
            if (bossHP == 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("CS3");
            }
        } 
    }
    
}
