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
        Debug.Log("�����");
    }

    protected override void Animal()
    {
        Debug.Log("���ł�");
    }
}
