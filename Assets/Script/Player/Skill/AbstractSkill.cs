using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スキルの抽象クラス
/// 参考：https://qiita.com/okk_archives/items/fd45e579d0bcc2bc889b
/// 抽象クラスについて：https://note.com/08_14/n/ne1030bc9186e
/// </summary>
public abstract class AbstractSkill
{
    //スキル種別の抽象プロパティ
    public abstract SkillFactory.SkillKind SkillKind { get; }

    //スキル実行の抽象メソッド
    public abstract void Play();
}
