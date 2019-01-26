using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : Interactable {

    public float food;
    public float coroutineTime = 5f;
    private bool isEating = true;

    public override void Interact(PersonStats stats, Animator anim)
    {
        anim.SetFloat("Idle_SpaceIdle", 0.0f);
        anim.SetFloat("Idle_Walk", -1.0f);

        if (isEating)
            StartCoroutine(AddFood(stats, food, anim));
    }

    IEnumerator AddFood(PersonStats _stats, float _food, Animator _anim)
    {
        isEating = false;
        _anim.SetBool("IsEating", true);
        yield return new WaitForSeconds(coroutineTime);
        _stats.ChangeHunger(_food);
        _anim.SetBool("IsEating", false);
        _stats.interact = false;
        InteractComplete(_stats);
    }

    public override void InteractComplete(PersonStats stats)
    {
        base.InteractComplete(stats);
    }
}
