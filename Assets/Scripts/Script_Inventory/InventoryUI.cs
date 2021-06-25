﻿using System;
using System.Collections;
using Photon.Pun.Demo.SlotRacer;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    private Inventory inventory;

    public GameObject Inventory_UI;
    
    private InventorySlot[] slots;
    
    [SerializeField]private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.OnItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        animator = Inventory_UI.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (!Inventory_UI.activeSelf)
            {
                Inventory_UI.SetActive(true);
            }
            else
            {
                animator.SetTrigger("Trigger");
                StartCoroutine(wait());
            }
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(0.80f);
        Inventory_UI.SetActive(false);
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        
    }
}
