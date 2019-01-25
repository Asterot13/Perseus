using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable {

    void getBroken();
    void getFixed();
    void getDestroyed();
    void wearOut();
    void takeDamage();
}
