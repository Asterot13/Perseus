using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
    public class Ship : MonoBehaviour
    {

        //GENERAL SHIP PARAMETERS - MAX VALUES
        [SerializeField]
        private float max_shipStrenght;
        [SerializeField]
        private float max_shipShield;
        [SerializeField]
        private float max_shieldRestorationSpeed;
        [SerializeField]
        private float max_energy;
        [SerializeField]
        private float max_speed;
        [SerializeField]
        private float max_radiationDefence;
        [SerializeField]
        private float noramlRadiationLevel;

        private float shipStrenght;
        private float shipShield;
        private float shieldRestorationSpeed;
        private float energy;
        private float speed;
        private float radiationDefence;
        private float currentRadiationLevel;

        //SHIP STORE
        [SerializeField]
        private float food;
        [SerializeField]
        private float water;
        [SerializeField]
        private float medicine;
        [SerializeField]
        private float oxigen;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            checkStats();
        }

        private void checkStats()
        {
            throw new NotImplementedException();
        }

        private void showStats()
        {
            throw new NotImplementedException();
        }
    }
}
