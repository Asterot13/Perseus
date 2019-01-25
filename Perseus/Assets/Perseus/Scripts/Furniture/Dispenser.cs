using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : Interactable {

    public float water;
    public float coroutineTime = 5f;
    private bool isDrinking = true;

    public override void Interact(PersonStats stats)
    {
        if(isDrinking)
            StartCoroutine(AddWater(stats, water));
    }

    IEnumerator AddWater(PersonStats _stats, float _water)
    {
        isDrinking = false;
        //TODO: Здесь можно прикрутить запуск анимации
        yield return new WaitForSeconds(coroutineTime);
        _stats.ChangeThirst(_water);
        _stats.interact = false;
        InteractComplete(_stats);
    }

    public override void InteractComplete(PersonStats stats)
    {
        base.InteractComplete(stats);
    }
}
