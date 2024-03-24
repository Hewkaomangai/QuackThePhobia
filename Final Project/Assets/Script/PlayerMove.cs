using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float stamina;
    float maxStamina;

    public Image staminaBar;
    public float dValue;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Animator")]
    public Animator animator;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    public int maxHP = 3;

    Rigidbody rb;

    [Header("Angle")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;

    public TextMeshProUGUI textMeshPro;
    public static PlayerMove Instance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        maxStamina = stamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.IsDead == false)
        {
            grounded = Physics.Raycast(transform.position, -transform.up, whatIsGround);
            staminaBar.fillAmount = stamina / maxStamina;

            
            MyInput();

            if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
            {
                moveSpeed = 60f;
                animator.SetBool("isRunning", true);
                DecreaseEnergy();

            }
            else
            {
                moveSpeed = 30f;
                animator.SetBool("isRunning", false);
                if (stamina != maxStamina)
                {
                    StartCoroutine(DelayIncreaseStamina());
                }
            }

            if (grounded)
            {
                rb.drag = groundDrag;
            }
            else
            {
                rb.drag = 0;
            }
        }
        else if (PlayerHealth.hpValue <= 0 && PlayerHealth.IsDead == true)
        {
            animator.SetBool("isDeath", true);
            rb.velocity = Vector3.zero;
        }


    }

    IEnumerator DelayIncreaseStamina()
    {
        yield return new WaitForSeconds(3f);
        IncreaseEnergy();
    }

    private void IncreaseEnergy()
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            stamina += dValue * 1f * Time.deltaTime;
        }
        if (stamina >= maxStamina)
        {
            stamina = maxStamina;
        }        
    }

    private void DecreaseEnergy()
    {
        if (stamina >= 0)
        {
            stamina -= dValue * 1f * Time.deltaTime;
        }
        else if (stamina < 0)
        {
            stamina = 0;
        }       
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));

        if (OnSlope())
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 10f, ForceMode.Force);
        }
    }
    public void TakeDamage(int damage)
    {
        maxHP--;
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    
       
    
}
