using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHitReaction : MonoBehaviour
{
    [Header("‚Ì‚¯‚¼‚éŠp“x")] public float knockAngle;

    [Header("‚Ð‚Ë‚é‘¬‚³")]public float rotateSpeed;

    private bool isReacting = false;

    public void PlayHitReaction()
    {
        if(!isReacting)
        {
            StartCoroutine(HitReaction());
        }
    }

    private IEnumerator HitReaction()
    {
        if (isReacting) yield break;
        isReacting = true;

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            Debug.Log("nav‚¨‚Ó");
            agent.isStopped = true;
            agent.updateRotation = false;//NavMeshAgent‚Ì‰ñ“]‚ðŽ~‚ß‚é
        }

        //‚Ì‚¯‚¼‚è‘O‚ÌŠp“x
        Quaternion startRot = transform.rotation;

        //X•ûŒü‚ÖŒX‚¯‚é
        Quaternion targetRot = Quaternion.Euler(knockAngle, startRot.eulerAngles.y, startRot.eulerAngles.z);

        //ŒX‚¯‚é
        while (Quaternion.Angle(transform.rotation, targetRot) > 0.5f)
        {
            //transform.rotation. += rotateSpeed;//Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * rotateSpeed);
            yield return null;
        }

        //–ß‚·
        while (Quaternion.Angle(transform.rotation, startRot) > 0.5f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, startRot,
                Time.deltaTime * rotateSpeed);
            yield return null;
        }

        transform.rotation = startRot;

        if (agent != null)
        {
            agent.isStopped = false;
            agent.updateRotation = true;
        }

        isReacting = false;
    }

}
