using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スキル「回転切り」の具象クラス
/// </summary>
public class RotateSlashSkill : AbstractSkill
{
    //スキル種別
    public override SkillFactory.SkillKind SkillKind
    {
        get { return SkillFactory.SkillKind.RotateSlash; }
    }

    //スキル「回転切り」の実行
    public override void Play()
    {
        Debug.Log("RotateSlash!");
    }
}
