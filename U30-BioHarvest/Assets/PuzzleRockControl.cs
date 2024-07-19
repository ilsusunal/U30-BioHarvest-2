using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PuzzleRockControl : MonoBehaviour
{
    [SerializeField] Animator rockanimator;
    [SerializeField] Transform astraTransform;
    [SerializeField] GameObject rocktransform;
    private void Awake()
    {
        rockanimator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            rockanimator.SetTrigger("isWrong");
        }
    }

    public void WrongPlace()
    {
        astraTransform.position = new Vector3(-190f, 161f, -144f);
        //astraTransform.rotation.y = new Vector3(0f, 175f, 0f);
    }
}
