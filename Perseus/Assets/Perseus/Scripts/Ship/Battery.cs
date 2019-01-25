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

        private float currentCharge;

        [SerializeField]
        private float max_health;
        private float health;

        public void getBroken(float damage = 0)
        {
            if(currentCharge <= 50f && damage == 0)
            {
               //TODO: Battery Needs Fixing
            }
            else if(damage > 0)
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
            throw new System.NotImplementedException();
        }

        public void takeDamage()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator wearOut()
        {
            yield return new WaitForSecondsRealtime(30f);

        }

        public IEnumerator charge()
        {
            yield return new WaitForSecondsRealtime(10f);
            if (currentCharge > max_capacity)
                currentCharge = max_capacity;
            else
            {
                currentCharge += (_reactor.currentGeneratingPower - _ship.energyConsumption);
            }
        }


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            StartCoroutine(charge());
        }


    }
}
