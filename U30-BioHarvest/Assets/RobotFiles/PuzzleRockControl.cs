using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public class PuzzleRockControl : MonoBehaviour
{
    [SerializeField] Animator rockanimator;
    [SerializeField] Transform astraTransform;
    [SerializeField] GameObject Pearl;
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

        if(Pearl.activeSelf)
        {
            astraTransform.position = new Vector3(-190f, 161f, -144f);
            astraTransform.rotation.y.Equals(175f);
            this.gameObject.SetActive(false);
        }
        else
        {
            astraTransform.position = new Vector3(177, 158, -587);
            astraTransform.rotation.y.Equals(320f);
            this.gameObject.SetActive(false);
        }
    }
}
