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
        private float dischargeSpeed;

        private float currentCharge;

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
