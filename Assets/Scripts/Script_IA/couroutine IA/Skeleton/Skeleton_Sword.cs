﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Coven
{ 
public class Skeleton_Sword : MonoBehaviour
{
    public GameObject holder;
    protected bool IsHiting = false; 
    public void SetIsHiting(bool IsHiting)
    {
        this.IsHiting = IsHiting;
    }
    void OnCollisionEnter(Collision collision) 
    {
        IA_Skeleton_code script = holder.GetComponent<IA_Skeleton_code>();
        if (IsHiting && collision.gameObject == script.GetTarget())
        {
            Debug.Log("hit");
            script.ApplyDamage(collision.gameObject);
            IsHiting = false;
        }
    }
    void Update()
    {
        IA_Skeleton_code script = holder.GetComponent<IA_Skeleton_code>();
        IsHiting = script.Getanimator().GetCurrentAnimatorStateInfo(0).IsName("Attack1h1");
    }
}
}

