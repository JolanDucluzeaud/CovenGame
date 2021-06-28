using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Sword : MonoBehaviour
{
    public string typeSword;
    Action CurrentAction = Action.NotAttacking;
    public GameObject BigSword;
    public GameObject SwordShield;
    public GameObject SwordAttack;
    public GameObject holder;
    public GameObject lowerSword;
    public GameObject center;
    public GameObject centerShield;
    public GameObject pos;
    protected GameObject target;
    protected bool first=false;
    protected bool swordUpHit = false;
    protected bool canDoDmg = true;
    protected bool TargetHitByLaunch = false;
    protected bool canLaunchSword = true;
    protected bool SwordInWall= false;
    public void SetSwordInWall(bool swordInWall)
    {
        SwordInWall= swordInWall;
    }
    public void SetSwordUpHit(bool Hit)
    {
        swordUpHit= Hit;
    }
    public void SetCurrentActon(int action)
    {
        CurrentAction=(Action)action;
    }
    public Action GetCurrentAction()
    {
        return CurrentAction;
    }
    public void SetTargetHitByLaunch(bool isHit)
    {
        TargetHitByLaunch= isHit;
    }
    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
    public void idle_4sword()
    {
        Debug.Log("Idle_Sword is playing");
        transform.RotateAround(center.transform.position,new Vector3(0,0,1),10);
        lowerSword.transform.RotateAround(center.transform.position,new Vector3(0,0,1),10);
    }
    public void LaunchSword(Vector3 position)
    {
        Debug.Log("L'epee est lancé vers la cible");
        lowerSword.transform.position= Vector3.MoveTowards(lowerSword.transform.position,position+ new Vector3(0,1,0),0.15F);
    }
    IEnumerator CoolDownGetBackSword()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1);
        }
        lowerSword.transform.position = transform.position + new Vector3(0,(float)0.8,0);
        lowerSword.transform.rotation = transform.rotation;
        SwordInWall = false;
        canLaunchSword=true;
    }
    public void BasicAttack1()
    {
        if (typeSword=="L")
        {
            transform.Rotate(Vector3.left*2,Space.Self);
        }
        else
        {
            transform.Rotate(Vector3.right*2,Space.Self);
        }
    }
    public void Tourbillion()
    {
        transform.RotateAround(holder.transform.position+ new Vector3(0,1,0),new Vector3(0,1,0),4);
    }
    public void SwordUp()
    {
        SwordAttack.transform.position = Vector3.MoveTowards(SwordAttack.transform.position,SwordAttack.transform.position + new Vector3(0,6,0),0.2F);
    }
    public void pullTarget(Vector3 position)
    {
        target.transform.Translate(Vector3.forward);
        lowerSword.transform.Translate(Vector3.forward);
    }
    IEnumerator actionRange()
    {
        if(canLaunchSword && target!=null)
        {
            lowerSword.transform.LookAt(target.transform.position);
            Vector3 position =target.transform.position;
            while(!SwordInWall)
            {
                LaunchSword(position);
                if(TargetHitByLaunch)
                {
                    /*while (!SwordInWall)
                    {
                        Debug.Log("on se fait transporter");
                        pullTarget(position);
                        yield return new WaitForEndOfFrame();
                    }*/
                    break;
                }
                yield return new WaitForEndOfFrame();
            }
            canLaunchSword=false;
            StartCoroutine(CoolDownGetBackSword());
        }
        yield return new WaitForEndOfFrame();
    }
    IEnumerator forward()
    {
        holder.GetComponent<Animator>().SetBool("IsRunning",true);
        while(true)
            {
                holder.transform.LookAt(target.transform.position);
                holder.transform.position = Vector3.MoveTowards(holder.transform.position,new Vector3(target.transform.position.x,holder.transform.position.y,target.transform.position.z),0.0005F);
                yield return new WaitForEndOfFrame();
            }
    }
    IEnumerator BackWard()
    {
        holder.GetComponent<Animator>().SetBool("IsRunning",true);
        while (true)
                {
                    holder.transform.LookAt(-target.transform.position);
                    holder.transform.position = Vector3.MoveTowards(holder.transform.position,new Vector3(-target.transform.position.x,holder.transform.position.y,-target.transform.position.z),0.0005F);
                    yield return new WaitForEndOfFrame();
                }
    }
    IEnumerator action()
    { 
        while (true){ if(target!=null){Debug.Log("action :" +CurrentAction);
        switch (CurrentAction)
        { 
            case Action.BasicAttack1 : 
            StartCoroutine(actionRange());
            StartCoroutine(forward());
            for (int t = 0; t < 6; t++){
                    for (int i = 0; i < 20; i++)
                    {
                        BasicAttack1();
                        yield return new WaitForEndOfFrame();
                    }
                    if (typeSword=="L"){typeSword="R";}
                    else {typeSword="L";}
                    for (int i = 0; i < 20; i++)
                    {                   
                        BasicAttack1();
                        yield return new WaitForEndOfFrame();
                    }
                    canDoDmg = true;
                    if (typeSword=="L"){typeSword="R";}
                    else {typeSword="L";}
                    yield return new WaitForEndOfFrame();
                    }
                    StopCoroutine(forward());
                    holder.GetComponent<Animator>().SetBool("IsRunning",false);
                    break;
            case Action.WomboCombo :
                    StartCoroutine(forward());
                    if(typeSword=="L"){transform.Rotate(90, 0, 90);}
                    else{transform.Rotate(270, 0, 90);}
                    for (int i = 0; i < 250; i++)
                    {
                        Tourbillion();
                        yield return new WaitForEndOfFrame();
                    }
                    canDoDmg = true;
                    for (int i = 0; i < 250; i++)
                    {
                        transform.RotateAround(holder.transform.position+ new Vector3(0,1,0),new Vector3(0,-1,0),4);
                        yield return new WaitForEndOfFrame();
                    }
                    StopCoroutine(forward());
                    holder.GetComponent<Animator>().SetBool("IsRunning",false);
                    transform.SetPositionAndRotation(pos.transform.position,pos.transform.rotation);
                    yield return new WaitForSeconds(1);
                    if(!first){
                    CurrentAction = Action.WomboCombo2;
                    SwordAttack.SetActive(true);
                    while(SwordAttack.transform.position.y<holder.transform.position.y + 20)
                    {
                        SwordUp();
                        yield return new WaitForEndOfFrame();
                    }
                    SwordAttack.SetActive(false);
                    swordUpHit = false;}
                    break;
            case Action.ShieldOfSword :  StartCoroutine(BackWard());
                    gameObject.transform.localScale = new Vector3(0, 0, 0);
                    lowerSword.transform.localScale = new Vector3(0, 0, 0);
                    SwordShield.SetActive(true);
                    for (int i = 0; i < 500; i++)
                    {
                        SwordShield.transform.RotateAround(centerShield.transform.position,new Vector3(0,1,0),1);
                        yield return new WaitForEndOfFrame();
                    }
                    gameObject.transform.localScale = new Vector3(0.8F, 0.8F, 0.8F);
                    lowerSword.transform.localScale = new Vector3(0.8F, 0.8F, 0.8F);
                    SwordShield.SetActive(false);
                    StopCoroutine(BackWard());
                    holder.GetComponent<Animator>().SetBool("IsRunning",false);
                    break;
            case Action.BigSwordSwing :
                    holder.transform.LookAt(-target.transform.position);
                    gameObject.transform.localScale = new Vector3(0, 0, 0);
                    lowerSword.transform.localScale = new Vector3(0, 0, 0);
                    BigSword.SetActive(true);
                for (int t = 0; t < 3; t++)
                {
                    for (int i = 0; i < 27; i++)
                    {
                        BigSword.transform.Rotate(Vector3.down*0.5F,Space.Self);
                        yield return new WaitForEndOfFrame();
                    }
                    for (int i = 0; i < 27; i++)
                    {
                        BigSword.transform.Rotate(Vector3.up*0.5F,Space.Self);
                        yield return new WaitForEndOfFrame();
                    }
                    BigSword.transform.Rotate(0, 90, 90);
                    if(t==0){BigSword.transform.position = new Vector3(BigSword.transform.position.x,BigSword.transform.position.y +2,BigSword.transform.position.z);}
                    if(t==1){BigSword.transform.position = new Vector3(BigSword.transform.position.x,BigSword.transform.position.y -3,BigSword.transform.position.z);}
                    if(t==2){BigSword.transform.position = new Vector3(BigSword.transform.position.x,BigSword.transform.position.y +1,BigSword.transform.position.z);}
                }
                BigSword.SetActive(false);
                gameObject.transform.localScale = new Vector3(0.8F, 0.8F, 0.8F);
                lowerSword.transform.localScale = new Vector3(0.8F, 0.8F, 0.8F);
                break;
            default: StartCoroutine(BackWard());for (int i = 0; i < 25; i++)
                {
                    idle_4sword();
                    yield return new WaitForEndOfFrame();
                } StopCoroutine(BackWard());holder.GetComponent<Animator>().SetBool("IsRunning",false);StartCoroutine(forward());
                for (int i = 0; i < 25; i++)
                {
                    transform.RotateAround(center.transform.position,new Vector3(0,0,-1),10);
                    lowerSword.transform.RotateAround(center.transform.position,new Vector3(0,0,-1),10);
                    yield return new WaitForEndOfFrame();
                }StopCoroutine(forward());holder.GetComponent<Animator>().SetBool("IsRunning",false);
                break;
        }}
        transform.SetPositionAndRotation(pos.transform.position,pos.transform.rotation);
        if(CurrentAction!=Action.BasicAttack1){
        lowerSword.transform.position = transform.position + new Vector3(0,(float)0.8,0);
        lowerSword.transform.rotation = transform.rotation;}
        canDoDmg = true;
        holder.GetComponent<Boss_IA>().SetCanDoAction(true);
        yield return new WaitForEndOfFrame();}
    }
    void Start()
    {
        StartCoroutine(action());
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && (CurrentAction == Action.BasicAttack1 || CurrentAction == Action.WomboCombo) && canDoDmg)
        {
            collider.gameObject.GetComponent<Coven.PlayerStat>().TakeDamage(1,1);
            canDoDmg = false;
        }
    }                                               
}
public enum Action
{
    NotAttacking,
    BasicAttack1,
    WomboCombo,
    WomboCombo2,
    ShieldOfSword,
    BigSwordSwing,
}
