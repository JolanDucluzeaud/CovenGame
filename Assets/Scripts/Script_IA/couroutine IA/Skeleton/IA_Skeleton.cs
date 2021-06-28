using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.UI;
 
namespace Coven 
{ 
public class IA_Skeleton : MonoBehaviour 
{ 
    public Animator animator; 
    public GameObject Weapon;
    CapsuleCollider playerCollider; 
    public IA_Skeleton_code Skeleton;
    public Image pvBar;
        private float MaxHp;
        private bool drop = false;
        public GameObject[] dropItem;
    void Awake() 
    { 
        Skeleton = gameObject.AddComponent<IA_Skeleton_code>(); 
        Skeleton.SetTarget(null); 
        Skeleton.SetAnimator(animator);
        Skeleton.SetWeapon(Weapon);
        ((enemy_couroutine)Skeleton).SetAttackRange(2.5f); 
        ((enemy_couroutine)Skeleton).SetMoveSpeed(1.5f); 
        ((enemy_couroutine)Skeleton).SetAttackDelay(1.5f); 
        ((enemy_couroutine)Skeleton).SetAttackDammage(15);
        ((enemy_couroutine)Skeleton).SetHealth(300);  
        Skeleton.StartCoroutine("CheckEntity");
        MaxHp = Skeleton.GetHealth();
    } 
    // Update is called once per frame 
    void Update() 
    {

            if (Skeleton.GetHealth() <= 0 && !drop)
            {
                animator.SetBool("Dead", true);
                Skeleton.GetTarget().gameObject.GetComponent<UnarmedCharacter>().Coins += 200;
                drop = true;
                return;
            }
            if (Skeleton.GetHealth() <= 0)
            {
                return;
            }
        pvBar.fillAmount = Skeleton.GetHealth() / MaxHp;
        if (Time.time>Skeleton.GetAllow_action()) 
        { 
            if (Skeleton.GetTarget()!=null)
            {
            float Distance = Vector3.Distance(Skeleton.transform.position,Skeleton.GetTarget().transform.position);
            if (Distance>Skeleton.GetFightingRange()) 
            { 
                Skeleton.chase(); 
            } 
            else 
            { 
                if (Distance<=Skeleton.GetAttackRange()) 
                { 
                    Skeleton.attack(); 
                } 
                else 
                { 
                    if (Skeleton.GetFight() && Distance<=Skeleton.GetFightingRange()) 
                    { 
                        Skeleton.StartCoroutine("fighting"); 
                    } 
                }     
            } }
        } 
        else 
        { 
            if (Skeleton.GetTarget()!=null)
            {
                Vector3 Targetposition = new Vector3 (Skeleton.GetTarget().transform.position.x, transform.position.y, Skeleton.GetTarget().transform.position.z); 
                transform.LookAt (Targetposition); 
                transform.position=Vector3.MoveTowards(transform.position,Skeleton.GetTarget().transform.position, 6*Time.deltaTime); 
            }
        }
    } 
}
}