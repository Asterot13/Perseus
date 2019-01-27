using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
    public class Reactor : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private Ship _ship;
        [SerializeField]
        private float max_health;
        [SerializeField]
        private float max_generatingPower;
        [SerializeField]
        private float wearoutIndex;
        public float radiation = 1f;
        private bool isWearingOut = true;

        public float currentGeneratingPower;
        [SerializeField]
        private float health;
        public bool isBurning;
        private bool isEmittingRadiation;
        private bool isFixed;
        public bool isOnFire
        {
            get {  return isBurning; }
            set { isBurning = isOnFire;  }
        }

        public void getBroken(float damage = 0)
        {
            if(health <= 50f && damage == 0)
            {
                isEmittingRadiation = true;
                isFixed = false;
                //TODO: Enable particles and ui indicators
            }
            else if(damage > 0)
            {
                health -= damage;
                //TODO: Enable particles and ui indicators
            }
        }

        public void getDestroyed()
        {
            throw new System.NotImplementedException();
        }

        public void getFixed(float fixingSkill)
        {
            if (max_health > health)
            {
                health += fixingSkill;
                isFixed = true;
            }
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
            health -= wearoutIndex * (isBurning ? 1.5f : 1);
            currentGeneratingPower *= (health / 100);
            isWearingOut = true;
        }

        public IEnumerator emitRadiation()
        {
            isEmittingRadiation = false;
            yield return new WaitForSecondsRealtime(5f);
            _ship.currentRadiationLevel += radiation;
            isEmittingRadiation = true;
        }

        public IEnumerator lowerRadiation()
        {
            isEmittingRadiation = false;
            yield return new WaitForSecondsRealtime(5f);
            _ship.currentRadiationLevel -= radiation;
            isEmittingRadiation = true;
        }

        // Use this for initialization
        void Start()
        {
            health = max_health;
            currentGeneratingPower = max_generatingPower/10;
            isOnFire = false;
        }

        // Update is called once per frame
        void Update()
        {
            if(isWearingOut)
                StartCoroutine(wearOut());
            if ((health <= 50f || isOnFire) && isEmittingRadiation)
                StartCoroutine(emitRadiation());
            if (isFixed && _ship.currentRadiationLevel > 0)
                StartCoroutine(lowerRadiation());
        }
    }
}
