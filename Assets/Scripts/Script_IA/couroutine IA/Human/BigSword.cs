using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSword : MonoBehaviour
{
    public GameObject mainSword;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag=="Player")
        {
            collider.gameObject.GetComponent<Coven.PlayerStat>().TakeDamage(35,1);
        }
    }
}
