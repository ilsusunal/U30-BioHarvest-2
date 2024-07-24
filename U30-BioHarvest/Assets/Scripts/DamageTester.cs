using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTester : MonoBehaviour
{
    public AttributesManager playerAtm;
    public AttributesManager enemyAtm;

    private void Update()
    {
        if (/*trigger tetikleme kýsmý yazmamýz lazým düþmanýn bize vurduðu kýsým */ Input.GetKeyDown(KeyCode.P))
        {
            enemyAtm.DealDamage(playerAtm.gameObject);
        }
    }
}
