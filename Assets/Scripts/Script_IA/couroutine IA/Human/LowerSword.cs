using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerSword : MonoBehaviour
{
    public GameObject UpperSword;
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            UpperSword.GetComponent<Boss_Sword>().SetTargetHitByLaunch(true);
            collider.gameObject.GetComponent<Coven.PlayerStat>().TakeDamage(30,1);
        }
        else if (collider.gameObject.layer == 9)
        {
            UpperSword.GetComponent<Boss_Sword>().SetSwordInWall(true);
        }
    }
    void Update()
    {
        
    }
}
