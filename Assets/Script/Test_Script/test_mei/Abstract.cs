using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// https://note.com/08_14/n/ne1030bc9186e
/// </summary>
public abstract class Abstract : MonoBehaviour
{
    protected abstract void Nakigoe();//���ۃ��\�b�h
    protected virtual void Animal() { Debug.Log("�A�j�}���N���X���"); }
}
