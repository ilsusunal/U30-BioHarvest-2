using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] int bulletCount = 15;
    [SerializeField] Transform shootingPoint;
    [SerializeField] GameObject bulletPrefab;

    bool isPressing;
    [SerializeField] float fireRate = 10f;
    float shootTimer;

    [SerializeField] int damage;
    private void Awake()
    {
        CreatePool();
    }

    void CreatePool()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject _currentBullet = Instantiate(bulletPrefab);
            _currentBullet.GetComponent<Bullet>().parentObject = shootingPoint;
            _currentBullet.GetComponent<Bullet>().damage = damage;
            _currentBullet.transform.SetParent(shootingPoint);
            _currentBullet.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            isPressing = true;    
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            isPressing = false;
        }
        shootTimer -= Time.deltaTime;
        if (shootTimer < 0 && isPressing) 
        {
            Shoot();
        }

    }

    void Shoot()
    {
        shootTimer = 1f / fireRate;
        GameObject _currentBulelt = shootingPoint.transform.GetChild(0).gameObject;

        _currentBulelt.transform.position = shootingPoint.position;
        _currentBulelt.transform.rotation = shootingPoint.rotation;
        _currentBulelt.transform.SetParent(null);
        _currentBulelt.transform.localScale = Vector3.one * 0.2f;
        _currentBulelt.SetActive(true);
    }
}
