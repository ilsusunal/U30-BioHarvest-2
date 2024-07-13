using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtyBar : MonoBehaviour
{
    public float can, animasyonYavasligi;
    private float maxCan, gercekScale;
    
    void Start()
    {
        maxCan = can;    
    }

    
    void Update()
    {
        gercekScale = can / maxCan;
        if (transform.localScale.x > gercekScale)
        {
            transform.localScale = new Vector3(transform.localScale.x - (transform.localScale.x-gercekScale)/ animasyonYavasligi, transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetKeyDown("h"))
        {
            can -= 10;
        }

        if (can < 0)
        {
            can = 0;
        }

    }
}
