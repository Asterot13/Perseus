using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : Interactable {

    public float food;
    public float coroutineTime = 5f;
    private bool isEating = true;

    public override void Interact(PersonStats stats)
    {
        if(isEating)
            StartCoroutine(AddFood(stats, food));
    }

    IEnumerator AddFood(PersonStats _stats, float _food)
    {
        isEating = false;
        //TODO: Здесь можно прикрутить запуск анимации
        yield return new WaitForSeconds(coroutineTime);
        _stats.ChangeHunger(_food);
        _stats.interact = false;
        InteractComplete(_stats);
    }

    public override void InteractComplete(PersonStats stats)
    {
        base.InteractComplete(stats);
    }
}
