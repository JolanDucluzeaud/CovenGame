using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special3Collision : MonoBehaviour
{
    public float spellDamage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("mob"))
        {
            col.gameObject.GetComponent<Coven.enemy_couroutine>().TakeDamage(50);
            col.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3 (0,3, -col.transform.forward.z), ForceMode.Impulse);
        }
    }
}
