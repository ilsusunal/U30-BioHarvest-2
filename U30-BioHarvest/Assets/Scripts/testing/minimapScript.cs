using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapScript : MonoBehaviour
{
    [SerializeField] Transform player;
    private void LateUpdate()
    {
        Vector3 minimap = player.position;
        minimap.y = transform.position.y;
        transform.position = minimap;
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
