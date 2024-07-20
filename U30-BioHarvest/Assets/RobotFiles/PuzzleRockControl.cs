using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PuzzleRockControl : MonoBehaviour
{
    [SerializeField] Animator rockanimator;
    [SerializeField] Transform astraTransform;
    private void Awake()
    {
        rockanimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rockanimator.SetTrigger("isWrong");
        }
    }

    public void WrongPlace()
    {
        astraTransform.position = new Vector3(-190f, 161f, -144f);
        astraTransform.rotation.y.Equals(175f);
        this.gameObject.SetActive(false);
    }
}
