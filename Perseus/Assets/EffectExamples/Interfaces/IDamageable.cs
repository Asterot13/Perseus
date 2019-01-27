using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable {

    bool isOnFire { get; set; }

    void getBroken(float damage);
    void getFixed(float fixingSkill);
    IEnumerator getDestroyed();
    IEnumerator wearOut();
    void takeDamage();
}
