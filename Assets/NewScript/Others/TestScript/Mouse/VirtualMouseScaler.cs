using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//#if UNITY_EDITOR
//using UnityEditor;

//[InitializeOnLoad]
//#endif

//public class VirtualMouseScaler : InputProcessor<Vector2>
//{
//    public float scale = 1;

//    private const string ProcessorName = nameof(VirtualMouseScaler);

//#if UNITY_EDITOR
//    //static VirtualMouseScaler() =>
//#endif

//    //Processorの登録処理
//    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
//    static void Initialize()
//    {
//        //重複登録すると、Input ActionのProcessor一覧に正しく表示されないことがあるため、
//        //重複チェックを行う
//        //if(InputSystem.TryGetProcessor)
//    }
//}
