using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockXZPosition : MonoBehaviour
{
    private float initialX;
    private float initialZ;

    void Start()
    {
        initialX = transform.position.x;
        initialZ = transform.position.z;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(initialX, transform.position.y, initialZ);
    }
}
