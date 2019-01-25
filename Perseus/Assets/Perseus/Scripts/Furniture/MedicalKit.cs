using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalKit : Interactable {

    public float medHelp;
    public float coroutineTime = 5f;
    private bool isHealing = true;

    public override void Interact(PersonStats stats)
    {
        if (isHealing)
            StartCoroutine(AddMedHelp(stats, medHelp));
    }

    IEnumerator AddMedHelp(PersonStats _stats, float _medHelp)
    {
        isHealing = false;
        //TODO: Здесь можно прикрутить запуск анимации
        yield return new WaitForSeconds(coroutineTime);
        _stats.ChangeLife(_medHelp);
        _stats.interact = false;
        InteractComplete(_stats);
    }

    public override void InteractComplete(PersonStats stats)
    {
        base.InteractComplete(stats);
    }
}
