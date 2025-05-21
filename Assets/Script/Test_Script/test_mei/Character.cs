using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�E��Enum
public enum Job
{
    brave, //���m
    mage,  //���@�g��
    monk,  //�m��
    warrior, //��m
}

public abstract class Character : MonoBehaviour
{
    private string name; //���O
    private Job job;     //�E��
    private int hp;      //HP
    private int mp;      //MP

    public Character(string name, Job job)
    {
        this.name = name;
        this.job = job;

        switch (job)
        {
            case Job.brave:
                this.hp = 100;
                this.mp = 100;
                break;
            case Job.mage:
                this.hp = 80;
                this.mp = 120;
                break;
            case Job.monk:
                this.hp = 90;
                this.mp = 110;
                break;
            case Job.warrior:
                this.hp = 120;
                this.mp = 80;
                break;
            default:
                Debug.Log("���̐E�Ƃ͑��݂��܂���");
                break;
        }
    }

    //�E�Ƃɉ����čU�����@��ύX����
    public abstract void Attack();

    //���O�ƐE�Ƃ�\������
    public void ShowProf()
    {
        Debug.Log("���̖��O��" + this.name);
        Debug.Log("�E�Ƃ�" + this.job.ToString());
    }

    public string GetName()
    {
        return this.name;
    }

    public Job GetJob()
    {
        return this.job;
    }
}
