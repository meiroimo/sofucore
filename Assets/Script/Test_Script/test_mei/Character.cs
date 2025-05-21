using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//E‹ÆEnum
public enum Job
{
    brave, //Œ•m
    mage,  //–‚–@g‚¢
    monk,  //‘m—µ
    warrior, //ím
}

public abstract class Character : MonoBehaviour
{
    private string name; //–¼‘O
    private Job job;     //E‹Æ
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
                Debug.Log("‚»‚ÌE‹Æ‚Í‘¶İ‚µ‚Ü‚¹‚ñ");
                break;
        }
    }

    //E‹Æ‚É‰‚¶‚ÄUŒ‚•û–@‚ğ•ÏX‚·‚é
    public abstract void Attack();

    //–¼‘O‚ÆE‹Æ‚ğ•\¦‚·‚é
    public void ShowProf()
    {
        Debug.Log("„‚Ì–¼‘O‚Í" + this.name);
        Debug.Log("E‹Æ‚Í" + this.job.ToString());
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
