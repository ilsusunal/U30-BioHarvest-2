using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtyBar : MonoBehaviour
{
    public float can, animasyonYavasligi;
    private float maxCan;

    public Slider healthSlider; // UI Slider referansý

    void Start()
    {
        maxCan = can;
        healthSlider.maxValue = maxCan; // Slider'ýn maksimum deðerini ayarla
        healthSlider.value = can; // Slider'ý baþlangýç can deðerine ayarla
    }

    void Update()
    {
        // Saðlýk çubuðunu yavaþça küçülmesini saðlayan animasyon
        if (transform.localScale.x > can / maxCan)
        {
            transform.localScale = new Vector3(transform.localScale.x - (transform.localScale.x - can / maxCan) / animasyonYavasligi, transform.localScale.y, transform.localScale.z);
        }

        // Test amaçlý klavyeden can azaltma
        if (Input.GetKeyDown("h"))
        {
            AzaltCan(10);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("water"))
        {
            Debug.Log("Suya dokundu");
            AzaltCan(10);
        }
    }

    // Can deðerini azaltan ve UI Slider'ý güncelleyen metod
    void AzaltCan(float miktar)
    {
        can -= miktar;
        if (can < 0) can = 0;
        healthSlider.value = can; // Can deðeri deðiþtiðinde Slider'ý güncelle
    }

}
