﻿using System.Collections;
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
            Debug.Log("Ennemi touché ! spell 2"); //il faut appliquer les dégâts
            Destroy(gameObject);
        }
    }
}
