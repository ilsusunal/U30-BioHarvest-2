using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] Rigidbody rb;
    float verticalMove;
    float horizontalMove;
    Vector3 moveDirection;

    bool isGround;
    [SerializeField] float jumpPower;
    [SerializeField] float rayDistance;
    [SerializeField] LayerMask jumpLayer;
    [SerializeField] Transform rayTransform;
    [SerializeField] Animator Astroanimator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * movementSpeed;
        verticalMove = Input.GetAxis("Vertical") * movementSpeed;

        moveDirection = transform.forward * verticalMove + transform.right * horizontalMove;

        if(horizontalMove==0 && verticalMove==0)
        {
           Astroanimator.SetTrigger("isIdle");
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Astroanimator.SetTrigger("isRun");
            }
            else
            {
                Astroanimator.SetTrigger("isWalk");
            }
        }

        if (GroundCheck() && Input.GetKeyDown(KeyCode.Space))
        {
            Astroanimator.SetTrigger("isJump");
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = rb.velocity.y;
        }
        rb.velocity = moveDirection;
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
}
