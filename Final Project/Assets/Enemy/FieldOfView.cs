using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FieldOfView : MonoBehaviour
{
    [Header("EnemyAI")]
    public Transform[] targetPoint;
    public int currentPoint;
    public NavMeshAgent agent;
    public Animator Animator;
    public float waitAtPoint = 2f;
    public float waitCounter;
    public float radius;
    public GameObject Player;
    public BoxCollider EnemyAttack;
    public static bool isDead = false;
    

    [Range(0,360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    public enum AIState
    {
        isDead, isSeekTargetPoint, isSeekPlayer, isAttack
    }
    public AIState state;

    void Start()
    {
        state = AIState.isSeekTargetPoint;
        waitCounter = waitAtPoint;
        StartCoroutine(FOVRoutine());
        playerRef = GameObject.FindGameObjectWithTag("Player");  
    }

    void Update()
    {
        if (HealItem.isStun == false)
        {
            if (isDead == false && ButtonScript_Game.isPause == false)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
                if (distanceToPlayer >= 6f && distanceToPlayer <= 15f && canSeePlayer == true)
                {
                    state = AIState.isSeekPlayer;
                }
                else if (distanceToPlayer >= 15f && canSeePlayer == false)
                {
                    state = AIState.isSeekTargetPoint;
                }
                else
                {
                    if (canSeePlayer == true)
                    {
                        state = AIState.isAttack;
                    }
                }
            }
            else
            {
                state = AIState.isSeekTargetPoint;
                Animator.SetBool("Attack", false);
                Animator.SetBool("isWalking", true);
            }

            switch (state)
            {
                case AIState.isSeekPlayer:
                    agent.SetDestination(Player.transform.position);
                    Animator.SetBool("Run", true);
                    Animator.SetBool("isWalking", false);
                    Animator.SetBool("Attack", false);
                    break;
                case AIState.isSeekTargetPoint:
                    if (currentPoint < targetPoint.Length)
                    {
                        agent.SetDestination(targetPoint[currentPoint].position);
                        Animator.SetBool("Attack", false);
                        if (agent.remainingDistance <= 0.1f)
                        {
                            if (waitCounter > 0)
                            {
                                waitCounter -= Time.deltaTime;
                                Animator.SetBool("isWalking", false);
                                Animator.SetBool("Run", false);
                                Animator.SetBool("Attack", false);
                            }
                            else
                            {
                                currentPoint++;
                                waitCounter = waitAtPoint;
                                Animator.SetBool("isWalking", true);
                                Animator.SetBool("Attack", false);
                            }
                        }
                    }
                    else
                    {
                        currentPoint = 0;
                    }
                    agent.stoppingDistance = 0f;
                    break;

                case AIState.isAttack:
                    RotateTowardPlayer();
                    agent.stoppingDistance = 4f;
                    Animator.SetBool("Run", false);
                    Animator.SetBool("Attack", true);
                    Animator.SetBool("isWalking", false);
                    break;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            HealBar.hpValue = HealBar.hpValue - 1;
            if (HealBar.hpValue == 0)
            {
                HealBar.hpValue = 0;
                isDead = true;
            }
        }
    }

    void RotateTowardPlayer()
    {
        Vector3 direction = (PlayerMove.Instance.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private IEnumerator FOVRoutine()
    {

        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }
}
