using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
    public class Ship : MonoBehaviour
    {
        public float MAIN_DISTANCE = 600f;
        public float currentDistance;

        public float MAIN_TIME = 1800f;
        public float remainingTime;

        [SerializeField]
        public Quaternion normalRotation;
        [SerializeField]
        public Quaternion disruptedRotation = Quaternion.Euler(1f, -10f, 7f);

        //GENERAL SHIP PARAMETERS - MAX VALUES
        [SerializeField]
        private float max_shipStrenght;
        [SerializeField]
        public float max_shipShield;
        [SerializeField]
        private float max_shieldRestorationSpeed;
        [SerializeField]
        private float max_energy;
        [SerializeField]
        private float max_speed;
        [SerializeField]
        private float max_radiationDefence;
        public float normalRadiationLevel;

        private float max_oxigenLevel;
        private float shipStrenght;
        public float shipShield;
        private float shieldRestorationSpeed;
        public float energy;
        public float speed;
        public float currentRadiationLevel;

        //SHIP STORE
        [SerializeField]
        private float food;
        [SerializeField]
        private float water;
        [SerializeField]
        private float medicine;
        [SerializeField]
        private float oxigen;

        public float energyConsumption = 10f;

        // Use this for initialization
        void Start()
        {
            shipStrenght = max_shipStrenght;
            remainingTime = MAIN_TIME;
            currentDistance = MAIN_DISTANCE;
            normalRotation = transform.rotation;
            //FindObjectOfType<InGameUI>().gameObject.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {
            countdown();
            //checkStats();
        }

        private void countdown()
        {
            remainingTime -= Time.deltaTime;
            currentDistance = speed * (remainingTime/60f);
        }

        private void checkStats()
        {
            throw new NotImplementedException();
        }

        private void showStats()
        {
            throw new NotImplementedException();
        }

        public void seeShipStats()
        {
            FindObjectOfType<InGameUI>().showShipStats();
        }
    }
}
