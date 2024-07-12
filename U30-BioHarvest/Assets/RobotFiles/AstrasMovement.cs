using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstrasMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private float rayDistance = 1.1f;
    [SerializeField] private LayerMask jumpLayer;
    [SerializeField] private Transform rayTransform;
    [SerializeField] private Animator astroAnimator;
    [SerializeField] private Vector3 customGravity = new Vector3(0, -20f, 0); // Yeni yer çekimi kuvveti

    private Rigidbody rb;
    private float verticalMove;
    private float horizontalMove;
    private Vector3 moveDirection;
    private bool isGround;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Physics.gravity = customGravity; // Global yer çekimini ayarla
        astroAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        isGround = GroundCheck();

        horizontalMove = Input.GetAxis("Horizontal") * walkSpeed;
        verticalMove = Input.GetAxis("Vertical") * walkSpeed;

        moveDirection = transform.forward * verticalMove + transform.right * horizontalMove;

        if (horizontalMove == 0 && verticalMove == 0)
        {
            astroAnimator.SetBool("isIdle", true);
            astroAnimator.SetBool("isWalk", false);
            astroAnimator.SetBool("isRun", false);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                astroAnimator.SetBool("isRun", true);
                astroAnimator.SetBool("isWalk", false);
                horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
                verticalMove = Input.GetAxis("Vertical") * runSpeed;
                moveDirection = transform.forward * verticalMove + transform.right * horizontalMove;
            }
            else
            {
                astroAnimator.SetBool("isRun", false);
                astroAnimator.SetBool("isWalk", true);
            }
            astroAnimator.SetBool("isIdle", false);
        }

        moveDirection.y = rb.velocity.y;
        rb.velocity = moveDirection;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    bool GroundCheck()
    {
        if (Physics.Raycast(rayTransform.position, -rayTransform.up, out RaycastHit hitInfo, rayDistance, jumpLayer))
        {
            if (hitInfo.collider.CompareTag("Ground"))
            {
                return true;
            }
        }
        return false;
    }

    private void Jump()
    {
        if (isGround)
        {
            astroAnimator.SetTrigger("isJump");
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}
