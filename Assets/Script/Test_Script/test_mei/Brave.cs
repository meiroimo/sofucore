using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brave : Character
{
    public Brave(string name):base(name,Job.brave)
    {

    }

    public override void Attack()
    {
        Debug.Log(GetName() + "‚ÌUŒ‚I");
        Debug.Log("Œ•‚ÅUŒ‚I");
    }
}
