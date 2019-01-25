using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
    public class Reactor : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private float max_health;
        [SerializeField]
        private float max_generatingPower;

        private float currentGeneratingPower;
        private float health;

        public void getBroken()
        {
            throw new System.NotImplementedException();
        }

        public void getDestroyed()
        {
            throw new System.NotImplementedException();
        }

        public void getFixed()
        {
            throw new System.NotImplementedException();
        }

        public void takeDamage()
        {
            throw new System.NotImplementedException();
        }

        public void wearOut()
        {
            throw new System.NotImplementedException();
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
