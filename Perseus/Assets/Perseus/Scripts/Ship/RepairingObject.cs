using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairingObject : Interactable
{
    public IDamageable damagebleObject;
    public float coroutineTime = 5f;
    private bool isRepairing = true;

    private void Start()
    {
        damagebleObject = gameObject.GetComponent<IDamageable>();
    }

    public override void Interact(PersonStats stats, Animator anim)
    {
        anim.SetFloat("Idle_SpaceIdle", 0.0f);
        anim.SetFloat("Idle_Walk", -1.0f);
        stats.work = true;
        if (isRepairing)
            StartCoroutine(FixObject(stats, anim));
    }

    IEnumerator FixObject(PersonStats _stats, Animator _anim)
    {
        isRepairing = false;
        _anim.SetBool("IsRepairing", true);
        yield return new WaitForSeconds(coroutineTime);
        damagebleObject.getFixed(_stats.reparingSkill);
        _anim.SetBool("IsRepairing", false);
        _stats.interact = false;
        InteractComplete(_stats);
        isRepairing = true;
    }

    public override void InteractComplete(PersonStats stats)
    {
        base.InteractComplete(stats);
    }
}
