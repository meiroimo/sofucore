using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�L���̒��ۃN���X
/// �Q�l�Fhttps://qiita.com/okk_archives/items/fd45e579d0bcc2bc889b
/// ���ۃN���X�ɂ��āFhttps://note.com/08_14/n/ne1030bc9186e
/// </summary>
public abstract class AbstractSkill
{
    //�X�L����ʂ̒��ۃv���p�e�B
    public abstract SkillFactory.SkillKind SkillKind { get; }

    //�X�L�����s�̒��ۃ��\�b�h
    public abstract void Play();
}
