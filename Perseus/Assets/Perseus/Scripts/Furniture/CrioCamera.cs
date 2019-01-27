using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrioCamera : Interactable {

    public float energy;

    public override void Interact(PersonStats stats, Animator anim)
    {
        anim.SetFloat("Idle_SpaceIdle", 0.0f);
        anim.SetFloat("Idle_Walk", -1.0f);
        //TODO: Здесь можно прикрутить запуск анимации
        stats.sleep = true;
        stats.stepEnergy = energy;
    }
}
