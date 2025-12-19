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
    public void StopAttack()
    {
        animator.SetBool("isAttack", false);

    }

    public void runMotion(bool flag)
    {
        animator.SetBool("isWalk", flag);
    }


    public void TrueBack()
    {
        animator.SetBool("isBack", true);
    }

    public void TrueFront()
    {
        animator.SetBool("isFront", true);
    }

    public void StopBack()
    {
        animator.SetBool("isBack", false);
    }

    public void StopFront()
    {
        animator.SetBool("isFront", false);
    }

    public void ultMotion(bool flag)
    {
        animator.SetBool("isUlt", flag);
    }
}
