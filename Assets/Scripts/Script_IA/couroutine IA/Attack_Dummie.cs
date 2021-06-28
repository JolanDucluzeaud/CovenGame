using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Dummie : MonoBehaviour
{
    public GameObject weapon;
    float Can;
    void Update()
    {
        if (Can<=Time.time)
        {
            gameObject.GetComponent<Animator>().SetInteger("Attack",Random.Range(0,6));
            weapon.GetComponent<Hit_Dummie>().SetPlayer(gameObject);
            Can= Time.time + 2;
        }
        else
        {
            gameObject.GetComponent<Animator>().SetInteger("Attack",6);
        }
        
    }
}
