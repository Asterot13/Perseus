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
        private float max_health;
        [SerializeField]
        private float max_shieldGeneratingCapacity;

        private float health;

        public void getBroken(float damage)
        {
            throw new System.NotImplementedException();
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

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
