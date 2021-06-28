using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public GameObject boss;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag=="Player")
        {
            boss.GetComponent<Boss_IA>().SetInFight(true);
        }
    }
}
