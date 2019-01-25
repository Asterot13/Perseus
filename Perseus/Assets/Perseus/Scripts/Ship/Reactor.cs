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

        public float currentGeneratingPower;
        private float health;

        public void getBroken(float damage = 0)
        {
            if(health <= 50f && damage == 0)
            {
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
            health -= wearoutIndex;
        }

        // Use this for initialization
        void Start()
        {
            health = max_health;
            currentGeneratingPower = max_generatingPower;
        }

        // Update is called once per frame
        void Update()
        {
            currentGeneratingPower *= (health / 100);
            StartCoroutine(wearOut());
        }
    }
}
