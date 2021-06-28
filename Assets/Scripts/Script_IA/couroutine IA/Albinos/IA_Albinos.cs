﻿using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
namespace Coven
{ 
public class IA_Albinos : MonoBehaviour 
{ 
    public Animator animator;
    public GameObject Weapon;
    CapsuleCollider playerCollider; 
    IA_Albinos_code Albinos; 
    void Awake() 
    { 
        Albinos = gameObject.AddComponent<IA_Albinos_code>(); 
        Albinos.SetTarget(null); 
        Albinos.SetAnimator(animator); 
        Albinos.SetWeapon(Weapon);
        ((enemy_couroutine)Albinos).SetAttackRange(0); 
        ((enemy_couroutine)Albinos).SetMoveSpeed(4); 
        ((enemy_couroutine)Albinos).SetAttackDelay(3); 
        ((enemy_couroutine)Albinos).SetAttackDammage(5);
        ((enemy_couroutine)Albinos).SetFightingRange(10);
        ((enemy_couroutine)Albinos).SetHealth(200);
        Albinos.StartCoroutine("CheckEntity");
    } 
    // Update is called once per frame 
    void Update() 
    { 
        if (Time.time>Albinos.GetAllow_action() && Albinos.GetTarget()!=null) 
        { 
            float Distance = Vector3.Distance(Albinos.transform.position,Albinos.GetTarget().transform.position);
             if (Albinos.GetFight() && Distance<=Albinos.GetFightingRange()) 
                { 
                    Albinos.StartCoroutine("fighting"); 
                } 
             else 
                { 
                    Vector3 Targetposition = new Vector3 (Albinos.GetTarget().transform.position.x, transform.position.y, Albinos.GetTarget().transform.position.z);
                    transform.LookAt (Targetposition);  
                } 
        }
    } 
} 
} 

