using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalKit : Interactable {

    public float medHelp;
    public float coroutineTime = 5f;
    private bool isHealing = true;

    public override void Interact(PersonStats stats, Animator anim)
    {
        anim.SetFloat("Idle_SpaceIdle", 0.0f);
        anim.SetFloat("Idle_Walk", -1.0f);

        if (isHealing)
            StartCoroutine(AddMedHelp(stats, medHelp, anim));
    }

    IEnumerator AddMedHelp(PersonStats _stats, float _medHelp, Animator _anim)
    {
        isHealing = false;
        _anim.SetBool("IsHealing", true);
        yield return new WaitForSeconds(coroutineTime);
        _stats.ChangeLife(_medHelp);
        _anim.SetBool("IsHealing", false);
        _stats.interact = false;
        InteractComplete(_stats);
    }

    public override void InteractComplete(PersonStats stats)
    {
        base.InteractComplete(stats);
    }
}
