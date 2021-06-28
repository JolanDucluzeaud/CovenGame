using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordUpHitBox : MonoBehaviour
{
    public GameObject mainSword;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag=="Player")
        {
            mainSword.GetComponent<Boss_Sword>().SetSwordUpHit(true);
        }
    }
}
