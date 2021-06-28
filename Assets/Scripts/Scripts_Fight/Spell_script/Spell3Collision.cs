using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell3Collision : MonoBehaviour
{
    public float spellDamage;
    //tu peux rajouter la varible knockback s'il en faut une
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("mob"))
        {
            col.gameObject.GetComponent<Coven.enemy_couroutine>().TakeDamage(20);
            col.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 2, -col.transform.forward.z*3), ForceMode.Impulse);
        }
    }
}
