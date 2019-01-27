using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : Interactable {

    public float water;
    public float coroutineTime = 5f;
    private bool isDrinking = true;

    public override void Interact(PersonStats stats, Animator anim)
    {
        anim.SetFloat("Idle_SpaceIdle", 0.0f);
        anim.SetFloat("Idle_Walk", -1.0f);
        if (isDrinking)
            StartCoroutine(AddWater(stats, water, anim));
    }

    IEnumerator AddWater(PersonStats _stats, float _water, Animator _anim)
    {
        isDrinking = false;
        _anim.SetBool("IsDrinking", true);
        yield return new WaitForSeconds(coroutineTime);
        _stats.ChangeThirst(_water);
        _anim.SetBool("IsDrinking", false);
        _stats.interact = false;
        InteractComplete(_stats);
        isDrinking = true;
    }

    public override void InteractComplete(PersonStats stats)
    {
        base.InteractComplete(stats);
    }
}
