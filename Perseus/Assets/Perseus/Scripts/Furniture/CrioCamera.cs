using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrioCamera : Interactable {

    public float energy;

    public override void Interact(PersonStats stats)
    {
        //TODO: Здесь можно прикрутить запуск анимации
        stats.sleep = true;
        stats.stepEnergy = energy;
    }
}
