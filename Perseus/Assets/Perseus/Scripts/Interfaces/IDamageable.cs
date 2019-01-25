using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable {

    void getBroken(float damage);
    void getFixed(float fixingSkill);
    void getDestroyed();
    IEnumerator wearOut();
    void takeDamage();
}
