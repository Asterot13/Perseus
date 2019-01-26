using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
    public class ShieldGenerator : MonoBehaviour, IDamageable
    {

        [SerializeField]
        private Ship _ship;
        [SerializeField]
        private Battery _battery;
        [SerializeField]
        private float max_health;

        private bool isWearingOut = true;
        private bool isCharging = true;
        [SerializeField]
        private float wearingOutIndex;
        [SerializeField]
        private float chargeSpeed;
        private float chargeRequest = 5f;

        private float health;

        public void getBroken(float damage)
        {
            if (health <= 50f && damage == 0)
            {
                //TODO: Battery Needs Fixing
            }
            else if (damage > 0 && health <= 50f)
            {
                //TODO: Show the same as above
            }
        }

        public void getDestroyed()
        {
            throw new System.NotImplementedException();
        }

        public void getFixed(float fixingSkill)
        {
            if (max_health > health)
                health += fixingSkill;
            else
                print("Object is fixed"); //TODO: Display in UI
        }

        public void takeDamage()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator wearOut()
        {
            isWearingOut = false;
            yield return new WaitForSecondsRealtime(5f);
            health -= wearingOutIndex;
            isWearingOut = true;
        }

        public IEnumerator charge()
        {
            isCharging = false;
            yield return new WaitForSecondsRealtime(chargeSpeed);
            if (_ship.shipShield > _ship.max_shipShield)
                _ship.shipShield = _ship.max_shipShield;
            else
            {
                _ship.shipShield += _battery.getSomeCharge(chargeRequest);
            }
            isCharging = true;
        }

        // Use this for initialization
        void Start()
        {
            health = max_health;
        }

        // Update is called once per frame
        void Update()
        {
            if (isWearingOut)
                StartCoroutine(wearOut());
            if (isCharging)
                StartCoroutine(charge());
        }
    }
}
