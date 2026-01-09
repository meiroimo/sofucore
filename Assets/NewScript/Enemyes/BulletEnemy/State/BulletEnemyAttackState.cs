using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyAttackState : BulletEnemyState
{
    public override void Enter(BulletEnemyController bulletEnemy)
    {
        Debug.Log("íeÇÃê∂ê¨");
        bulletEnemy.InitBullet();
        bulletEnemy.Agent.ResetPath();   //à⁄ìÆÇë¶í‚é~ ResetPath:í‚é~

        bulletEnemy.StartCoroutine(RecoverFromHit(bulletEnemy));
    }

    public override void Update(BulletEnemyController bulletEnemy)
    {

    }

    public override void Exit(BulletEnemyController bulletEnemy)
    {

    }

    private IEnumerator RecoverFromHit(BulletEnemyController bulletEnemy)
    {
        yield return new WaitForSeconds(1f); //çdíº
        bulletEnemy.ChangeState(new BulletEnemyChaseState());
    }

}
