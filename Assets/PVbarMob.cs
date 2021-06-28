using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PVbarMob : MonoBehaviour
{
    public GameObject mob;
    private Image image;
    private float MaxHp = 0;
    protected Coven.IA_Skeleton_code skeleton;

    // Start is called before the first frame update
    void Start()
    {   
        skeleton = mob.gameObject.GetComponent<Coven.IA_Skeleton>().Skeleton;
        MaxHp = skeleton.GetHealth();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        image.fillAmount = skeleton.GetHealth() / MaxHp;
    }


}
