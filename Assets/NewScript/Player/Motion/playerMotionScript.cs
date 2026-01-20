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
    public void dethMotion()
    {
        animator.Play("deth");
    }

    public void attackMotion()
    {
        animator.Play("attak");
    }

    public void runMotion()
    {
        animator.Play("walk");

    }
    public void isRunMotion(bool flag)
    {
        animator.SetBool("isWalk", flag);

    }


    public void TrueBack()
    {
        animator.SetBool("isWalk", false);
        animator.Play("avoidance_back",0,0);
    }

    public void TrueFront()
    {
        animator.SetBool("isWalk", false);

        animator.Play("avoidance_front",0,0);
    }

    public void ultMotion()
    {
        animator.Play("ult");
    }

    public void idleMotion()
    {
        animator.Play("Idol");

    }
}
