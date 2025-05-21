using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スキル「ヒール」の具象クラス
/// </summary>
public class HealSkill : AbstractSkill
{
    //スキル種別
    public override SkillFactory.SkillKind SkillKind
    {
        get { return SkillFactory.SkillKind.Heal; }
    }

    //スキル「ヒール」の実行
    public override void Play()
    {
        Debug.Log("Heal!");
    }
}
