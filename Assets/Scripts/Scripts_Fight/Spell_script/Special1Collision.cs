using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special1Collision : MonoBehaviour
{
    private float duration = 4;
    public Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponentInParent<Animator>();
        animator.SetBool("isSpecialSword", true);
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("mob"))
        {
            //col.gameObject.GetComponent<>().ApplyDamage.... //il faut ajouter les damages
            //ATTENTION !!! l'ennemi est touché 200 fois maximum durant l'anim !
            col.gameObject.GetComponent<Coven.enemy_couroutine>().TakeDamage(0.3f);
        }
    }

    private void Update()
    {
        if (animator.GetInteger("Weapon") == 1)
        {
            if (duration > 0)
            {
                duration -= Time.deltaTime;
            }
            else
            {
                duration = 4;
                animator.SetBool("isSpecialSword", false);
                Debug.Log("Stop");
                Destroy(gameObject);
            }
        }
        else
        {
            duration = 4;
            animator.SetBool("isSpecialSword", false);
            Debug.Log("Stop");
            Destroy(gameObject);
        }
    }
}
