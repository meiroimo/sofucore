using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMotionScript : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    public void dethMotion(bool flag)
    {
        animator.SetBool("isDeth", flag);
    }

    public void attackMotion(bool flag)
    {
        animator.SetBool("isAttack", flag);
    }

    public void runMotion(bool flag)
    {
        animator.SetBool("isWalk", flag);
    }

    public void avoidanceMotion(bool flag)
    {
        animator.SetBool("isAvoidance", flag);
    }

    public void ultMotion(bool flag)
    {
        animator.SetBool("isUlt", flag);
    }
}
