using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//職業Enum
public enum Job
{
    brave, //剣士
    mage,  //魔法使い
    monk,  //僧侶
    warrior, //戦士
}

public abstract class Character : MonoBehaviour
{
    private string name; //名前
    private Job job;     //職業
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
                Debug.Log("その職業は存在しません");
                break;
        }
    }

    //職業に応じて攻撃方法を変更する
    public abstract void Attack();

    //名前と職業を表示する
    public void ShowProf()
    {
        Debug.Log("私の名前は" + this.name);
        Debug.Log("職業は" + this.job.ToString());
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
