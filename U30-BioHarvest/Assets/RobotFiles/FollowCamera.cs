using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] float xSent = 300;
    [SerializeField] float ySent = 300;

    float xRotation;
    float yRotation;
    [SerializeField] Transform cameraHolder;

    void Start()
    {
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * xSent * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * ySent * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

        cameraHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}