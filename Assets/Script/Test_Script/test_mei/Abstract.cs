using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// https://note.com/08_14/n/ne1030bc9186e
/// </summary>
public abstract class Abstract : MonoBehaviour
{
    protected abstract void Nakigoe();//抽象メソッド
    protected virtual void Animal() { Debug.Log("アニマルクラスやで"); }
}
