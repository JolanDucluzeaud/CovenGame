using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Coven {
public class PlayerWeapon : MonoBehaviour
{
    bool isHiting;
    UnarmedCharacter player;
    IA_Albinos_code Dragon;
    IA_Hob_Code Hob;
    IA_Skeleton_code Skeleton;
    Skeleton_Dummie Dummie;
    Boss_IA Boss;
    Animator animator;

        /*public void SetIsHiting(bool isHiting)
        {
            this.isHiting=isHiting;
        }*/

    private void Start()
    {
        animator = gameObject.GetComponentInParent<UnarmedCharacter>().gameObject.GetComponent<Animator>();
        player = gameObject.GetComponentInParent<UnarmedCharacter>();
    }

    /*public void SetPlayer(GameObject player)
    {
        this.player=player;
    }*/
    public string GetScript(GameObject mob)
    {
        if (mob.GetComponent<IA_Skeleton_code>()!=null)
        {
            Skeleton = mob.GetComponent<IA_Skeleton_code>();
            return "Skeleton";
        }
        if (mob.GetComponent<IA_Hob_Code>()!=null)
        {
            Hob = mob.GetComponent<IA_Hob_Code>();
            return "Hob";
        }
        if (mob.GetComponent<IA_Albinos_code>()!=null)
        {
            Dragon = mob.GetComponent<IA_Albinos_code>();
            return "Dragon";   
        } 
        if (mob.GetComponent<Skeleton_Dummie>()!=null)
        {
            Dummie = mob.GetComponent<Skeleton_Dummie>();
            return "Dummie";
        }
        if (mob.GetComponent<Boss_IA>()!=null)
        {
            Boss = mob.GetComponent<Boss_IA>();
            return "Boss";
        }
        return null;
    }
    void OnTriggerEnter(Collider collider)
    {
        if (animator.GetBool("AnimCanAttack") && collider.gameObject.tag == "mob" )
        {
            Debug.Log("the player is hitting a mob");
            
            Debug.Log(GetScript(collider.gameObject));
            switch (GetScript(collider.gameObject))
            {
                case "Hob" : Hob.TakeDamage(player.damagePower);
                             break;
                case "Dragon" : Dragon.TakeDamage(player.damagePower);
                                break;
                case "Skeleton" : Skeleton.TakeDamage(player.damagePower);
                                  break;
                case "Boss" : Boss.TakeDamage(player.damagePower);
                              break;
                default: Dummie.TakeDamage();
                         break;
            }
            
        }
    }
}}
