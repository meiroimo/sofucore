using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�L���u��]�؂�v�̋�ۃN���X
/// </summary>
public class RotateSlashSkill : AbstractSkill
{
    //�X�L�����
    public override SkillFactory.SkillKind SkillKind
    {
        get { return SkillFactory.SkillKind.RotateSlash; }
    }

    //�X�L���u��]�؂�v�̎��s
    public override void Play()
    {
        Debug.Log("RotateSlash!");
    }
}
