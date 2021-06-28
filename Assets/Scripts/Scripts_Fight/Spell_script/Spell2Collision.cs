using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell2Collision : MonoBehaviour
{
    public float spellDamage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("mob"))
        {
            col.gameObject.GetComponent<Coven.enemy_couroutine>().TakeDamage(25); ;
            Destroy(gameObject);
        }
    }
}
