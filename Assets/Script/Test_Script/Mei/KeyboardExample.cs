using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardExample : MonoBehaviour
{
    private void Update()
    {
        //現在のキーボード情報
        var current = Keyboard.current;

        //キーボード接続チェック
        if(current == null)
        {
            //キーボードが押されてないと
            //Keyboard.currentがnullになる
            return;
        }

        //Aキーの入力状態取得
        //var aKey = current.aKey;
        var aKey = current[Key.A];


        //Aキーが押された瞬間かどうか
        if(aKey.wasPressedThisFrame)
        {
            Debug.Log("Aキーが押された！");
        }

        //Aキーが離された瞬間かどうか
        if(aKey.wasReleasedThisFrame)
        {
            Debug.Log("Aキーが離された！");
        }

        //Aキーが押されているかどうか
        if(aKey.isPressed)
        {
            Debug.Log("Aキーが押されている！");
        }
    }
}
