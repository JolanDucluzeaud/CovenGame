using System.Collections; 
using System.Collections.Generic; 
using System; 
using UnityEngine; 
namespace Coven
{ 
    public class Skeleton_Dummie : MonoBehaviour 
    { 
        public Animator animator;
        private int delay_jump = 10; 
        private int allow_jump = 0; 
        private float allow_action=0; 
        private float accel = 0.1f;
 
        private bool fight = true; 
        public bool GetFight() 
        { 
            return fight; 
        } 
        public float GetAllow_action() 
        { 
            return allow_action; 
        } 
        public void TakeDamage()
        {
            animator.Play("Hit1");
        }
    } 
}

