using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiyoko : Abstract
{
    void Start()
    {
        Animal();
        Nakigoe();
    }

    protected override void Nakigoe()
    {
        Debug.Log("‚Ò‚æ‚Ò‚æ");
    }

    protected override void Animal()
    {
        Debug.Log("ƒqƒˆƒR‚â‚Å");
    }
}
