using Coven;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_IA : Coven.enemy_couroutine
{
    public float health = 1000;
    private float MaxHealth;
    public Animator animator;
    public Image PVbar;
    public GameObject mainSword;
    public GameObject mainSword2;
    GameObject[] listTarget;
    int nbTarget;
    bool canDoAction;
    bool InFight;

    public override void chase() { }
    public override void attack() { }
    public override void TakeDamage(PlayerStat player){}
    public override void TakeDamage(float damage)
    {
        if (mainSword.GetComponent<Boss_Sword>().GetCurrentAction() != Action.ShieldOfSword)
        {
            health -= damage;
            if (health <= 0)
            {
                animator.SetTrigger("Dead");
                Destroy(gameObject, 5);
            }
        }
    }

    public override IEnumerator CheckEntity()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator fighting()
    {
        throw new System.NotImplementedException();
    }


    public void SetCanDoAction(bool canDoAction)
    {
        this.canDoAction = canDoAction;
    }
    public void SetInFight(bool inFight)
    {
        InFight = inFight;
    }
    public void TakeDamage(int dmg)
    {
        if (mainSword.GetComponent<Boss_Sword>().GetCurrentAction()!=Action.ShieldOfSword)
        {
        health-=dmg;
        if (health<=0)
        {
            animator.SetTrigger("Dead");
            Destroy(gameObject,5);
        }
        }
    }
    IEnumerator ChooseAttackClose()
    {
        while(true){
        canDoAction = false;
        int attack = Random.Range(0,6);
        mainSword.GetComponent<Boss_Sword>().SetCurrentActon(attack);
        mainSword2.GetComponent<Boss_Sword>().SetCurrentActon(attack);
        yield return new WaitUntil(()=> canDoAction==true);
        }
    }
    void Start()
    {
        StartCoroutine(ChooseAttackClose());
        MaxHealth = health;
        
    }
    void Update()
    {
        PVbar.fillAmount = health / MaxHealth;

        if (InFight)
        {
            listTarget = GameObject.FindGameObjectsWithTag("Player");
            if(listTarget.Length==0){InFight=false;}
            else{mainSword.GetComponent<Boss_Sword>().SetTarget(listTarget[0]);
            mainSword2.GetComponent<Boss_Sword>().SetTarget(listTarget[0]);}
            nbTarget = listTarget.Length;
        }
    }
}
