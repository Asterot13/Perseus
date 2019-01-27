using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ship
{
    public class Battery : MonoBehaviour, IDamageable
    {

        [SerializeField]
        private Ship _ship;
        [SerializeField]
        private Reactor _reactor;

        [SerializeField]
        private float max_capacity;
        [SerializeField]
        private float chargeSpeed;
        [SerializeField]
        private float currentCharge;
        private bool isCharging = true;
        [SerializeField]
        private float max_health;
        [SerializeField]
        private float health;
        public float wearoutIndex;
        public bool isBurning;

        public bool isOnFire
        {
            get { return isOnFire; }
            set { isBurning = isOnFire; }
        }

        public void getBroken(float damage = 0)
        {
            if(health <= 50f && damage == 0)
            {
               //TODO: Battery Needs Fixing
            }
            else if(damage > 0 && health <= 50f)
            {
                //TODO: Show the same as above
            }
        }

        public float getSomeCharge(float request)
        {
            currentCharge -= request;
            return request;
        }

        public IEnumerator getDestroyed()
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
            yield return new WaitForSecondsRealtime(30f);
            health -= wearoutIndex * (isBurning ? 1.5f : 1); ;
        }

        public IEnumerator charge()
        {
            isCharging = false;
            yield return new WaitForSecondsRealtime(chargeSpeed);
            if (currentCharge > max_capacity)
                currentCharge = max_capacity;
            else
            {
                currentCharge += ((_reactor.currentGeneratingPower) - _ship.energyConsumption);
            }
            isCharging = true;
        }


        // Use this for initialization
        void Start()
        {
            health = max_health;
            currentCharge = max_capacity;
        }

        // Update is called once per frame
        void Update()
        {
            _ship.energy = currentCharge;
            if(isCharging)
                StartCoroutine(charge());
        }


    }
}
