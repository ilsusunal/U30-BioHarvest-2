using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Windows.WebCam;
//using static UnityEditor.Progress;

public class DoorControl : MonoBehaviour
{
    [SerializeField] private Animator animator; 
    [SerializeField] private GameObject rocketCam;
    [SerializeField] private GameObject doorCanvas;
    [SerializeField] private Transform rayTransform;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject originalAstra;
    private bool isPlayerInRange = false;
    private void Awake()
    {
        rocketCam.SetActive(false);
    }
    public void AnimationFinished()
    {
        rocketCam.SetActive(true);
        originalAstra.SetActive(false);
    }

    private void Update()
    {
        if (Physics.Raycast(rayTransform.position, rayTransform.right, out RaycastHit hitInfo, rayDistance, playerLayer))
        {
            isPlayerInRange = true;

            if (doorCanvas.activeSelf != true)
            {
                doorCanvas.SetActive(true);
            }
        }
        else
        {
            isPlayerInRange = false;

            if (doorCanvas.activeSelf != false)
            {
                doorCanvas.SetActive(false);
            }
        }

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("isOpening", true);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && rocketCam.activeSelf)
        {
            rocketCam.SetActive(false);
            animator.SetBool("isClosing", true);
            originalAstra.SetActive(true);
        }
    }
}
