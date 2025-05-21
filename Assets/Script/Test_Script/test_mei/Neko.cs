using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neko : Abstract
{
    void Start()
    {
        Animal();
        Nakigoe();
    }

    protected override void Nakigoe()
    {
        Debug.Log("Ç…Ç·Å[Ç…Ç·Å[");
    }

}
