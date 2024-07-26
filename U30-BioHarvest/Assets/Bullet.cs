using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float speed;
    public Transform parentObject;

    float timer;
    [SerializeField] float bulletLifeTime = 5f;

    public int damage;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
    }

    private void OnEnable()
    {
        timer = bulletLifeTime;
    }

    void DestroyBullet()
    {
        gameObject.SetActive(false);
        transform.parent = parentObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag("Player")) 
        {
            DestroyBullet();
        }

    }

    private void Update()
    {
        rb.velocity = transform.forward * speed;
        
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            DestroyBullet();
        }
    }

}
