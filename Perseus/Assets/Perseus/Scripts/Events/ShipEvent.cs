using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEvent : MonoBehaviour {

    public void ignite(IDamageable obj)
    {
        //TODO: Burn particle
        obj.isOnFire = true;
    }

    public void damage(IDamageable obj)
    {
        obj.getBroken(40f);
    }

    public void callCustomEvent(GameObject obj)
    {

    }
}
