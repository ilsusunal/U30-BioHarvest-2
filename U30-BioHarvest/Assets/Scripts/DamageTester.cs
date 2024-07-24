using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTester : MonoBehaviour
{
    public AttributesManager playerAtm;
    public AttributesManager enemyAtm;

    private void Update()
    {
        if (/*trigger tetikleme k�sm� yazmam�z laz�m d��man�n bize vurdu�u k�s�m */ Input.GetKeyDown(KeyCode.P))
        {
            enemyAtm.DealDamage(playerAtm.gameObject);
        }
    }
}
