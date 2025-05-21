using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inu : Abstract
{
    void Start()
    {
        Animal();
        Nakigoe();
    }

    protected override void Nakigoe()
    {
        Debug.Log("‚í‚ñ‚í‚ñ");
    }

    protected override void Animal()
    {
        Debug.Log("Œ¢‚Å‚·");
    }
}
